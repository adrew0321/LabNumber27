using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LabNumber27.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Step 1 : Build and make request to API
            HttpWebRequest API_Request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=json");

            // used to add keys
            // no keys used

            // assing UserAgent
            API_Request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";

            // Step 2 : Build and make response back to client
            HttpWebResponse API_Response = (HttpWebResponse)API_Request.GetResponse();

            // Step 3 : Set Status code == 200
            if (API_Response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader ResponseData = new StreamReader(API_Response.GetResponseStream());

                string Forecast = ResponseData.ReadToEnd();

                //parse data
                JObject JSON_Forecast = JObject.Parse(Forecast);
                

                //show data
                ViewBag.Forecast = JSON_Forecast["data"]["text"][0];
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}