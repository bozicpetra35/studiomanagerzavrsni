using AutoMapper;
using StudioManager.Mappers;
using StudioManager.Models;

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

        public static Planiprogram MapPlaniprogramInsertUpdateFromDTO(this PlaniprogramDTOInsertUpdate entitet)
        {
            var mapper = PlaniprogramMapper.InicijalizirajInsertUpdateFromDTO();
            return mapper.Map<Planiprogram>(entitet);
        }



    }
}

