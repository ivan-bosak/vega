using System.Collections.Generic;
using AutoMapper;
using vega.Controllers;
using vega.Controllers.Resources;
using vega.Core.Models;

namespace vega.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Model to Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
        }
    }
}