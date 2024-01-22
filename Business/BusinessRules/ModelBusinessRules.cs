using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _modelDal;

    public ModelBusinessRules(IModelDal modelDal)
    {
        _modelDal = modelDal;
    }

    public void CheckIfModelNameNotExists(string modelName, double dailyPrice)
    {
        bool isExists = _modelDal.GetList().Any(b => b.Name == modelName);
        if (isExists)
        {
            throw new BusinessException("Model already exists.");
        }
        
        if (modelName.Length < 2)
        {
            throw new BusinessException("Model name minimum 2 character.");
        }
        
        if (dailyPrice <= 0)
        {
            throw new BusinessException("dailyPrice minimum 1.");
        }
    }
}