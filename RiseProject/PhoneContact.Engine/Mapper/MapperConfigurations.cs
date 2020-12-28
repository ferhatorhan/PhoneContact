using AutoMapper;
using PhoneContact.Data.Entities;
using PhoneContact.Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.Engine.Mapper
{
    public class MapperConfigurations
    {
        public static void Map(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.CreateMap<CommunicationInfoDTO, CommunicationInfoEntity>().ForMember(meb => meb.ContentType,
                                           dest => dest.MapFrom(map => map.Type));
            mapperConfiguration.CreateMap<ContentTypeDTO, ContentTypeEntity>();
            mapperConfiguration.CreateMap<ContactDTO, ContactEntity>().ForMember(member => member.CommunicationInfo,
                                           dest => dest.MapFrom(src => src.CommunicationInfos)); 
            mapperConfiguration.CreateMap<CommunicationInfoEntity, CommunicationInfoDTO>()
                                .ForMember(meb => meb.Type,
                                           dest => dest.MapFrom(map => map.ContentType));
            mapperConfiguration.CreateMap<ContentTypeEntity, ContentTypeDTO>();
            mapperConfiguration.CreateMap<ContactEntity, ContactDTO>()
                                .ForMember(member => member.CommunicationInfos,
                                           dest => dest.MapFrom(src => src.CommunicationInfo));
        }
    }
}
