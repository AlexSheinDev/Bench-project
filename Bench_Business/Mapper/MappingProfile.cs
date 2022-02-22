using AutoMapper;
using Bench_DataAccess;
using Bench_Models;

namespace Bench_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Item, ItemDTO>().ReverseMap();
            //CreateMap<ItemDTO, Item>();
        }
    }
}
