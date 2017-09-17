using System.Web.Http;
using PersonInfo.Model;
using System;
namespace PersonInfo.ProcessDetailsApi.Controllers
{
    public class ProcessPersonalDetailsController : ApiController
    {
        static string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        static string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        static string[] words2 = { "", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personInfoModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/ProcessPersonalDetails/{personDetailsModel}")]
        public PersonInfoModel GetPersonalDetails([FromBody] PersonInfoModel personInfoModel)
        {
            return ProcessDetails(personInfoModel);
        }
        private PersonInfoModel ProcessDetails(PersonInfoModel personInfoModel)
        {
            personInfoModel.NumberString = ConvertToWords(personInfoModel.Number);
            return personInfoModel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ConvertToWords(decimal number)
        {
            string numberInWords = string.Empty;
            int numberPart = Convert.ToInt32(Math.Floor(number));
            int decimalpart = Convert.ToInt32((number - numberPart) * 100);
            int thosands, hundrerd, tens, ones, lakhs = 0;
            lakhs = Convert.ToInt32(numberPart / 100000);
            thosands = Convert.ToInt32((numberPart - lakhs * 100000) / 1000);
            hundrerd = Convert.ToInt32((numberPart - ((thosands * 1000) + (lakhs * 100000))) / 100);
            tens = Convert.ToInt32(numberPart - ((lakhs * 100000) + (thosands * 1000) + (hundrerd * 100)));

            ones = Convert.ToInt32((numberPart - tens));
            if (lakhs > 0)
                numberInWords = (lakhs > 10 ? SplitWords(lakhs) : words0[lakhs]) + " lakh ";
            if (thosands > 0)
                numberInWords += (thosands > 10 ? SplitWords(thosands) : words0[thosands]) + " Thousand ";
            if (hundrerd > 0)
                numberInWords += words0[hundrerd] + " hundred ";
            if (tens > 10)
                numberInWords += SplitWords(tens) + " Dollars ";
            else
                numberInWords += words0[tens] + " Dollars ";

            if (decimalpart > 0)
            {
                if (decimalpart > 10)
                    numberInWords += SplitWords(decimalpart) + " Cents";
                else
                    numberInWords += words0[decimalpart] + " Cents";
            }
            return numberInWords;
        }
        /// <summary>
         /// 
         /// </summary>
         /// <param name="number"></param>
         /// <returns></returns>
        private static string SplitWords(int number)  
        {
            string words = string.Empty;
            int num1 = 0;
            int num2 = 0;
            num1 = number / 10;
            num2 = number % 10;
            words = (num1 == 1 ? words1[num2] : words2[num1 - 1] + words0[num2]);
            return words;
        }
    }
}