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

    public void CheckIfModelNameNotExists(string modelName)
    {
        bool isExists = _modelDal.GetList().Any(b => b.Name == modelName);
        if (isExists)
        {
            throw new BusinessException("Model already exists.");
        }
    }
}