using BathroomStatus.Models;
using System;
using System.Collections.Generic;

namespace BathroomStatus.Stores
{
    public interface IBathroomStore
    {
        IEnumerable<Bathroom> GetAll();
        Bathroom GetById(int id);
        void Update(Bathroom bathroom);
    }
}
