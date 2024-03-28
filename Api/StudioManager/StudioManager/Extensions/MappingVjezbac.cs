using AutoMapper;
using StudioManager.Mappers;
using StudioManager.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudioManager.Extensions
{
    public static class MappingVjezbac
    {


        public static List<VjezbacDTORead> MapVjezbacReadList(this List<Vjezbac> lista)
        {
            var mapper = VjezbacMapper.InicijalizirajReadToDTO();
            var vrati = new List<VjezbacDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<VjezbacDTORead>(e));
            });
            return vrati;
        }

        public static VjezbacDTORead MapVjezbacReadToDTO(this Vjezbac entitet)
        {
            var mapper = VjezbacMapper.InicijalizirajReadToDTO();
            return mapper.Map<VjezbacDTORead>(entitet);
        }

        public static VjezbacDTOInsertUpdate MapVjezbacInsertUpdateToDTO(this Vjezbac entitet)
        {
            var mapper = VjezbacMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<VjezbacDTOInsertUpdate>(entitet);
        }


        public static Vjezbac MapVjezbacInsertUpdateFromDTO(
            this VjezbacDTOInsertUpdate dto, Vjezbac entitet)
        {
            entitet.Ime = dto.ime;
            entitet.Prezime = dto.prezime;
            entitet.Telefon = dto.telefon;
            entitet.BrojUpisnogLista = dto.brojupisnoglista;
            return entitet;
        }




    }
}

