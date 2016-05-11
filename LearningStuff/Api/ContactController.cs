using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LearningStuff.Models;
using LearningStuff.Repositories;

namespace LearningStuff.Api
{
    public class ContactController : ApiController
    {
        private readonly ContactRepository _repository;

        public ContactController()
        {
            _repository = new ContactRepository();
        }

        public Contact[] Get()
        {
            return _repository.GetAll().ToArray();
        }

        public HttpResponseMessage Post(Contact contact)
        {
            if (contact == null)
            {
                Trace.TraceWarning("Post failed. Contact missing"); 
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "A contact must be supplied");
            }

            contact.Name = $"{contact.Name} ({100/contact.Id})";

            _repository.SaveContact(contact);

            return Request.CreateResponse(HttpStatusCode.Created, contact);
        }
    }
}