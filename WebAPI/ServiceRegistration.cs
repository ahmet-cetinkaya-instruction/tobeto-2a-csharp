using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;

namespace WebAPI;

public static class ServiceRegistration
{
    public static readonly IBrandDal BrandDal = new InMemoryBrandDal();
    public static readonly BrandBusinessRules BrandBusinessRules = new BrandBusinessRules(BrandDal);
    public static readonly IBrandService BrandService = new BrandManager(BrandDal, BrandBusinessRules);
} // IoC Container yapımızı kurduğumuz Dependency Injection ile daha verimli hale getiricez.
