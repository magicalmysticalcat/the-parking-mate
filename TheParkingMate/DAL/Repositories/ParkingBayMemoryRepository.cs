using System;
using System.Collections.Generic;
using System.Linq;
using TheParkingMate.DAL.Models;

namespace TheParkingMate.DAL.Repositories
{
    public class ParkingBayMemoryRepository:IParkingBayRepository
    {
        private readonly DbContext _dbContext;
        public ParkingBayMemoryRepository()
        {
            _dbContext = DbContext.Instance();
        }
        public void Create(ParkingBay entity)
        {
            var parkingLot = _dbContext.ParkingLots.FirstOrDefault(pl => pl.Id == entity.ParkingLotId);
            parkingLot?.ParkingBays.ToList().Add(entity);
        }
        
        public ParkingBay Read(Guid id)
        {
            return _dbContext.ParkingBays.FirstOrDefault(pb => pb.ParkingLotId == id);
        }

        public IEnumerable<ParkingBay> ReadAll()
        {
            return _dbContext.ParkingBays;
        }

        public void Update(ParkingBay entity)
        {
            
        }

        public void Delete(Guid id)
        {
            _dbContext.ParkingBays.RemoveAll(pb => pb.Id == id);
        }
    }
}