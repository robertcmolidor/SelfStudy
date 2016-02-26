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

        String username = "";
        String apiKey = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ViewState.Add("hostNameIndex", 0);
            }
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //create order variables
            string hostname = "PST" + locationDropDown.SelectedItem.Text + osDropDown.SelectedItem.Text;                       //creates the hostname string with pst[location][os][index]
            string domain = "testdomain.com";                                                        //setting this to testdomain for now since it's been the standard                                                                     
            int quantity = 0;
            int hostNameIndex = int.Parse(ViewState["hostNameIndex"].ToString());
            //checking for realistic order amounts and setting quantity
            if (int.Parse(quantityTextBox.Text) >= 1 && int.Parse(quantityTextBox.Text) <= 50 && quantityTextBox.Text != "")
                quantity = int.Parse(quantityTextBox.Text);
            else
                resultLabel.Text ="you must select between 1 and 50 servers.";




            //defining orderItems                                                   //this is used to flag product IDs for our order. this is important.
            int[] orderItems = GetConfig(int.Parse(configDropDown.SelectedValue));  //sends the selected config to getconfig and sets the configs to orderItems
            Array.Resize(ref orderItems, orderItems.Length + 1);                    //resizes array to squeze in the OS
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

            for (int i=0; i < quantity; i++)
            {
                orderTemplate.hardware[i] = new SoftLayer_Hardware_Server();                 //initializing array of servers quantity size
                orderTemplate.hardware[i].hostname = hostname + hostNameIndex.ToString("000");    //sets hostname to formatted string  need to figure out how to force 3 spots
                orderTemplate.hardware[i].domain = domain;                                   //sets domain to provided domain
                hostNameIndex++;
            }
            ViewState["hostNameIndex"] = hostNameIndex;

            //display the stuff.  bye!
            for (int i = 0; i < quantity; i++)
                resultLabel.Text += orderTemplate.hardware[i].hostname + "." + orderTemplate.hardware[i].domain +"<br />";


            





            /*set username and apikey to a new authenticate
            authenticate authenticate = new authenticate();
            authenticate.username = username;
            authenticate.apiKey = apiKey;
            */










        }

        //this is going to take the selected value of the congiguration selection and spit back a config.  
        private int[] GetConfig(int selection)
        {
            
            switch(selection)//config 0
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
    }
}