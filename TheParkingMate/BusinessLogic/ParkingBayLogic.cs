using System.Collections.Generic;
using System.Linq;
using TheParkingMate.DAL.Models;
using TheParkingMate.DAL.Repositories;

namespace TheParkingMate.BusinessLogic
{
    public class ParkingBayLogic : IParkingBayLogic
    {
        private readonly IParkingBayRepository _parkingBayRepository;
        public ParkingBayLogic(IParkingBayRepository parkingBayRepository)
        {
            _parkingBayRepository = parkingBayRepository;
        }

        public void Take(ParkingBay parkingBay)
        {
            parkingBay.IsOccupied = true;
            _parkingBayRepository.Update(parkingBay);
        }

        public void Vacate(ParkingBay parkingBay)
        {
            parkingBay.IsOccupied = false;
            _parkingBayRepository.Update(parkingBay);
        }

        public int GetTotal(BaySize baySize) => _parkingBayRepository.ReadAll().Count(pb=>pb.Size==baySize);

        public int GetFree(BaySize baySize) =>
            _parkingBayRepository.ReadAll().Count(pb => pb.IsOccupied == false && pb.Size == baySize);

        public IEnumerable<ParkingBay> GetAll(BaySize baySize) => _parkingBayRepository.ReadAll();
    }
}