using Google.Cloud.Translation.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Scratcher.Controllers
{
    [RoutePrefix("api/transtester")]
    public class translationController : ApiController
    {
        /// <summary>
        /// Input text for input field, and then add langauge code for what language you want back
        /// </summary>
        /// <param name="inputvalue"></param>
        /// <param name="language_code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public string GetTranslation(string inputvalue, string language_code)
        {
            //documentation here: https://cloud.google.com/translate/docs/quickstart?csw=1
            //enable api here maybe: https://console.cloud.google.com/apis/api/translate.googleapis.com/overview?project=curious-song-235615&folder&organizationId
            string credential_path = @"FilePath\googlekey.json";
            System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            TranslationClient client = TranslationClient.Create();
            var response = client.TranslateText(inputvalue, language_code);
            return response.TranslatedText;
        }
    }
}
