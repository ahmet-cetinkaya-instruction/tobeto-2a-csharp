using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Requests.Model;
using Business.Responses.Brand;
using Business.Responses.Model;
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper)
    {
        _brandDal = brandDal;
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
    }

    public AddBrandResponse Add(AddBrandRequest request)
    {
        // İş Kuralları

        _brandBusinessRules.CheckIfBrandNameNotExists(request.Name);

        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Brand brandToAdd = new(request.Name)
        /*Brand brandToAdd = _mapper.Map<Brand>(request); // Mapping

        _brandDal.Add(brandToAdd);

        AddBrandResponse response = _mapper.Map<AddBrandResponse>(brandToAdd);
        return response;*/
        //ValidationTool.Validate(new AddBrandRequestValidator(), request);


        var brandToAdd = _mapper.Map<Brand>(request);

        Brand addedBrand = _brandDal.Add(brandToAdd);

        var response = _mapper.Map<AddBrandResponse>(addedBrand);
        return response;
    }

    public DeleteBrandResponse Delete(DeleteBrandRequest request)
    {
        Brand? brandToDelete = _brandDal.Get(predicate: brand => brand.Id == request.Id); // 0x123123
        _brandBusinessRules.CheckIfBrandExists(brandToDelete); // 0x123123

        Brand deletedBrand = _brandDal.Delete(brandToDelete!); // 0x123123

        var response = _mapper.Map<DeleteBrandResponse>(
            deletedBrand // 0x123123
        );
        return response;
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

    public Brand FindByID(int id)
    {

        IList<Brand> brandList = _brandDal.GetList();
        foreach (Brand brand in brandList)
        {
            if(brand.Id == id)
            {
                return brand;
            }
        }

        throw new BusinessException("Brand is not exists. " + id);
    }

    public GetBrandByIdResponse GetById(GetBrandByIdRequest request)
    {
        Brand? brand = _brandDal.Get(brand => brand.Id == request.Id);
        _brandBusinessRules.CheckIfBrandExists(brand);

        var response = _mapper.Map<GetBrandByIdResponse>(brand);
        return response;
    }

    public UpdateBrandResponse Update(UpdateBrandRequest request)
    {
        Brand? brandToUpdate = _brandDal.Get(predicate: brand => brand.Id == request.Id); // 0x123123
        _brandBusinessRules.CheckIfBrandExists(brandToUpdate);

        brandToUpdate = _mapper.Map(request, brandToUpdate); // 0x123123
        Brand updatedBrand = _brandDal.Update(brandToUpdate!); // 0x123123

        var response = _mapper.Map<UpdateBrandResponse>(
            updatedBrand // 0x123123
        );
        return response;
    }
}