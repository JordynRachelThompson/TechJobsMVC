using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;


            if (searchType == "all")
                if (searchTerm == null)
                {
                    List<Dictionary<string, string>> theJobs = JobData.FindAll();
                    ViewBag.jobs = theJobs;
                }

                else 
                {
                    List<Dictionary<string, string>> theJobs = JobData.FindByValue(searchTerm);
                    ViewBag.jobs = theJobs; 
                }

            else
            {
                List<Dictionary<string, string>> theJobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = theJobs;
            }

            return View("index");         
        }

    }
}
