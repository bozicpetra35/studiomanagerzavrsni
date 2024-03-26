using AutoMapper;
using StudioManager.Mappers;
using StudioManager.Models;
using StudioManager.Models.EdunovaAPP.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudioManager.Extensions
{
    public static class Mapping
    {


        public static List<PlaniprogramDTORead> MapPlaniprogramReadList(this List<Planiprogram> lista)
        {
            var mapper = PlaniprogramMapper.InicijalizirajReadToDTO();
            var vrati = new List<PlaniprogramDTORead>();
            lista.ForEach(e => {
                vrati.Add(mapper.Map<PlaniprogramDTORead>(e));
            });
            return vrati;
        }

        public static PlaniprogramDTORead MapPlaniprogramReadToDTO(this Planiprogram entitet)
        {
            var mapper = PlaniprogramMapper.InicijalizirajReadToDTO();
            return mapper.Map<PlaniprogramDTORead>(entitet);
        }

        public static PlaniprogramDTOInsertUpdate MapPlaniprogramInsertUpdateToDTO(this Planiprogram entitet)
        {
            var mapper = PlaniprogramMapper.InicijalizirajInsertUpdateToDTO();
            return mapper.Map<PlaniprogramDTOInsertUpdate>(entitet);
        }


        public static Planiprogram MapPlaniprogramInsertUpdateFromDTO(
            this PlaniprogramDTOInsertUpdate dto, Planiprogram entitet)
        {
            entitet.Naziv = dto.naziv;
            entitet.TjednaSatnica = dto.tjednasatnica;
            entitet.Cijena = dto.cijena;
            entitet.Trener = dto.trener;
            return entitet;
        }




    }
}

