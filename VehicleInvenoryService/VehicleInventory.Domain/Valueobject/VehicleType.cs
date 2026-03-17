using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain.Valueobject
{
    public sealed class VehicleType
    {
        public string Value { get; }

        private VehicleType(string value)
        {
            Value = value;
        }

        public static VehicleType Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception.DomainException("VehicleType is required.");
            if (value.Length > 50)
                throw new Exception.DomainException("VehicleType max length is 50.");

            return new VehicleType(value.Trim());
        }

        public override bool Equals(object? obj)
        { 
         return obj is VehicleType other && Value == other.Value;
        }

        public override string ToString(){ return Value;  }
    }

}
