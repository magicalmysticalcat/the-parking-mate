using System.Collections.Generic;
using System.Linq;
using TheParkingMate.DAL.Models;
using TheParkingMate.DAL.Repositories;

namespace TheParkingMate.BusinessLogic
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingBayLogic _parkingBayLogic;

        public ParkingService(IParkingBayLogic parkingBayLogic)
        {
            _parkingBayLogic = parkingBayLogic;
        }
        private ParkingBay GetFreeBay(BaySize vehicleSize, IEnumerable<ParkingBay> parkingBays) =>
            parkingBays.FirstOrDefault(pb => pb.Size == vehicleSize && pb.IsOccupied == false);

        private ParkingBay GetTakenBay(BaySize vehicleSize, IEnumerable<ParkingBay> parkingBays) =>
            parkingBays.FirstOrDefault(pb => pb.Size == vehicleSize && pb.IsOccupied);
        
        public bool TakeBay(BaySize vehicleSize)
        {
            var freeBay = GetFreeBay(vehicleSize, _parkingBayLogic.GetAll(vehicleSize));
            if (freeBay == null)
                return false;
            _parkingBayLogic.Take(freeBay);
            return true;
        }

        public void LeaveBay(BaySize vehicleSize)
        {
            var takenBay = GetTakenBay(vehicleSize, _parkingBayLogic.GetAll(vehicleSize));
            if(takenBay!=null)
                _parkingBayLogic.Vacate(takenBay);
        }

        public int Free(BaySize baySize) => _parkingBayLogic.GetFree(baySize);

        public int Total(BaySize baySize) => _parkingBayLogic.GetTotal(baySize);
    }
}