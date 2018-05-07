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
                        //httpRequest.ContentLength = model.ToString().Length;

                        //var streamWriter = new StreamWriter();
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
                    //try
                    //{
                    //    using (client = new HttpClient())
                    //    {
                    //        client.BaseAddress = new Uri("http://localhost:35796/");
                    //        client.DefaultRequestHeaders.Accept.Clear();
                    //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //        var response = await client.PostAsJsonAsync("api/People", model);

                    //        if (response.IsSuccessStatusCode)
                    //        {
                    //            //HttpMessageTextBox.Text = await response.Content.ReadAsStringAsync();
                    //            ViewBag.Message = await response.Content.ReadAsStringAsync();
                    //            return View();
                    //        }

                    //    }
                    //}
                    //catch (Exception ex)
                    //{

                    //}
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