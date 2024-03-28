using AutoMapper;
using StudioManager.Models;

namespace StudioManager.Mappers
{
    public class VjezbacMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Vjezbac, VjezbacDTORead>();
                })
                );
        }

//c. oznacava configuration

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<VjezbacDTORead, Vjezbac>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Vjezbac, VjezbacDTOInsertUpdate>();
                })
                );
        }

    

    }
}