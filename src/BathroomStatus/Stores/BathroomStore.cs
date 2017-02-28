using System;
using System.Collections.Generic;
using BathroomStatus.Models;
using System.Linq;

namespace BathroomStatus.Stores
{
    public class BathroomStore : IBathroomStore
    {
        private static readonly List<Bathroom> m_DB = new List<Bathroom>()
        {
            new Bathroom
            {
                Id = 1,
                Name = "Back Office"
            }
        };

        IEnumerable<Bathroom> IBathroomStore.GetAll()
        {
            return m_DB;
        }

        Bathroom IBathroomStore.GetById(int id)
        {
            return m_DB.FirstOrDefault(x => x.Id == id);
        }

        void IBathroomStore.Update(Bathroom bathroom)
        {
            var index = m_DB.IndexOf(bathroom);
            m_DB[index] = bathroom;
        }
    }
}
