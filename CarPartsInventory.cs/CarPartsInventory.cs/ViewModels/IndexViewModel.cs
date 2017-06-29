using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarPartsInventory.cs.Models;

namespace CarPartsInventory.cs.ViewModels
{
    public class IndexViewModel
    {

        public Order CurrentOrder { get; set; }

        public int SelectedPart { get; set; }

        public IndexViewModel()
        {
            CurrentOrder = new Order();
        }

    }
}