using ShopAPI2.Data;
using ShopAPI2.Models;
using AutoMapper;

namespace ShopAPI2.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Products, ProductModel>().ReverseMap();
        }
    }
}
