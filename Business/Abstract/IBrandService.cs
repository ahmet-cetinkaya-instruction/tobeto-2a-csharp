using Entities.Concrete;

namespace Business.Abstract;

public interface IBrandService
{
    public Brand Add(Brand brand);

    public IList<Brand> GetList();
}
