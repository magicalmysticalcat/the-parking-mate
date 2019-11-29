using System.Collections;
using System.Collections.Generic;
using TheParkingMate.DAL.Models;

namespace TheParkingMate.BusinessLogic
{
    public interface IParkingService
    {
        bool TakeBay(BaySize vehicleSize);
        void LeaveBay(BaySize vehicleSize);

        int Free(BaySize baySize);
        int Total(BaySize baySize);
    }
}