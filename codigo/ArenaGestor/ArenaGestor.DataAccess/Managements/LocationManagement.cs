using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.DataAccess.Managements
{
    public class LocationManagement : ILocationManagement
    {
        private readonly DbSet<Location> locations;
        private readonly DbContext context;

        public LocationManagement(DbContext context)
        {
            locations = context.Set<Location>();
            this.context = context;
        }
        public Location GetLocationById(int id)
        {
            var locationNoTracking = locations.AsNoTracking();
            var location = locationNoTracking.Include(x => x.Country).FirstOrDefault(x => x.LocationId == id);
            return location;
            
        }
    }
}
