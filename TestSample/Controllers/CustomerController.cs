using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer;

namespace TestSample.Controllers
{
    public class CustomerController : ApiController
    {

            List<Customer> customers = new List<Customer> {
            new Customer { CID= 1,CustomerName="AirTel",Active="Y"},
            new Customer { CID= 2,CustomerName="BT",Active="Y"},
            new Customer { CID= 3,CustomerName="Libera",Active="Y"},
            new Customer { CID= 4,CustomerName="BSNL",Active="N"},
            new Customer { CID= 5,CustomerName="VodaPhone",Active="N"},
        };
            List<ContactDetails> contacts = new List<ContactDetails> {
            new ContactDetails{ID=1,CID=1,TelNumber=07823795749},
            new ContactDetails{ID=2,CID=2,TelNumber=07823795111},
            new ContactDetails{ID=3,CID=1,TelNumber=07823795222},
            new ContactDetails{ID=4,CID=3,TelNumber=07823795333},
            new ContactDetails{ID=5,CID=1,TelNumber=07823795444},
            new ContactDetails{ID=6,CID=4,TelNumber=07823795555},
            new ContactDetails{ID=7,CID=5,TelNumber=07823795123},
        };

            [Route("api/Customer/GetCustomerDetails")]
            [HttpGet]
            public HttpResponseMessage GetCustomerDetails()
            {
                List<Customer> customerDetails = customers;
                if (customerDetails != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customerDetails.ToList());
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }

            [Route("api/Customer/GetActiveCustomers")]
            [HttpGet]
            public HttpResponseMessage GetActiveCustomers()
            {
                List<Customer> activeCustomers = customers.Where(a => a.Active == "Y").ToList();
                try
                {
                    if (activeCustomers != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, activeCustomers.ToList());
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }

            [Route("api/Customer/GetContactDetails/{id:int?}")]
            [HttpGet]
            public HttpResponseMessage GetContactDetails(int? id)
            {
                List<ContactDetails> contactDetails = contacts.Where(b => b.CID == id).ToList();
                try
                {
                    if (contactDetails != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, contactDetails.ToList());
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    
}
