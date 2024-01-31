using System.Reflection;
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.Model;
using Business.Responses.Model;
using Core.CrossCuttingConcerns.Exceptions;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _modelDal;
    private readonly ModelBusinessRules _modelBusinessRules;
    private readonly IMapper _mapper;

    public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal;
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {
        ValidationTool.Validate(new AddModelRequestValidator(), request);

        _modelBusinessRules.CheckIfModelNameExists(request.Name);
        _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);

        var modelToAdd = _mapper.Map<Model>(request);

        Model addedModel = _modelDal.Add(modelToAdd);

        var response = _mapper.Map<AddModelResponse>(addedModel);
        return response;
    }

    public DeleteModelResponse Delete(DeleteModelRequest request)
    {
        Model? modelToDelete = _modelDal.Get(predicate: model => model.Id == request.Id); // 0x123123
        _modelBusinessRules.CheckIfModelExists(modelToDelete); // 0x123123

        Model deletedModel = _modelDal.Delete(modelToDelete!); // 0x123123

        var response = _mapper.Map<DeleteModelResponse>(
            deletedModel // 0x123123
        );
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

    public GetModelByIdResponse GetById(GetModelByIdRequest request)
    {
        Model? model = _modelDal.Get(predicate: model => model.Id == request.Id);
        _modelBusinessRules.CheckIfModelExists(model);

        var response = _mapper.Map<GetModelByIdResponse>(model);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        IList<Model> modelList = _modelDal.GetList(
            predicate: model =>
                (request.FilterByBrandId == null || model.BrandId == request.FilterByBrandId)
                && (request.FilterByFuelId == null || model.FuelId == request.FilterByFuelId)
                && (
                    request.FilterByTransmissionId == null
                    || model.TransmissionId == request.FilterByTransmissionId
                )
        );

        var response = _mapper.Map<GetModelListResponse>(modelList);

        return response;
    }

    public UpdateModelResponse Update(UpdateModelRequest request)
    {
        Model? modelToUpdate = _modelDal.Get(predicate: model => model.Id == request.Id); // 0x123123
        _modelBusinessRules.CheckIfModelExists(modelToUpdate);
        _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);

        modelToUpdate = _mapper.Map(request, modelToUpdate); // 0x123123
        Model updatedModel = _modelDal.Update(modelToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateModelResponse>(
            updatedModel // 0x123123
        );
        return response;
    }
}