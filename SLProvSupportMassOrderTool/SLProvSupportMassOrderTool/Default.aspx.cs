/*
INCOMPLETE PROJECT
SoftLayer Mass Order Tool
uses web reference https://api.softlayer.com/soap/v3/SoftLayer_Product_Order?wsdl

This was written for the provisioning support group to efficiently and easily drop large orders to stress test provisioning systems
it allows for the choice of preset config, datacenter, operating system, and quantity of servers to provision.
builds an order template of type SoftLayer_Container_Product_Order_Hardware_Server to send to orderService.*
it will allow for successive submissions with the hostname indexing appropriately.
hostnames are of standard format PST[DC][OS][###].

Considerations:
Currently server quantity is confirmed by checking hostnames.
Order verification and submission is not yet implemented.  it is commented out until proper api pulls are athorized by softlayer account.
Order items, or billing items, are not properly defined in getconfig preconfigs.  This information needs to come from someone in house to help.


Valuable References: 
softlayer/orderBareMetalInstance.cs     https://gist.github.com/softlayer/570676/02b391441f0388d89c8dc4dea1243e6e3c923241
SLDN|Reference                          http://sldn.softlayer.com/reference/services/SoftLayer_Product_Order
Basic introductory training from EpicU  http://www.epicu.org/
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SLProvSupportMassOrderTool.com.softlayer.api;


namespace SLProvSupportMassOrderTool
{
    public partial class Default : System.Web.UI.Page
    {
        static String username = "provsupport";                                       //set static to username of softlayer account
        static String apiKey = "6bfe39025f431808b91e651e4c4066851c0a0a2937499de9bf682ed7888a6708";                                         //set static to apikey found in the customer portal
        int hostNameIndex = 0;                                      //creating a global host name index incrementing per server ordered
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ViewState.Add("hostNameIndex", 0);                  //adds a hostNameIndex viewstate if this is the first load
                
            }
                
        }
        protected void verifyOrderButton_Click(object sender, EventArgs e)
        {
            SoftLayer_Container_Product_Order_Hardware_Server orderTemplate = buildTemplate();  //creates new order template and sets it to the values returned by build template
            try
            {
                if (verifyOrder(orderTemplate))                                                     //sends template to verifyorder and sets label if true
                {
                    setVerifyLabel(orderTemplate);
                }
            }
            catch (Exception ex)
            {
                setVerifyLabel("ERROR: Order did not pass verification" + ex.Message);
            }
                
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SoftLayer_Container_Product_Order_Hardware_Server orderTemplate = buildTemplate();
            try
            {
                if (submitOrder(orderTemplate))
                {
                    appendOrderedLabel(orderTemplate);
                    ViewState["hostNameIndex"] = hostNameIndex;
                }
            }
            catch (Exception ex)
            {
                setVerifyLabel("ERROR: Order did not submit" + ex.Message);
            }
            
        }

        //takes the user input from the app and builds an order template accordingly then returns the completed template
        private  SoftLayer_Container_Product_Order_Hardware_Server buildTemplate()
        {
            //create order variables
            string hostname = "PST" + locationDropDown.SelectedItem.Text + osDropDown.SelectedItem.Text;                       //creates the hostname string with pst[location][os][index]
            string domain = "testdomain.com";                                                                                  //setting this to testdomain for now since it's been the standard                                                                     
            int quantity = 0;
            hostNameIndex = int.Parse(ViewState["hostNameIndex"].ToString());
            
            //checking for realistic order amounts and setting quantity
            if (int.Parse(quantityTextBox.Text) >= 1 && int.Parse(quantityTextBox.Text) <= 50 && quantityTextBox.Text != "") //FormatException: Input string was not in a correct format.  this happens when textbox has nothing entered.
                quantity = int.Parse(quantityTextBox.Text);
            else
                verifyLabel.Text = "you must select between 1 and 50 servers.";

            //defining orderItems                                                   //this is used to flag product IDs for our order. this is important.
            int[] orderItems = GetConfig(int.Parse(configDropDown.SelectedValue));  //sends the selected config to getconfig and sets the configs to orderItems
            Array.Resize(ref orderItems, orderItems.Length + 1);                    //resizes array to squeeze in the OS
            orderItems[orderItems.GetUpperBound(0)] = int.Parse(osDropDown.Text);   //sets the last slot in the array to os id

            //create an order template
            SoftLayer_Container_Product_Order_Hardware_Server orderTemplate = new SoftLayer_Container_Product_Order_Hardware_Server();

            //set order template variables
            orderTemplate.packageId = 50; //apparently package ID 50 denotes we're ording a bare metal.  
            orderTemplate.packageIdSpecified = true;

            //sets selected location from the drop down.  it's the value of the selected DC which will be changed to the location ID
            orderTemplate.location = locationDropDown.SelectedValue.ToString();
            orderTemplate.quantity = quantity;
            orderTemplate.quantitySpecified = true;
            orderTemplate.hardware = new SoftLayer_Hardware_Server[quantity];               //creating array of quantity size

            for (int i = 0; i < quantity; i++)
            {
                orderTemplate.hardware[i] = new SoftLayer_Hardware_Server();                    //initializing array of servers quantity size
                orderTemplate.hardware[i].hostname = hostname + hostNameIndex.ToString("000");  //sets hostname to formatted string
                orderTemplate.hardware[i].domain = domain;                                      //sets domain to provided domain
                hostNameIndex++;
            }

            // Convert our array of orderItems ids into SoftLayer_Product_Item_Price objects
            List<SoftLayer_Product_Item_Price> orderPrices = new List<SoftLayer_Product_Item_Price>();   //creating a list of product item prices based on our orderItems
            foreach (int priceId in orderItems)                                                          //parses through each index of orderItems[]
            {
                SoftLayer_Product_Item_Price price = new SoftLayer_Product_Item_Price();                 //creates new softlayer product item price called price
                price.id = priceId;                                                                      //price.id is set to the contents of orderItems[]
                price.idSpecified = true;                                                                //Price.idSpecified set to true since there is content
                orderPrices.Add(price);                                                                  //adds price to the list                                                              
            }
            orderTemplate.prices = orderPrices.ToArray();
            return orderTemplate;
        }


        //this is going to take the selected value of the configuration selection and spit back a config.  
        private int[] GetConfig(int selection)
        {

            switch (selection)//config 0
            {
                case 0:
                    {
                        int[] orderItems = {
                            2165,   // 4 cores + 16G RAM
                            19,     // 250G hard drive
                            274,    // 1000mbps public & private network
                            34,     // 2000GB monthly bandwidth allocation
                            905,    // reboot / remote console access
                            21,     // single primary IP address
                            22,     // 4x public IP addresses
                            1867,   // Windows 2008 R2, Datacenter Edition (64-bit) with Hyper-v
                            894,    // Windows Firewall
                            55,     // host ping monitoring
                            57,     // email and ticket monitoring notification
                            58,     // automated notification response
                            420,    // unlimited SSL and 1 PPTP VPN users per account
                            418,    // Nessus vulnerability and assessment reporting
                                        };
                        return orderItems;
                    }
                case 1:
                    {
                        int[] orderItems = { };
                        return orderItems;
                    }
                case 2:
                    {
                        int[] orderItems = { };
                        return orderItems;
                    }
                case 3:
                    {
                        int[] orderItems = { };
                        return orderItems;
                    }
                case 4:
                    {
                        int[] orderItems = { };
                        return orderItems;
                    }

            }
            int[] orderNull = { };
            return orderNull;
        }

        private bool verifyOrder(SoftLayer_Container_Product_Order_Hardware_Server orderTemplate)
        {

            authenticate authenticate = new authenticate();
            authenticate.username = username;
            authenticate.apiKey = apiKey;
            SoftLayer_Product_OrderService orderService = new SoftLayer_Product_OrderService();
            orderService.authenticateValue = authenticate;
            try
            {
                SoftLayer_Container_Product_Order_Hardware_Server verifiedOrder = (SoftLayer_Container_Product_Order_Hardware_Server)orderService.verifyOrder(orderTemplate);
                return true;
            }
            catch (Exception ex)
            {
                setVerifyLabel("ERROR: Order did not submit" + ex.Message);
                return false;
            }
          
        }

        private bool submitOrder(SoftLayer_Container_Product_Order_Hardware_Server orderTemplate)
        {
            /*
            authenticate authenticate = new authenticate();
            authenticate.username = username;
            authenticate.apiKey = apiKey;
            SoftLayer_Product_OrderService orderService = new SoftLayer_Product_OrderService();
            orderService.authenticateValue = authenticate;
            try
            {
                SoftLayer_Container_Product_Order_Receipt orderReceipt = orderService.placeOrder(orderTemplate, false);
                return true;
            }
            catch
            {
                return false;
            }
            */
            writeHostnames(orderTemplate);
            return true;
        }

        private void appendOrderedLabel(SoftLayer_Container_Product_Order_Hardware_Server orderTemplate)
        {
            int i = orderTemplate.hardware.Length-1;
            orderedLabel.Text += orderTemplate.hardware[0].hostname + "." + orderTemplate.hardware[0].domain 
                + "<br /> Through<br />" 
                + orderTemplate.hardware[i].hostname 
                + "." 
                + orderTemplate.hardware[i].domain
                +"<br />";
            
        }
        private void setVerifyLabel(SoftLayer_Container_Product_Order_Hardware_Server orderTemplate)
        {
            verifyLabel.Text = orderTemplate.hardware.Length.ToString() + " HardWares Verified";
        }
        private void setVerifyLabel(string output)
        {
            verifyLabel.Text = output;
        }
        private void writeHostnames(SoftLayer_Container_Product_Order_Hardware_Server orderTemplate)
        {
            for (int n = 0; n < orderTemplate.hardware.Length - 1; n++)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\slprovsupportmassordertool output\hostnames.txt", true))
                {
                    file.WriteLine(orderTemplate.hardware[n].hostname + "." + orderTemplate.hardware[n].domain);
                }
            }
        }

    }
    }
