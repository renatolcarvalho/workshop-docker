using AutoMapper;
using Example.Application.InOut.Clients;
using Example.Domain.Models;

namespace Example.Application.Mapping
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<ClientRequest, Client>()
                .ForMember(client => client.Id, configuration => configuration.Ignore())
                .ConstructUsing(client => new Client(client.Name, client.Email));
        }
    }
}
