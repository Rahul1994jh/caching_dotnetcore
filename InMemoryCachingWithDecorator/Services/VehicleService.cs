using InMemoryCachingWithDecorator.Data;
using InMemoryCachingWithDecorator.Entities;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCachingWithDecorator.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
    }

    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;

        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }
    }
}
