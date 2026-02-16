using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Entities;

namespace VehicleInventory.Application.Interfaces
{
    public interface IVehicleRepoNS
    {
        Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<List<Vehicle>> GetAllAsync(CancellationToken ct = default);
        Task AddAsync(Vehicle vehicle, CancellationToken ct = default);
        Task UpdateAsync(Vehicle vehicle, CancellationToken ct = default);
        Task DeleteAsync(Vehicle vehicle, CancellationToken ct = default);
    }
}
