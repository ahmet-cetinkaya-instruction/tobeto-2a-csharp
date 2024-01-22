using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _modelDal;
    private readonly ModelBusinessRules _modelBusinessRules;
    private readonly IMapper _mapper;

    private BrandManager _brandManager = new BrandManager();
    private FuelManager _fuelManager = new FuelManager();
    private TransmissionManager _transmissionManager = new TransmissionManager();

    public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal; //new InMemoryModelDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {
        // İş Kuralları
        _modelBusinessRules.CheckIfModelNameNotExists(request.Name);
        Brand brand = _brandManager.FindByID(request.BrandId);
        Fuel fuel = _fuelManager.FindByID(request.FuelId);
        Transmission transmission = _transmissionManager.FindByID(request.TransmissionId);

        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Model modelToAdd = new(request.Name)
        Model modelToAdd = _mapper.Map<Model>(request); // Mapping
        modelToAdd.Brand = brand;
        modelToAdd.Fuel = fuel;
        modelToAdd.Transmission = transmission;

        _modelDal.Add(modelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(modelToAdd);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Model> modelList = _modelDal.GetList();

        // modelList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Model -> ModelListItemDto
        // IList<Model> -> GetModelListResponse

        GetModelListResponse response = _mapper.Map<GetModelListResponse>(modelList); // Mapping
        return response;
    }

    public Model FindByID(int id)
    {

        IList<Model> modelList = _modelDal.GetList();
        foreach (Model model in modelList)
        {
            if (model.Id == id)
            {
                return model;
            }
        }

        throw new BusinessException("Model is not exists. " + id);
    }
}