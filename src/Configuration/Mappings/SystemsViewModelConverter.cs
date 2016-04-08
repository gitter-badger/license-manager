using System.Collections.Generic;
using AutoMapper;
using LicenseManager.ViewModels.Configuration.Systems;

namespace LicenseManager.Configuration.Mappings
{
    public class SystemsViewModelConverter : ITypeConverter<List<Models.System>, SystemsViewModel>
    {
        public SystemsViewModel Convert(ResolutionContext context)
        {
            List<Models.System> source = (List<Models.System>)context.SourceValue;

            SystemsViewModel destination = new SystemsViewModel();
            destination.Table = new SystemsTableViewModel();
            destination.Table.Rows = new List<SystemsTableRowViewModel>();
            foreach (Models.System system in source)
            {
                destination.Table.Rows.Add(new SystemsTableRowViewModel()
                {
                    Id = system.Id,
                    Name = system.Name,
                    Description = system.Description
                });
            }

            return destination;
        }
    }
}