using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
           var result = _contactService.GetAll();

           if (result.Success)
           {
               return Ok(result);
           }

           return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Contact contact)
        {
            var result = _contactService.Add(contact);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
