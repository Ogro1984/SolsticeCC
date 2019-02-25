using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using Newtonsoft.Json;
using WebApi.Data;

namespace WebApi.Controllers
{
    //General Api Controller  
    public class ContactController : ApiController

    {

        solsticeccEntities DB = new solsticeccEntities();


        /// <summary>
        /// Retrieve a contact record by Person name or id
        /// </summary>
        /// <param name="PersonNameOrId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/contacts/{PersonNameOrId}")] 
        public   IEnumerable<string> GetContactbyPersonName(string PersonNameOrId)
        {


            var    intern = DB.ContactRecords.ToList().Where(x => x.PersonName == PersonNameOrId || x.PersonId == Int32.Parse(PersonNameOrId));

         


                 if (intern == null || JsonConvert.SerializeObject(intern).ToString() == "[]" )
                 {
                     byte[] bytecero = { 0, 0, 0, 0 };
                     ContactRecords interno = new ContactRecords();
                     interno.PersonId = 0;
                     interno.PersonName = "no match";
                     interno.PhoneNumberHome = "no match";
                     interno.PhoneNumberWork = "no match";
                     interno.ProfileImage= bytecero;
                     interno.CompanyName = "no match";
                     interno.Addressnumber = "no match";
                     interno.BirthDate = new DateTime(1, 1, 1);
                     interno.Email = "no match";
            
                 yield  return JsonConvert.SerializeObject(interno).ToString();
                 
                 }
            
                 else {
                 yield return JsonConvert.SerializeObject(intern).ToString(); 
                     }

            
            


        }

        /// <summary>
        /// Returns All Contact matching phone number or email
        /// </summary>
        /// <param name="PersonEmailOrPhoneNumber"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("~/api/contacts/{PersonEmailOrPhoneNumber}/searchemail")]
       
        public IEnumerable<string> GetContactbyEmail(string PersonEmailOrPhoneNumber)
        {
            
                                    
            var intern = DB.ContactRecords.ToList().Where(x => x.Email == PersonEmailOrPhoneNumber || x.PhoneNumberHome == PersonEmailOrPhoneNumber || x.PhoneNumberWork == PersonEmailOrPhoneNumber);


            if (intern == null || JsonConvert.SerializeObject(intern).ToString() == "[]")
            {
                IEnumerable<string> nomatch = new List<string> { "no match", "no match", "no match", "no match", "no match", "no match", "no match", "no match", "no match", "no match" };
                yield return JsonConvert.SerializeObject(nomatch).ToString();
            } 
            else { yield return JsonConvert.SerializeObject(intern).ToString(); }

        
        }


        [HttpGet]

        [Route("~/api/contacts/{CityOrState}/searchcity")]

        public IEnumerable<string> GetContactStateOrCity(string StateOrCity)
        {


            var intern = DB.ContactRecords.ToList().Where(x => x.Addressnumber.Contains(StateOrCity));


            if (intern == null || JsonConvert.SerializeObject(intern).ToString() == "[]")
            {
                IEnumerable<string> nomatch = new List<string> { "no match", "no match", "no match", "no match", "no match", "no match", "no match", "no match", "no match", "no match" };
                yield return JsonConvert.SerializeObject(nomatch).ToString();
            }
            else { yield return JsonConvert.SerializeObject(intern).ToString(); }


        }




        // POST: api/Api1
        /// <summary>
        /// Creates a new contact in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/contacts/new")]
        public bool Post(ContactRecords NewContact)
        {
            
            
            DB.ContactRecords.Add(NewContact);

            return DB.SaveChanges()>0;

        }

        [HttpPut]
        [Route("~/api/contacts/modify")]
        // modifies a profile by id
        public bool Put(int id, ContactRecords NewContact)
        {
            var actualizerecord = DB.ContactRecords.FirstOrDefault(x => x.PersonId == NewContact.PersonId);
            actualizerecord.PersonName = NewContact.PersonName;
            actualizerecord.CompanyName = NewContact.CompanyName;
            actualizerecord.ProfileImage = NewContact.ProfileImage;
            actualizerecord.Email = NewContact.Email;
            actualizerecord.BirthDate = NewContact.BirthDate;
            actualizerecord.PhoneNumberHome = NewContact.PhoneNumberHome;
            actualizerecord.PhoneNumberWork = NewContact.PhoneNumberWork;
            actualizerecord.Addressnumber = NewContact.Addressnumber;
            return DB.SaveChanges() > 0;

        }

        // Deletes one profile 
        [HttpDelete]
        [Route("~/ api/contacts/{id}/delete")]
        public bool Delete(int id)
        {
            var deleterecord = DB.ContactRecords.FirstOrDefault(x => x.PersonId == id);
            DB.ContactRecords.Remove(deleterecord);

            return DB.SaveChanges() > 0;


        }

    }
}
