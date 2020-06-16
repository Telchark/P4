﻿using MapDemo.DataAccess;
using MapDemo.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MapDemo.UI.Data
{
    public class CastleDataService : ICastleDataService
    {
        MapDemoDbContext _context;

        public CastleDataService(MapDemoDbContext context)
        {
            _context = context;
        }

        public void Add(Castle castle)
        {
            _context.Castles.Add(castle);
        }

        public async Task<Castle> GetByIdAsync(int castleId)
        {
            return await _context.Castles.SingleAsync(c => c.CastleId == castleId);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(Castle model)
        {
            _context.Castles.Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
