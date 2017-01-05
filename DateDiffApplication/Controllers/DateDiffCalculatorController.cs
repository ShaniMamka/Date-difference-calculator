using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DateDiffApplication.BusinessLogic;
using DateDiffApplication.Models;

namespace DateDiffApplication.Controllers
{
    public class DateDiffCalculatorController : Controller
    {
        [HttpGet]
        public ActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateDateDiff(String startDate, String endDate)
        {
            String dateDiff;

            if (String.Compare(startDate, endDate) > 0)
            {
                dateDiff = "Start date should always be before end date!";
            }
            else
            {
                String[] startDateSplit = startDate.Split('-');
                Date startDateObj = new Date(int.Parse(startDateSplit[2]), int.Parse(startDateSplit[1]), int.Parse(startDateSplit[0]));

                String[] endDateSplit = endDate.Split('-');
                Date endDateObj = new Date(int.Parse(endDateSplit[2]), int.Parse(endDateSplit[1]), int.Parse(endDateSplit[0]));

                int dateDiffResult = DateService.GetDateDiffInDays(startDateObj, endDateObj);
                dateDiff = String.Format("Days between two dates: {0}", dateDiffResult);
            }

            return Json(dateDiff, JsonRequestBehavior.AllowGet);
        }
    }
}
