using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestForeignKey.Domain.AutoMapper
{
    public class MappingProfile : Profile
    {
        protected MappingProfile(string profileName) : base(profileName)
        {

        }

        public MappingProfile()
        {
        }
    }
}
