using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain.Valueobject
{
    public sealed class VehicleCode
    {
        public string Value { get; }

        private VehicleCode(string value)
        {
            Value = value;
        }

        public static VehicleCode Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception.DomainException("VehicleCode is required.");
            if (value.Length > 50)
                throw new Exception.DomainException("VehicleCode max length is 50.");

            return new VehicleCode(value.Trim());
        }

      
        public override bool Equals(object? obj)
        {

            return obj is VehicleCode other && Value == other.Value;
        }

        public override string ToString()
        {
          return  Value;
        }
    }
}
