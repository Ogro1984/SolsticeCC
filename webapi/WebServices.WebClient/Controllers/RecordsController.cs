using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft;
using System.Net.Http.Formatting;
using WebServices.WebClient.Data;


namespace WebServices.WebClient.Controllers
{
    public class RecordsController : Controller
    {
        ContactRecords CR = new ContactRecords();
        // Get  Api method
        //Retrieves Contact Records 
        [HttpGet]
        public ActionResult Index()
        {
            string PersonNameOrId = (Request.Form["search"]);            
            if (PersonNameOrId == null)
            {
                PersonNameOrId = "1";}
            

            HttpClient httpc = new HttpClient();
            httpc.BaseAddress = new Uri("http://localhost:57265");
            var request = httpc.GetAsync("api/contacts/" + PersonNameOrId).Result;
                if (request.IsSuccessStatusCode)
                {
                    var resultString = request.Content.ReadAsStringAsync().Result;
                               
                       
                              
                var list = JsonConvert.DeserializeObject<IEnumerable<string>>(resultString);
                
                return View(list);
                }
             




            return View();


        }









        // Post api method
        [HttpGet]

        public ActionResult New()
        {
            return View();

        }

        [HttpPost]
        public ActionResult New(ContactRecords record)
        {
            HttpClient httpc = new HttpClient();
            httpc.BaseAddress = new Uri("http://localhost:57301");
            var request = httpc.PostAsync("api/Record", record, new JsonMediaTypeFormatter()).Result;


            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var okvalue = JsonConvert.DeserializeObject<bool>(resultString);
                if (okvalue) {

                    return RedirectToAction("Index");
                }


                return View(record);
            }

            return View(record);
        }

        // Put api method
        [HttpGet]

        public ActionResult Update(int id)
        {

            HttpClient httpc = new HttpClient();
            httpc.BaseAddress = new Uri("http://localhost:57301");
            var request = httpc.GetAsync("api/Record?id=" + id).Result;


            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                resultString = resultString.Insert(0, "[");
                resultString = resultString.Insert(resultString.Length, "]");
                var info = JsonConvert.DeserializeObject<List<ContactRecords>>(resultString);

               

                return View(info);
            }


            return View();

        }

        [HttpPost]
        public ActionResult Update(ContactRecords record)
        {
            HttpClient httpc = new HttpClient();
            httpc.BaseAddress = new Uri("http://localhost:57301");
            var request = httpc.PutAsync("api/Record", record, new JsonMediaTypeFormatter()).Result;




            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var okvalue = JsonConvert.DeserializeObject<bool>(resultString);
                if (okvalue)
                {

                    return RedirectToAction("Index");
                }


                return View(record);
            }

            return View(record);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            HttpClient httpc = new HttpClient();
            httpc.BaseAddress = new Uri("http://localhost:57301");
            var request = httpc.DeleteAsync("api/Record?id=" + id).Result;


            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var okvalue = JsonConvert.DeserializeObject<bool>(resultString);
                if (okvalue)
                {

                    return RedirectToAction("Index");
                }



            }

            return View();


        }
                                                           

        [HttpGet]

        public ActionResult Details(int id)
        {

            HttpClient httpc = new HttpClient();
            httpc.BaseAddress = new Uri("http://localhost:57301");
            var request = httpc.GetAsync("api/Record?id=" + id).Result;


            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<List<ContactRecords>>(resultString);
                return View(info);
            }
                                   
            return View();
                                 
        }


    }



}
