using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiplexApis.Data;

namespace MultiplexApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultiplexController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MultiplexController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<MultiplexController>
        [HttpGet]
        public List<Multiplex> Get()
        {
            var data = _context.Multiplex.Include(x => x.Screens).ToList();
            return data;
        }

        // GET api/<MultiplexController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MultiplexController>
        [HttpPost]
        public IActionResult Post([FromBody] MultiplexRegisterViewModel obj)
        {
            Multiplex multiplex = new Multiplex()
            {
                Address = obj.Address,
                Email = obj.Email,
                Mobile = obj.Mobile,
                Name = obj.Name,
                Password = obj.Password,
            };


            foreach (var ScreenName in obj.Screens)
            {

                multiplex.Screens.Add(new Screens()
                {
                    Name = ScreenName
                });
            }

            _context.Multiplex.Add(multiplex);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<MultiplexController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MultiplexController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
