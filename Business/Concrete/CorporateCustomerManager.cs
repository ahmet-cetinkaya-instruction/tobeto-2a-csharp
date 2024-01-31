using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CorporateCustomerManager : ICorporateCustomerService
{
    private readonly ICorporateCustomerDal _ındividualcustomerDal;
    private readonly CorporateCustomerBusinessRules _ındividualcustomerBusinessRules;
    private readonly IMapper _mapper;

    public CorporateCustomerManager(ICorporateCustomerDal ındividualcustomerDal, CorporateCustomerBusinessRules ındividualcustomerBusinessRules, IMapper mapper)
    {
        _ındividualcustomerDal = ındividualcustomerDal; 
        _ındividualcustomerBusinessRules = ındividualcustomerBusinessRules;
        _mapper = mapper;
    }

    public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request)
    {
        _ındividualcustomerBusinessRules.CheckIfCorporateCustomerNameNotExists(request.CompanyName);

        CorporateCustomer ındividualcustomerToAdd = _mapper.Map<CorporateCustomer>(request); // Mapping

        _ındividualcustomerDal.Add(ındividualcustomerToAdd);

        AddCorporateCustomerResponse response = _mapper.Map<AddCorporateCustomerResponse>(ındividualcustomerToAdd);
        return response;
    }

    public GetCorporateCustomerListResponse GetList(GetCorporateCustomerListRequest request)
    {

        IList<CorporateCustomer> ındividualcustomerList = _ındividualcustomerDal.GetList();

        GetCorporateCustomerListResponse response = _mapper.Map<GetCorporateCustomerListResponse>(ındividualcustomerList); // Mapping
        return response;
    }

    public CorporateCustomer FindByID(int id)
    {

        IList<CorporateCustomer> ındividualcustomerList = _ındividualcustomerDal.GetList();
        foreach (CorporateCustomer ındividualcustomer in ındividualcustomerList)
        {
            if(ındividualcustomer.Id == id)
            {
                return ındividualcustomer;
            }
        }

        throw new BusinessException("CorporateCustomer is not exists. " + id);
    }
}