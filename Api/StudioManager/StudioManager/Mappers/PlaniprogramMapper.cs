using AutoMapper;
using StudioManager.Models;
using StudioManager.Models.EdunovaAPP.Models;

namespace StudioManager.Mappers
{
    public class PlaniprogramMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Planiprogram, PlaniprogramDTORead>();
                })
                );
        }

//c. oznacava configuration

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<PlaniprogramDTORead, Planiprogram>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Planiprogram, PlaniprogramDTOInsertUpdate>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<PlaniprogramDTOInsertUpdate, Planiprogram>();
                })
                );
        }

    }
}