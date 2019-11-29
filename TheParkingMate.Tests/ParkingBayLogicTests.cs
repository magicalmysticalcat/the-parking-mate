using System;
using System.Configuration;
using Autofac;
using Moq;
using NUnit.Framework;
using TheParkingMate.BusinessLogic;
using TheParkingMate.DAL.Models;
using TheParkingMate.DAL.Repositories;

namespace TheParkingMate.Tests
{
    [TestFixture]
    public class ParkingBayLogicTests
    {
        [Test]
        public void Take()
        {
            var mockDataAccess = new Mock<IParkingBayRepository>();
            var parkingBay = new ParkingBay(){IsOccupied = false};

            var parkingBayLogic = new ParkingBayLogic(mockDataAccess.Object);
            parkingBayLogic.Take(parkingBay);
            
            Assert.True(parkingBay.IsOccupied);
        }
        
        [Test]
        public void Vacate()
        {
            var mockDataAccess = new Mock<IParkingBayRepository>();
            var parkingBay = new ParkingBay(){IsOccupied = true};

            var parkingBayLogic = new ParkingBayLogic(mockDataAccess.Object);
            parkingBayLogic.Vacate(parkingBay);
            
            Assert.False(parkingBay.IsOccupied);
        }
        
    }
}