using AutoMapper;
using MarketEase_API.Entity;
using MarketEase_API.Model;

namespace MarketEase_API.Mapper
{
    public class MarketProfile : Profile
    {
        public MarketProfile()
        {
            CreateMap<Product, ProductInputModel>();
            CreateMap<ProductInputModel, Product>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<PackagingTypes, PackInputModel>();
            CreateMap<PackInputModel, PackagingTypes>();
            CreateMap<PackagingTypes, PackViewModel>();

        }
    }
}
