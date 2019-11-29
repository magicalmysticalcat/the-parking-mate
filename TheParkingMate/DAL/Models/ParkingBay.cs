using System;
using System.Diagnostics.CodeAnalysis;

namespace TheParkingMate.DAL.Models
{
    [ExcludeFromCodeCoverage]
    public class ParkingBay
    {
        public Guid Id { get; set; }
        public BaySize Size { get; set; }
        public bool IsOccupied { get; set; }
        public Guid ParkingLotId { get; set; }

    }
}