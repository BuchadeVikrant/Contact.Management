using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Contacts.Management.Models;
using Contacts.Management.Models.ErrorResponses;
using Contacts.Management.Models.Responses;
using Contacts.Management.Models.Enums;
using Contacts.Management.Interfaces;

namespace Contacts.Management.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContact _contactRepository;
        public ContactsController(IContact contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public HttpResponseMessage Get()
        {
            try
            {
                BaseResponse<List<Contact>> response = new BaseResponse<List<Contact>>();
                response.Data = _contactRepository.GetContacts();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                BaseResponse<Error> response = new BaseResponse<Error>();
                response.Errors = new Error(ErrorCodes.TechnicalError.ToString(), ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
            
        }

        
        public HttpResponseMessage Post([FromBody]Contact contact)
        {
            try
            {
                BaseResponse<bool> response = new BaseResponse<bool>();
                response.Data = _contactRepository.AddContact(contact);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {

                BaseResponse<Error> response = new BaseResponse<Error>();
                response.Errors = new Error(ErrorCodes.TechnicalError.ToString(), ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
        public HttpResponseMessage Put([FromBody] Contact contact)
        {
            try
            {
                bool isContactUpdated =  _contactRepository.UpdateContact(contact);
                if (isContactUpdated)
                {
                    BaseResponse<bool> response = new BaseResponse<bool>();
                    response.Data = isContactUpdated;
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    BaseResponse<Error> response = new BaseResponse<Error>();
                    response.Errors = new Error(ErrorCodes.DataNotFoundError.ToString(), "Contact not found");
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
            }
            catch (Exception ex)
            {

                BaseResponse<Error> response = new BaseResponse<Error>();
                response.Errors = new Error(ErrorCodes.TechnicalError.ToString(), ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                bool isContactUpdated = _contactRepository.ChangeContactStatus(id);
                if (isContactUpdated)
                {
                    BaseResponse<bool> response = new BaseResponse<bool>();
                    response.Data = isContactUpdated;
                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                else
                {
                    BaseResponse<Error> response = new BaseResponse<Error>();
                    response.Errors = new Error(ErrorCodes.DataNotFoundError.ToString(), "Contact not found");
                    return Request.CreateResponse(HttpStatusCode.NotFound, response);
                }
            }
            catch (Exception ex)
            {

                BaseResponse<Error> response = new BaseResponse<Error>();
                response.Errors = new Error(ErrorCodes.TechnicalError.ToString(), ex.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
