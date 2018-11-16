using AteneaMobile.Models;
using AteneaMobile.ViewModels;

namespace AteneaMobile.Services
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config => 
                config.CreateMap<Paciente, PacientesViewModel>().ReverseMap()
            );
        }
    }
}
