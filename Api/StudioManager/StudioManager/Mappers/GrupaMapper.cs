using AutoMapper;
using StudioManager.Models;

namespace StudioManager.Mappers
{
    public class GrupaMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Grupa, GrupaDTORead>()
                    .ForMember(dto => dto.planiprogram, entitet => entitet.MapFrom(src => src.PlaniProgram!.Naziv))
                    .ForMember(dto => dto.brojvjezbaca, entitet => entitet.MapFrom(src => src.Vjezbaci!.Count()));
                })
                );
        }

//c. oznacava configuration

        //public static Mapper InicijalizirajReadFromDTO()
        //{
        //    return new Mapper(
        //        new MapperConfiguration(c =>
        //        {
        //            c.CreateMap<GrupaDTORead, Grupa>();
        //        })
        //        );
        //}

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Grupa, GrupaDTOInsetUpdate>()
                    .ForMember(dto => dto.planiprogram, entitet => entitet.MapFrom(src => src.PlaniProgram!.Naziv))
                    .ForMember(dto => dto.brojvjezbaca, entitet => entitet.MapFrom(src => src.Vjezbaci!.Count()));
                })
                );
        }

    

    }
}