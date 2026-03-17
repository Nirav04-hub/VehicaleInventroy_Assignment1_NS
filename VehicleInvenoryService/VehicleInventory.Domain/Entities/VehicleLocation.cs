using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Exception;

namespace VehicleInventory.Domain.Entities
{
    public class VehicleLocation
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        private VehicleLocation() { }

        public static VehicleLocation Create(string name, string city, string country)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Location name is required.");
            if (string.IsNullOrWhiteSpace(city))
                throw new DomainException("City is required.");
            if (string.IsNullOrWhiteSpace(country))
                throw new DomainException("Country is required.");

            return new VehicleLocation
            {
                Id = Guid.NewGuid(),
                Name = name.Trim(),
                City = city.Trim(),
                Country = country.Trim()
            };
        }
    }
}
