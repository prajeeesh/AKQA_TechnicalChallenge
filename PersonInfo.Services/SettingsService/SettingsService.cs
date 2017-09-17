using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonInfo.Common;
using PersonInfo.Services.Interface;
namespace PersonInfo.Services
{
    public class SettingsService : ISettingsService
    {
        public SettingsService()
        {
        }

        public string GetWebApiPath()
        {
            var apiEndPoint = Common.ConfigSettingsReader.GetConfigurationValues(Constants.APIEndPoint);
            var personalInfoService = Common.ConfigSettingsReader.GetConfigurationValues(Constants.PersonalInfoService);
            return apiEndPoint + personalInfoService;
        }
    }
}
