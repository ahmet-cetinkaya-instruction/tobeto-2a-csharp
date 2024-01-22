using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TransmissionManager : ITransmissionService
{
    private readonly ITransmissionDal _transmissionDal;
    private readonly TransmissionBusinessRules _transmissionBusinessRules;
    private readonly IMapper _mapper;

    public TransmissionManager(ITransmissionDal transmissionDal, TransmissionBusinessRules transmissionBusinessRules, IMapper mapper)
    {
        _transmissionDal = transmissionDal; //new InMemoryTransmissionDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _transmissionBusinessRules = transmissionBusinessRules;
        _mapper = mapper;
    }

    public AddTransmissionResponse Add(AddTransmissionRequest request)
    {
        // İş Kuralları
        _transmissionBusinessRules.CheckIfTransmissionNameNotExists(request.Name);
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Transmission transmissionToAdd = new(request.Name)
        Transmission transmissionToAdd = _mapper.Map<Transmission>(request); // Mapping

        _transmissionDal.Add(transmissionToAdd);

        AddTransmissionResponse response = _mapper.Map<AddTransmissionResponse>(transmissionToAdd);
        return response;
    }

    public GetTransmissionListResponse GetList(GetTransmissionListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Transmission> transmissionList = _transmissionDal.GetList();

        // transmissionList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Transmission -> TransmissionListItemDto
        // IList<Transmission> -> GetTransmissionListResponse

        GetTransmissionListResponse response = _mapper.Map<GetTransmissionListResponse>(transmissionList); // Mapping
        return response;
    }

    public Transmission FindByID(int id)
    {

        IList<Transmission> transmissionList = _transmissionDal.GetList();
        foreach (Transmission transmission in transmissionList)
        {
            if (transmission.Id == id)
            {
                return transmission;
            }
        }

        throw new BusinessException("Transmission is not exists. " + id);
    }
}