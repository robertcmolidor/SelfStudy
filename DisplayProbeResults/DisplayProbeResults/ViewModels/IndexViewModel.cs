using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DisplayProbeResults.EntityModels;


namespace DisplayProbeResults.ViewModels
{
    public class IndexViewModel
    {
        
        public List<Profile> Profiles { get; set; }
        public List<Result> Results { get; set; }
        public List<CheckType> CheckTypes { get; set; }


        public int Runs { get; set; }
        public int ProfilesChecked { get; set; }
        public int ProfilesNotRun { get; set; }
        public double PercentageSuccessful { get; set; }


        public List<Result> RelevantResults { get; set; }
        public List<Result> SuccessfulResults { get; set; }
        public List<Result> FailedResults { get; set; }

        public Dictionary<int,int> CheckTypeSuccesses { get; set; }
        public Dictionary<int, int> CheckTypeFails { get; set; }

        public Dictionary<string, int> Errors { get; set; }
        public int Nulls { get; set; }


        public IndexViewModel()
        {
            Profiles = new List<Profile>();
            Results = new List<Result>();
            CheckTypes= new List<CheckType>();
            RelevantResults = new List<Result>();
            SuccessfulResults = new List<Result>();
            FailedResults =new List<Result>();
            CheckTypeSuccesses = new Dictionary<int, int>();
            CheckTypeFails = new Dictionary<int, int>();
            Errors = new Dictionary<string, int>();
            Runs = 0;
            ProfilesChecked = 0;
            ProfilesNotRun = 0;
            PercentageSuccessful = 0;
            Nulls = 0;
        }
    }
}