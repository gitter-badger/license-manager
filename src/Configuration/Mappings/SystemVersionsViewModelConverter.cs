using System.Collections.Generic;
using AutoMapper;
using LicenseManager.ViewModels.Configuration.SystemVersions;

namespace LicenseManager.Configuration.Mappings
{
    public class SystemVersionsViewModelConverter : ITypeConverter<List<Models.SystemVersion>, SystemVersionsViewModel>
    {
        public SystemVersionsViewModel Convert(ResolutionContext context)
        {
            List<Models.SystemVersion> source = (List<Models.SystemVersion>)context.SourceValue;

            SystemVersionsViewModel destination = new SystemVersionsViewModel();
            destination.Table = new SystemVersionsTableViewModel();
            destination.Table.Rows = new List<SystemVersionsTableRowViewModel>();
            foreach (Models.SystemVersion systemVersion in source)
            {
                destination.Table.Rows.Add(new SystemVersionsTableRowViewModel()
                {
                    Id = systemVersion.Id,
                    Major = systemVersion.Major,
                    Minor = systemVersion.Minor,
                    Description = systemVersion.Description,
                    SystemName = systemVersion.System.Name,
                    Deleted = systemVersion.Deleted
                });
            }

            return destination;
        }
    }
}