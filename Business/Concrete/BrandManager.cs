using Business.Abstract;
using Business.BusinessRules;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;
    private readonly BrandBusinessRules _brandBusinessRules;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules)
    {
        _brandDal = brandDal; //new InMemoryBrandDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _brandBusinessRules = brandBusinessRules;
    }

    public Brand Add(Brand brand)
    {
        // İş Kuralları
        _brandBusinessRules.CheckIfBrandNameNotExists(brand.Name);

        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        //Brand addedBrand =
        _brandDal.Add(brand);

        return brand;
    }

    public IList<Brand> GetList()
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Brand> brandList = _brandDal.GetList();
        return brandList;
    }
}
