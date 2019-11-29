using System.Collections;
using System.Collections.Generic;
using TheParkingMate.DAL.Models;

namespace TheParkingMate.BusinessLogic
{
    public interface IParkingBayLogic
    {
        void Take(ParkingBay parkingBay);
        void Vacate(ParkingBay parkingBay);

        int GetTotal(BaySize baySize);
        int GetFree(BaySize baySize);

        IEnumerable<ParkingBay> GetAll(BaySize baySize);
    }
}