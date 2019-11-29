using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheParkingMate.DAL.Models
{
    [ExcludeFromCodeCoverage]
    public class ParkingLot
    {
        public IEnumerable<ParkingBay> ParkingBays { get; set; }
        public Guid Id { get; set; }
    }
}