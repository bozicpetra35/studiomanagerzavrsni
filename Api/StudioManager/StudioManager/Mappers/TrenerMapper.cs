using AutoMapper;
using StudioManager.Models;

namespace StudioManager.Mappers
{
    public class TrenerMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Trener, TrenerDTORead>();
                })
                );
        }

//c. oznacava configuration

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<TrenerDTORead, Trener>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Trener, TrenerDTOInsertUpdate>();
                })
                );
        }

    

    }
}