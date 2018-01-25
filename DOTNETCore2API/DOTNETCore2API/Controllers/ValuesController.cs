using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DOTNETCore2API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private readonly IHubContext<ChatHub> _context;

        [HttpGet("Send/{message}")]
        public IActionResult Send(string message)
        {
            //for everyone
            this._context.Clients.All.InvokeAsync("Send", message);
            //for a single group
            this._context.Clients.Group("groupName").InvokeAsync("Send", message);
            //for a single client
            this._context.Clients.Client("id").InvokeAsync("Send", message);

            return this.Ok();
        }
    }

}
