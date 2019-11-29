using System;
using System.Diagnostics.CodeAnalysis;
using TheParkingMate.DAL.Models;

namespace TheParkingMate.DAL.DTOs
{
    [ExcludeFromCodeCoverage]
    public class ParkingBayDTO
    {
        public Guid Id { get; set; }
        public BaySize Size { get; set; }
        public bool IsOccupied { get; set; }
        public Guid ParkingLotId { get; set; }

    }
}