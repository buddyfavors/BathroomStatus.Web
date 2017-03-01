using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using BathroomStatus.Stores;
using BathroomStatus.Models;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using BathroomStatus.Hubs;

namespace BathroomStatus.Controllers
{
    [Route("api/[controller]")]
    public class BathroomsController : Controller
    {
        private readonly IConnectionManager m_ConnectionManager;
        private readonly IBathroomStore m_BathroomStore;
        private readonly IHubContext m_Hub;

        public BathroomsController(IServiceProvider serviceProvider)
        {
            m_ConnectionManager = serviceProvider.GetService<IConnectionManager>();
            m_BathroomStore = serviceProvider.GetService<IBathroomStore>();

            m_Hub = m_ConnectionManager.GetHubContext<BathroomsHub>();
        }

        [HttpGet]
        public IEnumerable<Bathroom> Get()
        {
            return m_BathroomStore.GetAll();
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Bathroom updatedBathroom)
        {
            var bathroom = m_BathroomStore.GetById(id);
            bathroom.IsOpened = updatedBathroom.IsOpened;
            m_BathroomStore.Update(bathroom);

            m_Hub.Clients.All.Update(bathroom);
        }
    }
}
