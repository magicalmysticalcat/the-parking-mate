using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace TheParkingMate.DAL.Models
{
    [ExcludeFromCodeCoverage]
    public class DbContext
    {
        public List<ParkingBay> ParkingBays { get; private set; }
        public List<ParkingLot> ParkingLots { get; private set; }

        private static DbContext _instance;
        public static DbContext Instance() => _instance ?? (_instance = new DbContext());

        private DbContext() => Initialize();

        private void Initialize()
        {
            ParkingLots = new List<ParkingLot> {new ParkingLot() {Id = Guid.NewGuid()}};
            ParkingBays = new List<ParkingBay>();

            foreach (var parkingLot in ParkingLots)
            {
                parkingLot.ParkingBays = new List<ParkingBay>();
                for (var i = 0; i < 5; i++)
                {
                    var compact = new ParkingBay()
                    {
                        Id = Guid.NewGuid(),
                        IsOccupied = false,
                        Size = BaySize.Compact,
                        ParkingLotId = parkingLot.Id
                    };
                    var handicapped = new ParkingBay()
                    {
                        Id = Guid.NewGuid(), 
                        IsOccupied = false, 
                        Size = BaySize.Handicapped,
                        ParkingLotId = parkingLot.Id
                    };
                    var regular = new ParkingBay()
                    {
                        Id = Guid.NewGuid(), 
                        IsOccupied = false, 
                        Size = BaySize.Regular, 
                        ParkingLotId = parkingLot.Id
                    };
                    ParkingBays.Add(compact);
                    ParkingBays.Add(handicapped);
                    ParkingBays.Add(regular);
                    parkingLot.ParkingBays.ToList().AddRange(new []{compact,handicapped,regular});
                }
            }

        }
        
        
    }
}