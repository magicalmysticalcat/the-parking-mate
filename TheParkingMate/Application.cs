using System;
using TheParkingMate.BusinessLogic;
using TheParkingMate.DAL.Models;

namespace TheParkingMate
{
    public class Application
    {
        private IParkingService _parkingService;

        public Application(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        public void Run()
        {
            string command=string.Empty;
            while (command!="exit")
            {
                PrintMenu();
                command = Console.ReadLine();
                ProcessInput(command);
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("Handicapped:{0}/{1}", _parkingService.Free(BaySize.Handicapped),
                _parkingService.Total(BaySize.Handicapped));
            Console.WriteLine("Compact:{0}/{1}", _parkingService.Free(BaySize.Compact),
                _parkingService.Total(BaySize.Compact));
            Console.WriteLine("Regular:{0}/{1}", _parkingService.Free(BaySize.Regular),
                _parkingService.Total(BaySize.Regular));
            Console.WriteLine("To take type T, to vacate type (V) and the kind of bay:(H)andicapped,(C)ompact, (R)egular and press enter");
        }

        private void ProcessInput(string command)
        {
            if (command == "TH")
                _parkingService.TakeBay(BaySize.Handicapped);
            else if(command=="TC")
                _parkingService.TakeBay(BaySize.Compact);
            else if(command=="TR")
                _parkingService.TakeBay(BaySize.Regular);
            if (command == "VH")
                _parkingService.LeaveBay(BaySize.Handicapped);
            else if(command=="VC")
                _parkingService.LeaveBay(BaySize.Compact);
            else if(command=="VR")
                _parkingService.LeaveBay(BaySize.Regular);
        }
    }
}