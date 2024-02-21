using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Responses.Brand;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal; // Bir entity service'i kendi entitysi dışında hiç bir entity'nin DAL'ını injekte etmemelidir.
    // private readonly IModelDal _modelDal;
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _brandDal = brandDal; //new InMemoryBrandDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    // AOP => Aspect Oriented Programming - Autofac
    // Pipeline 
    public AddBrandResponse Add(AddBrandRequest request)
    {
        if(!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            throw new Exception("Bu endpointi çalıştırmak için giriş yapmak zorundasınız!");
        }
        // İş Kuralları
        _brandBusinessRules.CheckIfBrandNameNotExists(request.Name);
        // Authentication-Authorization
        // Validation
        // Cache
        // Transaction
        //Brand brandToAdd = new(request.Name)
        Brand brandToAdd = _mapper.Map<Brand>(request); // Mapping

        _brandDal.Add(brandToAdd);

        AddBrandResponse response = _mapper.Map<AddBrandResponse>(brandToAdd);
        return response;
    }

    public Brand? GetById(int id)
    {
        return _brandDal.Get(i => i.Id == id);
    }

    public GetBrandListResponse GetList(GetBrandListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Brand> brandList = _brandDal.GetList();
    
        // brandList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Brand -> BrandListItemDto
        // IList<Brand> -> GetBrandListResponse

        GetBrandListResponse response = _mapper.Map<GetBrandListResponse>(brandList); // Mapping
        return response;
    }
}
