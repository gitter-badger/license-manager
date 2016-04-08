using System;
using System.Collections.Generic;
using AutoMapper;
using LicenseManager.ViewModels.Configuration.Clients;
using LicenseManager.ViewModels.Configuration.Systems;
using LicenseManager.ViewModels.Configuration.SystemVersions;

namespace LicenseManager.Configuration.Mappings
{
    /// Profil ustawień AutoMappera
    public class MapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<CreateClientViewModel, Models.Client>()
                .ForMember(d => d.Id, c => c.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.CreationDate, c => c.MapFrom(s => DateTime.Now))
                .ForMember(d => d.LastModificationDate, c => c.Ignore())
                .ForMember(d => d.Name, c => c.MapFrom(s => s.Name))
                .ForMember(d => d.Description, c => c.MapFrom(s => !string.IsNullOrEmpty(s.Description) ? s.Description : null))
                .ForMember(d => d.Products, c => c.Ignore());

            CreateMap<CreateSystemViewModel, Models.System>()
                .ForMember(d => d.Id, c => c.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.CreationDate, c => c.MapFrom(s => DateTime.Now))
                .ForMember(d => d.LastModificationDate, c => c.Ignore())
                .ForMember(d => d.Name, c => c.MapFrom(s => s.Name))
                .ForMember(d => d.Description, c => c.MapFrom(s => !string.IsNullOrEmpty(s.Description) ? s.Description : null))
                .ForMember(d => d.SystemVersions, c => c.Ignore());

            CreateMap<CreateSystemVersionViewModel, Models.SystemVersion>()
                .ForMember(d => d.Id, c => c.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.CreationDate, c => c.MapFrom(s => DateTime.Now))
                .ForMember(d => d.LastModificationDate, c => c.Ignore())
                .ForMember(d => d.Major, c => c.MapFrom(s => int.Parse(s.Major)))
                .ForMember(d => d.Minor, c => c.MapFrom(s => int.Parse(s.Minor)))
                .ForMember(d => d.Description, c => c.MapFrom(s => !string.IsNullOrEmpty(s.Description) ? s.Description : null))
                .ForMember(d => d.System, c => c.Ignore())
                .ForMember(d => d.SystemId, c => c.Ignore());

            CreateMap<List<Models.Client>, ClientsViewModel>()
                .ConvertUsing(new ClientsViewModelConverter());

            CreateMap<List<Models.System>, SystemsViewModel>()
                .ConvertUsing(new SystemsViewModelConverter());

            CreateMap<List<Models.SystemVersion>, SystemVersionsViewModel>()
                .ConvertUsing(new SystemVersionsViewModelConverter());
        }
    }
}