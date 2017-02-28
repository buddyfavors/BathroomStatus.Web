using System;

namespace BathroomStatus.Models
{
    public class Bathroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpened { get; set; }
    }
}
