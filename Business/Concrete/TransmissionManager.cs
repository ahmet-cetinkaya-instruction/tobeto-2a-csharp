using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
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
        _transmissionDal = transmissionDal;
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

        Transmission transmissionToAdd = _mapper.Map<Transmission>(request);

        _transmissionDal.Add(transmissionToAdd);

        AddTransmissionResponse response = _mapper.Map<AddTransmissionResponse>(transmissionToAdd);
        return response;
    }

    public IList<Transmission> GetList()
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Transmission> transmissionList = _transmissionDal.GetList();
        return transmissionList;
    }
}
