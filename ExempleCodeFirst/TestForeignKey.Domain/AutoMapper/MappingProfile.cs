using AutoMapper;
using System.Linq;
using TestCodeFirst.Domain.Entities;
using TestCodeFirst.Domain.ViewModels;

namespace TestCodeFirst.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        protected MappingProfile(string profileName) : base(profileName)
        {

        }

        public MappingProfile()
        {
            CreateMap<Many, ManyQueryViewModel>()
                .ForMember(p => p.CustomProperty, opts => opts.MapFrom(p => $"ManyID: { p.ManyID }/OneID: { p.OneID }/ManyProperty01: {p.ManyProperty01}/OneProperty01: {p.One.OneProperty01}"))
                .ForMember(p => p.QuantitySelfElement, opts => opts.MapFrom(p => p.SelfOne.Count()));
        }
    }
}
