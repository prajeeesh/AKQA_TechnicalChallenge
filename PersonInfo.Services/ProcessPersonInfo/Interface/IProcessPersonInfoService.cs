using PersonInfo.Model;
using System.Threading.Tasks;

namespace PersonInfo.Services.Interface
{
    public interface IProcessPersonInfoService
    {
        Task<PersonInfoModel> GetPersonInfoFromApi(string personInfo);
    }
}
