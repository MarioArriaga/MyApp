using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient client;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(IPerson model)
        {
            if(Request.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(@"http://localhost:35796/api/People");
                    httpRequest.Method = "POST";
                    httpRequest.ContentType = "application/json";
                    using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        var json = String.Format("\"Name\":\"{0}\",\"Address\":\"{1}\",\"Telephone\":\"{2}\"", model.Name, model.Address, model.Telephone);
                        streamWriter.Write("{" + json + "}");
                        streamWriter.Flush();
                        streamWriter.Close();

                    }

                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        ViewBag.Message = result;
                    }

                    return View("RecordedInfo", model);
                }
            }
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Database recorder web app.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nearshore Technology.";

            return View();
        }
    }
}