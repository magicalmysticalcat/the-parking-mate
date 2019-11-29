using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TheParkingMate.DAL.Models;

namespace TheParkingMate.DAL.Repositories
{
    public class ParkingLotMemoryRepository:IParkingLotRepository
    {
        private readonly DbContext _dbContext;
        public ParkingLotMemoryRepository()
        {
            _dbContext = DbContext.Instance();
        }
        
        public void Create(ParkingLot entity)
        {
            _dbContext.ParkingLots.Add(entity);
            _dbContext.ParkingBays.AddRange(entity.ParkingBays);
        }

        public ParkingLot Read(Guid id)
        {
            return _dbContext.ParkingLots.FirstOrDefault(pl => pl.Id == id);
        }

        public IEnumerable<ParkingLot> ReadAll()
        {
            return _dbContext.ParkingLots;
        }

        public void Update(ParkingLot entity)
        {
            var oldEntity = Read(entity.Id);
            oldEntity.ParkingBays = entity.ParkingBays;
        }

        public void Delete(Guid id)
        {
            _dbContext.ParkingBays.RemoveAll(pb=>pb.ParkingLotId==id);
            _dbContext.ParkingLots.Remove(Read(id));
        }
    }
}