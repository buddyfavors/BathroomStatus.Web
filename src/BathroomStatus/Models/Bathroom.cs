using System;

namespace BathroomStatus.Models
{
    public class Bathroom
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public bool IsOpened { get; set; }
    }
}
