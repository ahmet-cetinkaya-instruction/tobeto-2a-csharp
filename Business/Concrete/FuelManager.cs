using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class FuelManager : IFuelService
{
    private readonly IFuelDal _fuelDal;
    private readonly FuelBusinessRules _fuelBusinessRules;
    private readonly IMapper _mapper;

    public FuelManager(IFuelDal fuelDal, FuelBusinessRules fuelBusinessRules, IMapper mapper)
    {
        _fuelDal = fuelDal; //new InMemoryFuelDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _fuelBusinessRules = fuelBusinessRules;
        _mapper = mapper;
    }

    public AddFuelResponse Add(AddFuelRequest request)
    {
        // İş Kuralları
        _fuelBusinessRules.CheckIfFuelNameNotExists(request.Name);
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Fuel fuelToAdd = new(request.Name)
        Fuel fuelToAdd = _mapper.Map<Fuel>(request); // Mapping

        _fuelDal.Add(fuelToAdd);

        AddFuelResponse response = _mapper.Map<AddFuelResponse>(fuelToAdd);
        return response;
    }

    public GetFuelListResponse GetList(GetFuelListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Fuel> fuelList = _fuelDal.GetList();

        // fuelList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Fuel -> FuelListItemDto
        // IList<Fuel> -> GetFuelListResponse

        GetFuelListResponse response = _mapper.Map<GetFuelListResponse>(fuelList); // Mapping
        return response;
    }

    public Fuel FindByID(int id)
    {

        IList<Fuel> fuelList = _fuelDal.GetList();
        foreach (Fuel fuel in fuelList)
        {
            if (fuel.Id == id)
            {
                return fuel;
            }
        }

        throw new BusinessException("Fuel is not exists. " + id);
    }
}