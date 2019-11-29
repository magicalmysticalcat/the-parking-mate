using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Autofac;
using TheParkingMate.BusinessLogic;
using TheParkingMate.DAL.DTOs;
using TheParkingMate.DAL.Models;
using TheParkingMate.DAL.Repositories;
using AutoMapper;

namespace TheParkingMate
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        public static void Main(string[] args)
        {
            Configuration.CompositionRoot().Resolve<Application>().Run();
            Configuration.CreateMapper();

        }
    }
}