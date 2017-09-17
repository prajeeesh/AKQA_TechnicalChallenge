using PersonInfo.Services.Interface;
using System.Web.Mvc;
using PersonInfo.Model;
using System;
using System.Threading.Tasks;

namespace PersonInfo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcessPersonInfoService processPersonInfoService;
        public HomeController(IProcessPersonInfoService _processPersonInfoService)
        {
            processPersonInfoService = _processPersonInfoService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string personalDetails)
        {
            PersonInfoModel personInfoModel = new PersonInfoModel();
            try
            {
                personInfoModel.Message = ValidateInputValues(personalDetails);
                if (string.IsNullOrEmpty(personInfoModel.Message))
                {
                    personInfoModel = await processPersonInfoService.GetPersonInfoFromApi(personalDetails);
                }
            }
            catch (Exception ex)
            {
                //Log the error message

            }
            return View(personInfoModel);
        }
       /// <summary>
       /// <param name="values"></param>
       /// <returns></returns>
        public string ValidateInputValues(string values)
        {
            var errorMessage = string.Empty;
            string[] stringSeparators = new string[] { "\r\n" };
            var details = values.TrimEnd().Split(stringSeparators, StringSplitOptions.None);
            if (details.Length < 2)
            {
                errorMessage = "Please enter both the inputs";
            }
            else
            {
                string[] amount = details[1].Split('.');
                if (amount[0].Length > 7)
                    errorMessage = "Please enter a smaller number";
            }
            return errorMessage;
        }
    }
}