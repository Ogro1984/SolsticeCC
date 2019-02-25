using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Data
{
    public class ContactRecordstesting
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string CompanyName { get; set; }
        public byte[] ProfileImage { get; set; }
        public string Email { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PhoneNumberHome { get; set; }
        public string PhoneNumberWork { get; set; }
        public string Addressnumber { get; set; }


    }
}