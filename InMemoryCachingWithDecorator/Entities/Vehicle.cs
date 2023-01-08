using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryCachingWithDecorator.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }
        public string? Vin { get; set; }
        public string? Fuel { get; set; }
    }
}
