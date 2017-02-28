using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using BathroomStatus.Stores;
using BathroomStatus.Models;

namespace BathroomStatus.Controllers
{
    [Route("api/[controller]")]
    public class BathroomsController : Controller
    {
        private readonly IBathroomStore m_BathroomStore;

        public BathroomsController(IServiceProvider serviceProvider)
        {
            m_BathroomStore = serviceProvider.GetService<IBathroomStore>();
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
        }
    }
}
