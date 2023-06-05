using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Services
{
    public class TipoPlanService : ITipoPlanService
    {
        private readonly ITipoPlanRepository _tipoPlanRepository;

        public TipoPlanService(ITipoPlanRepository tipoPlanRepository)
        {
            _tipoPlanRepository = tipoPlanRepository;
        }

        public async Task<IEnumerable<TipoPlanDTO>> GetAll()
        {
            var tiposplan = await _tipoPlanRepository.GetAll();
            var tiposplanDTO = new List<TipoPlanDTO>();
            foreach (var tipoPlan in tiposplan)
            {
                var tipoplanDTO = new TipoPlanDTO();
                tipoplanDTO.IdPlan = tipoPlan.IdPlan;
                tipoplanDTO.NombrePlan = tipoPlan.NombrePlan;
                tiposplanDTO.Add(tipoplanDTO);
            }
            return tiposplanDTO;
        }

        public async Task<TipoPlanDTO> GetById(int id)
        {
            var tipoplan = await _tipoPlanRepository.GetById(id);
            if (tipoplan == null)
                return null;

            var tipoplanDTO = new TipoPlanDTO()
            {
                IdPlan = tipoplan.IdPlan,
                NombrePlan = tipoplan.NombrePlan,
            };
            return tipoplanDTO;
        }

        public async Task<bool> Insert(TipoPlanInsertDTO tipoPlanInsertDTO)
        {
            var tipoplan = new TipoPlan();
            tipoplan.NombrePlan = tipoPlanInsertDTO.NombrePlan;

            var result = await _tipoPlanRepository.Insert(tipoplan);
            return result;
        }

        public async Task<bool> Update(TipoPlanUpdateDTO tipoPlanUpdateDTO)
        {
            var tipopplan = await _tipoPlanRepository.GetById(tipoPlanUpdateDTO.IdPlan);
            if (tipopplan == null)
                return false;
            tipopplan.IdPlan = tipoPlanUpdateDTO.IdPlan;
            tipopplan.NombrePlan = tipoPlanUpdateDTO.NombrePlan;

            var result = await _tipoPlanRepository.Update(tipopplan);
            return result;
        }
        //public async Task<bool> Update(int id, TipoPlanUpdateDTO tipoPlanUpdateDTO)
        //{
        //    var tipopplan = await _tipoPlanRepository.GetById(id);
        //    if (tipopplan == null)
        //        return false;
        //    tipopplan.IdPlan = id;
        //    tipopplan.NombrePlan = tipoPlanUpdateDTO.NombrePlan;

        //    var result = await _tipoPlanRepository.Update(tipopplan);
        //    return result;
        //}
    }
}
