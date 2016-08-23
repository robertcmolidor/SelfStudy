using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DisplayProbeResults.EntityModels;
using DisplayProbeResults.Utils;
using DisplayProbeResults.ViewModels;

namespace DisplayProbeResults.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            var machine = new Guid("CD3291FA-A11A-4A54-8C6A-5FD9D1C8CF6E");
            using (var db = new ProbeContext())
            {
                viewModel.Profiles = await db.Profiles.Where(x => x.MachineID == machine).ToListAsync();
                viewModel.Results = await db.Results.Where(x => x.HourStamp > new DateTime(2016, 8, 17)).ToListAsync();
                viewModel.CheckTypes = await db.CheckTypes.ToListAsync();
            }

            //var TestsPerProfile = new List<int>();

            foreach (var profile in viewModel.Profiles)
            {
                viewModel.Runs = 0;
                foreach (var result in viewModel.Results)
                {
                    if (profile.ProfileID == result.ProfileID)
                    {
                        viewModel.Runs++;
                        viewModel.RelevantResults.Add(result);
                        if (result.Success)
                            viewModel.SuccessfulResults.Add(result);
                        else
                        {
                            viewModel.FailedResults.Add(result);
                        }
                    }
                }
                viewModel.ProfilesChecked++;
                if (viewModel.Runs == 0)
                {
                    viewModel.ProfilesNotRun++;
                }

            }
            viewModel.PercentageSuccessful = ((double) viewModel.SuccessfulResults.Count/(double) viewModel.RelevantResults.Count);

            

            
            //counting successes per test type
            
            foreach (var profile in viewModel.Profiles)
            {
                if (viewModel.CheckTypeSuccesses.ContainsKey(profile.CheckType))
                {
                    foreach (var result in viewModel.RelevantResults)
                    {
                        if (profile.ProfileID == result.ProfileID && result.Success)
                        {
                            int value;
                            viewModel.CheckTypeSuccesses.TryGetValue(profile.CheckType, out value);
                            viewModel.CheckTypeSuccesses[profile.CheckType] = value + 1;
                        }
                        if (profile.ProfileID == result.ProfileID && !result.Success)
                        {
                            int value;
                            viewModel.CheckTypeFails.TryGetValue(profile.CheckType, out value);
                            viewModel.CheckTypeFails[profile.CheckType] = value + 1;

                        }
                    }
                }
                else
                {
                    viewModel.CheckTypeSuccesses.Add(profile.CheckType, 0);
                    viewModel.CheckTypeFails.Add(profile.CheckType, 0);
                }
            }
            var checkTypeSuccessesSorted = viewModel.CheckTypeSuccesses.OrderBy(x => x.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
            viewModel.CheckTypeSuccesses = checkTypeSuccessesSorted;


            foreach (var result in viewModel.FailedResults)
            {
                if (result.Message != null)
                {
                    if (viewModel.Errors.ContainsKey(result.Message))
                    {
                        int value;
                        viewModel.Errors.TryGetValue(result.Message, out value);
                        viewModel.Errors[result.Message] = value + 1;

                    }
                    else
                    {
                        viewModel.Errors.Add(result.Message, 1);
                    }
                }
                else
                {
                    viewModel.Nulls++;
                }
            }
            var errorsOrdered = viewModel.Errors.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value); ;
            viewModel.Errors = errorsOrdered;
            return View(viewModel);
        }
    }
}

