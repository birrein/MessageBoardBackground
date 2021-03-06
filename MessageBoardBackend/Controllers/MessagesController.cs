﻿using System;
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
        readonly ApiContext context;

        public MessagesController(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Models.Message> Get()
        {
            return context.Messages;
        }

        [HttpGet("{name}")]
        public IEnumerable<Models.Message> Get(string name)
        {
            return context.Messages.Where(message => message.Owner == name);
        }

        [HttpPost]
        public Models.Message Post([FromBody] Models.Message message)
        {
            var dbMessage = context.Messages.Add(message).Entity;
            context.SaveChanges();
            return dbMessage;
        }
    }
}
