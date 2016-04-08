using System.Collections.Generic;
using AutoMapper;
using LicenseManager.ViewModels.Configuration.Clients;

namespace LicenseManager.Configuration.Mappings
{
    public class ClientsViewModelConverter : ITypeConverter<List<Models.Client>, ClientsViewModel>
    {
        public ClientsViewModel Convert(ResolutionContext context)
        {
            List<Models.Client> source = (List<Models.Client>)context.SourceValue;

            ClientsViewModel destination = new ClientsViewModel();
            destination.Table = new ClientsTableViewModel();
            destination.Table.Rows = new List<ClientsTableRowViewModel>();
            foreach (Models.Client client in source)
            {
                destination.Table.Rows.Add(new ClientsTableRowViewModel()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Description = client.Description
                });
            }

            return destination;
        }
    }
}