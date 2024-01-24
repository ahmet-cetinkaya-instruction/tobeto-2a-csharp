using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
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
}
