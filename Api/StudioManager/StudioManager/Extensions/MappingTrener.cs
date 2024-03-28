using AutoMapper;
using StudioManager.Mappers;
using StudioManager.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudioManager.Extensions
{
    public static class MappingTrener
    {


        public static List<TrenerDTORead> MapTrenerReadList(this List<Trener> lista)
        {
            var mapper = TrenerMapper.InicijalizirajReadToDTO();
            var vrati = new List<TrenerDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<TrenerDTORead>(e));
            });
            return vrati;
        }

        public static TrenerDTORead MapTrenerReadToDTO(this Trener entitet)
        {
            var mapper = TrenerMapper.InicijalizirajReadToDTO();
            return mapper.Map<TrenerDTORead>(entitet);
        }

        public static TrenerDTOInsertUpdate MapTrenerInsertUpdateToDTO(this Trener entitet)
        {
            var mapper = TrenerMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<TrenerDTOInsertUpdate>(entitet);
        }


        public static Trener MapTrenerInsertUpdateFromDTO(
            this TrenerDTOInsertUpdate dto, Trener entitet)
        {
            entitet.Ime = dto.ime;
            entitet.Prezime = dto.prezime;
            entitet.Telefon = dto.telefon;
            entitet.Oib = dto.oib;
            entitet.Iban = dto.iban;
            return entitet;
        }




    }
}

