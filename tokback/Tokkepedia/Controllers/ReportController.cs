using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rotativa.NetCore;
using Rotativa.NetCore.Options;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Controllers
{
    public class ReportController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokService _tokService;

        public ReportController(IUserService userService, ITokService tokService)
        {
            _userService = userService;
            _tokService = tokService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> User(ReportViewModel reportModel)
        {
            ResultViewModel result = new ResultViewModel();
            result.ResultTitle = "Report Failed!";

            if(ModelState.IsValid)
            {
                // Call api report service here.

                result.ResultEnum = Result.Success;
            }
            else
            {
                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        result.ResultMessage = error.ErrorMessage + "&nbsp;";
                    }
                }
            }

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> DownloadPersonalData()
        {
            var userAccount = await _userService.GetUserAsync(HttpContext.User.Identity.Name);
            TokketUser user = JsonConvert.DeserializeObject<TokketUser>(JsonConvert.SerializeObject(userAccount));

            return new PartialViewAsPdf("User/_PersonalDataPDF", user) { // Temporary
                FileName = "tokkepedia_personalData.pdf",
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 8",
                PageSize = Size.A4,
                PageOrientation = Orientation.Portrait,
                PageMargins = new Margins(10, 5, 10, 5)
            };
        }

        [HttpPost]
        public async Task<IActionResult> ReportTok(string message)
        {
            ResultViewModel result = new ResultViewModel();
            result.ResultEnum = Result.Failed;
            result.ResultMessage = "Report Failed!";

            if (!string.IsNullOrEmpty(message))
            {
                if (await _tokService.CreateReportAsync(new Report() { Message = message }))
                {
                    result.ResultEnum = Result.Success;
                    result.ResultMessage = "Report Successful!";
                }
            }

            return Json(result);
        }
    }
}