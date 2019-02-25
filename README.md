# SolsticeCC
Api Restful .NET CRUD ops
Api documentation 

method 

[HttpGet]
[Route("~/api/contacts/{PersonNameOrId}")] 
Retrieves a contact record by Person name or id, with  format  Json Serialized String Array Type, from a Azure cloud virtual sql database server 
the model is accessed by entity methods in the "model" folder

if the contact doesnt exist it retrives a 0 filled object

[HttpGet]

[Route("~/api/contacts/{CityOrState}/searchcity")]
Retrieves a contact record or many of them, searching by city or State, with  format  Json Serialized String Array Type, from a Azure cloud virtual sql database server 
the model is accessed by entity methods in the "model" folder

[HttpGet]
[Route("~/api/contacts/{PersonEmailOrPhoneNumber}/searchemail")]
Retrieves a contact record or many of them, searching by phone numers  or email, with  format  Json Serialized String Array Type, from a Azure cloud virtual sql database server 
the model is accessed by entity methods in the "model" folder       


[HttpPost]
[Route("~/api/contacts/new")]
 Creates a new contact in the database
 datatype object ContactRecords:
 
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
    

    
    
    
[HttpPut]
[Route("~/api/contacts/modify")]
Modifies existing contact record by id



Delete existing contact record by id
[HttpDelete]
[Route("~/ api/contacts/{id}/delete")]
    
Put, Post and delete methods returns a boolean true if success
    
    
    
