using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PersonInfo.Model;
using PersonInfo.Services.Interface;

namespace PersonInfo.Services
{
    public class ProcessPersonInfoService: IProcessPersonInfoService
    {
        private readonly ISettingsService settingsService;

        public ProcessPersonInfoService(ISettingsService _settingsService)
        {
            settingsService = _settingsService;
        }
        public async Task<PersonInfoModel> GetPersonInfoFromApi(string personInfo)
        {
            string uri = settingsService.GetWebApiPath();
            string[] stringSeparators = new string[] { "\r\n" };
            var details = personInfo.TrimEnd().Split(stringSeparators, StringSplitOptions.None);
            PersonInfoModel personInfoModel = new PersonInfoModel
            {
                Name = details[0],
                Number = Convert.ToDecimal(details[1])
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(personInfoModel), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(uri, content);
                    var FinalResults = await response.Content.ReadAsAsync<PersonInfoModel>();
                    return FinalResults;  
                }
            }
            catch (Exception ex)
            {
                //Log Exception 
                Console.WriteLine(ex.Message);
                throw new Exception("Error occured while accessing the service API");
            }
        }
    }
}
