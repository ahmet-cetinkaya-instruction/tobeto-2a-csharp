﻿using System.Reflection;
using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.Model;
using Business.Responses.Model;
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
        _modelBusinessRules.CheckIfBrandExists(request.BrandId);
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

    public GetModelByIdResponse GetById(GetModelByIdRequest request)
    {
        Model? model = _modelDal.Get(predicate: model => model.Id == request.Id);
        _modelBusinessRules.CheckIfModelExists(model);

        var response = _mapper.Map<GetModelByIdResponse>(model);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        // business rules

        // data access

        //bool predicate(Model model)
        //{
        //    return (request.FilterByBrandId == null || model.BrandId == request.FilterByBrandId)
        //        && (request.FilterByFuelId == null || model.FuelId == request.FilterByFuelId)
        //        && (
        //            request.FilterByTransmissionId == null
        //            || model.TransmissionId == request.FilterByTransmissionId
        //        );
        //}
        //IList<Model> modelList = _modelDal.GetList(predicate);

        IList<Model> modelList = _modelDal.GetList(
            predicate: model =>
                (request.FilterByBrandId == null || model.BrandId == request.FilterByBrandId)
                && (request.FilterByFuelId == null || model.FuelId == request.FilterByFuelId)
                && (
                    request.FilterByTransmissionId == null
                    || model.TransmissionId == request.FilterByTransmissionId
                )
        );

        // mapping & response
        var response = _mapper.Map<GetModelListResponse>(modelList);
        //var responseWithoutAutoMapper = new GetModelListResponse();
        //responseWithoutAutoMapper.Items = modelList
        //    .Select(
        //        model =>
        //            new ModelListItemDto
        //            {
        //                BrandId = model.BrandId,
        //                BrandName = model.Brand.Name,
        //                FuelId = model.FuelId,
        //                FuelName = model.Fuel.Name,
        //                Id = model.Id,
        //                Name = model.Name,
        //                TransmissionId = model.TransmissionId,
        //                TransmissionName = model.Transmission.Name
        //            }
        //    )
        //    .ToList();
        return response;
    }

    public UpdateModelResponse Update(UpdateModelRequest request)
    {
        Model? modelToUpdate = _modelDal.Get(predicate: model => model.Id == request.Id); // 0x123123
        _modelBusinessRules.CheckIfModelExists(modelToUpdate);
        _modelBusinessRules.CheckIfModelYearShouldBeInLast20Years(request.Year);
        _modelBusinessRules.CheckIfBrandExists(request.BrandId);

        //modelToUpdate = _mapper.Map<Model>(request); // 0x333123
        /* Bunu kullanmayacağız çünkü bizim için yeni bir nesne (referans) oluşturuyor.
        Ve ayrıca entity sınıfında olup da request sınıfında olmayan alanlar (örn. CreatedAt vb.) varsayılan değerler alacak,
        böylece yanlış bir veri güncellemesi yapmış oluruz. */
        modelToUpdate = _mapper.Map(request, modelToUpdate); // 0x123123
        Model updatedModel = _modelDal.Update(modelToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateModelResponse>(
            updatedModel // 0x123123
        );
        return response;
    }
}
