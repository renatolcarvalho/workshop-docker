using AutoMapper;
using Example.Application.InOut.Clients;
using Example.Domain.Models;

namespace Example.Application.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Client, ClientResponse>();
        }
    }
}
