using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MatrixChallenge.Models;

namespace MatrixChallenge.ViewModels
{
    public class NumberEntryViewModel
    {
        public List<Matrix> Matrices { get; set; }

        public NumberEntryViewModel()
        {
            Matrices = new List<Matrix>();
        }
    }
}