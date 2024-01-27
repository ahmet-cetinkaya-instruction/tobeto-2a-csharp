using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class IndividualCustomerManager : IIndividualCustomerService
{
    private readonly IIndividualCustomerDal _ındividualcustomerDal;
    private readonly IndividualCustomerBusinessRules _ındividualcustomerBusinessRules;
    private readonly IMapper _mapper;

    public IndividualCustomerManager(IIndividualCustomerDal ındividualcustomerDal, IndividualCustomerBusinessRules ındividualcustomerBusinessRules, IMapper mapper)
    {
        _ındividualcustomerDal = ındividualcustomerDal; 
        _ındividualcustomerBusinessRules = ındividualcustomerBusinessRules;
        _mapper = mapper;
    }

    public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request)
    {
        _ındividualcustomerBusinessRules.CheckIfIndividualCustomerNameNotExists(request.Name);

        IndividualCustomer ındividualcustomerToAdd = _mapper.Map<IndividualCustomer>(request); // Mapping

        _ındividualcustomerDal.Add(ındividualcustomerToAdd);

        AddIndividualCustomerResponse response = _mapper.Map<AddIndividualCustomerResponse>(ındividualcustomerToAdd);
        return response;
    }

    public GetIndividualCustomerListResponse GetList(GetIndividualCustomerListRequest request)
    {

        IList<IndividualCustomer> ındividualcustomerList = _ındividualcustomerDal.GetList();

        GetIndividualCustomerListResponse response = _mapper.Map<GetIndividualCustomerListResponse>(ındividualcustomerList); // Mapping
        return response;
    }

    public IndividualCustomer FindByID(int id)
    {

        IList<IndividualCustomer> ındividualcustomerList = _ındividualcustomerDal.GetList();
        foreach (IndividualCustomer ındividualcustomer in ındividualcustomerList)
        {
            if(ındividualcustomer.Id == id)
            {
                return ındividualcustomer;
            }
        }

        throw new BusinessException("IndividualCustomer is not exists. " + id);
    }
}