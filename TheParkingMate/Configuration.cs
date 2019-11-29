using Autofac;
using AutoMapper;
using TheParkingMate.BusinessLogic;
using TheParkingMate.DAL.DTOs;
using TheParkingMate.DAL.Models;
using TheParkingMate.DAL.Repositories;

namespace TheParkingMate
{
    public static class Configuration
    {
        public static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<ParkingService>().As<IParkingService>();
            builder.RegisterType<ParkingBayLogic>().As<IParkingBayLogic>();
            builder.RegisterType<ParkingBayMemoryRepository>().As<IParkingBayRepository>();
            builder.RegisterType<ParkingLotMemoryRepository>().As<IParkingLotRepository>();
            return builder.Build();
        }

        public static IMapper Mapper { get; private set; }
        public static void CreateMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ParkingBay, ParkingBayDTO>();
                cfg.CreateMap<ParkingLot, ParkingLotDTO>();
            });
            Mapper = config.CreateMapper();
        }
    }
}