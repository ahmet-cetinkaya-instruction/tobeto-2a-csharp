using Azure.Core;
using Business.Abstract;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;
    private readonly IBrandService _brandService;


    public ModelBusinessRules(IModelDal modelDal, IBrandService brandService)
    {
        _modelDal = modelDal;
        _brandService = brandService;
    }

    public void CheckIfModelNameExists(string name)
    {
        bool isNameExists = _modelDal.Get(m => m.Name == name) != null;
        if (isNameExists)
            throw new BusinessException("Model name already exists.");
    }

    public void CheckIfModelExists(Model? model)
    {
        if (model is null)
            throw new NotFoundException("Model not found.");
    }

    public void CheckIfModelYearShouldBeInLast20Years(short year)
    {
        if (year < DateTime.UtcNow.AddYears(-20).Year)
            throw new BusinessException("Model year should be in last 20 years.");
    }
    public void CheckIfBrandExists(int brandId)
    {

        Brand? brand = _brandService.GetById(brandId);
        if (brand is null)
            throw new Exception("Böyle bir marka yok.");
    }
}
