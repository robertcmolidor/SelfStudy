using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MatrixChallenge.Models;
using MatrixChallenge.ViewModels;

namespace MatrixChallenge.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            return View(model);
        }

        public ActionResult NumberEntry(IndexViewModel input)
        {
            var model = new NumberEntryViewModel();
            model.Matrices.Add(new Matrix(input.Rows,input.Cols));
            model.Matrices.Add(new Matrix(input.Rows, input.Cols));


            return View(model);
        }

        public ActionResult Result(NumberEntryViewModel input)
        {
            var total = input.Matrices[0];
            for (int i = 1; i < input.Matrices.Count; i++)
            {
                try
                {
                    total.Add(input.Matrices[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                   
                }
                
            }
            return View(total);
        }
    }
}