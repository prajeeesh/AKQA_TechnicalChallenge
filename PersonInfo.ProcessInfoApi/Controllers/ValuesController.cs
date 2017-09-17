using System.Web.Http;
using PersonInfo.Model;
using System;
using System.Collections.Generic;

namespace PersonInfo.ProcessInfoApi.Controllers
{
    public class ValuesController : ApiController
    {
        static string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
        static string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
        static string[] words2 = { "", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        [Route("api/ProcessPersonalDetails/{personDetailsModel}")]
        public PersonInfoModel GetPersonalDetails([FromBody] PersonInfoModel personInfoModel)
        {
            return ProcessDetails(personInfoModel);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
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
            int thosands, hundrerd, tens, ones, millions = 0;
            millions = Convert.ToInt32(number / 1000000);
            thosands = Convert.ToInt32(number / 1000);
            hundrerd = Convert.ToInt32((number - thosands * 1000) / 100);
            tens = Convert.ToInt32(number - ((thosands * 1000) + (hundrerd * 100)));

            ones = Convert.ToInt32((number - tens));
            if (thosands > 0)
            {
                numberInWords = (thosands > 10 ? SplitWords(thosands) : words0[thosands]) + "Thousand ";
                //if (thosands > 1)
                // numberInWords = words0[thosands] + "Thousand ";
            }
            if (hundrerd > 0)
                numberInWords += words0[hundrerd] + "hundred ";
            if (tens > 10)
                numberInWords += SplitWords(tens);
            else
                numberInWords += words0[tens];
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
            //if (num1 == 1)
            //    words = words1[num2];
            //words = words2[num1-1] + words0[num2];
            return words;
        }
    }
}
