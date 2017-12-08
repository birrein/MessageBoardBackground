using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageBoardBackend.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        public IEnumerable<Models.Message> Get()
        {
            return new Models.Message[] {
                new Models.Message {
                    Owner = "John",
                    Text  = "hello"
                },
                new Models.Message {
                    Owner = "Manuel",
                    Text  = "wena compare!"
                }
            };
        }
    }
}
