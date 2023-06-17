using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Core.Interfaces;
using UESAN.Couch.Infrastructure.Data;
using UESAN.Couch.Infrastructure.Repositories;

namespace UESAN.Couch.Core.Services
{
    public class EmprendadoresServices : IEmprendadoresServices
    {
        private readonly IEmprendedoresRepository _emprendadoresRepository;

        public EmprendadoresServices(IEmprendedoresRepository emprendadoresRepository)
        {
            _emprendadoresRepository = emprendadoresRepository;
        }
        public async Task<IEnumerable<EmprendadoresDescDTOS>> GetAll()
        {
            var emprendadores = await _emprendadoresRepository.GetAll();

            var emprendadoresDTO = new List<EmprendadoresDescDTOS>();

            foreach (var emprendedor in emprendadores)
            {
                var emprendador = new EmprendadoresDescDTOS();
                emprendador.IdEmprendedor = emprendedor.IdEmprendedor;
                emprendador.IdPersona = emprendedor.IdPersona;

                emprendadoresDTO.Add(emprendador);
            }
            return emprendadoresDTO;

        }
        public async Task<EmprendadoresDTO> GetById(int id)
        {
            var emprendadores = await _emprendadoresRepository.GetById(id);
            var emprendadoresDTO = new EmprendadoresDTO();
            emprendadoresDTO.IdEmprendedor = emprendadores.IdEmprendedor;
            emprendadoresDTO.IdPersona = emprendadores.IdPersona;
            emprendadoresDTO.IsActive = emprendadores.IsActive;

            return emprendadoresDTO;
        }

        public async Task<bool> Insert(EmprendadoresInDTO emprendadoresInUpDTO)
        {
            var emprendadores = new Emprendadores();
            emprendadores.IdPersona = emprendadoresInUpDTO.IdPersona;
            emprendadores.IsActive = emprendadoresInUpDTO.IsActive;

            var result = await _emprendadoresRepository.Insert(emprendadores);

            return result;
        }
        public async Task<bool> Update(EmprendadoresDescDTOS emprendedorDescrDTO)
        {

            var emprendadores = await _emprendadoresRepository.GetById(emprendedorDescrDTO.IdEmprendedor);
            if (emprendadores == null)
            {
                return false;
            }
            emprendadores.IdPersona = emprendedorDescrDTO.IdPersona;

            var result = await _emprendadoresRepository.Update(emprendadores);
            return result;

        }
        public async Task<bool> Delete(int id)
        {
            var emprendadores = await _emprendadoresRepository.GetById(id);
            if (emprendadores == null)
            {
                return false;
            }
            return await _emprendadoresRepository.Delete(id);

        }

    }

}

