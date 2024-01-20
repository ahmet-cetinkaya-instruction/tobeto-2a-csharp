using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Business.Requests.Brand;
using Business.Requests.Fuel;
using Business.Responses.Brand;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace WebAPI;

public static class FuelServiceRegistration
{
    public static readonly IFuelDal FuelDal = new InMemoryFuelDal();

    public static readonly FuelBusinessRules FuelBusinessRules = new FuelBusinessRules(FuelDal);

    public static IMapper Mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<AddFuelRequest, Fuel>();
        cfg.CreateMap<Fuel, AddFuelResponse>();
    }).CreateMapper();

    public static readonly IFuelService FuelService = new FuelManager(
        FuelDal,
        FuelBusinessRules,
        Mapper
    );

}
