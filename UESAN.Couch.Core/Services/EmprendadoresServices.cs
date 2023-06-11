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
        public async Task<IEnumerable<EmprendadoresDTO>> GetAll()
        {
            var emprendadores = await _emprendadoresRepository.GetAll();

            var emprendadoresDTO = emprendadores.Select(e => new EmprendadoresDTO
            {
                IdEmprendedor = e.IdEmprendedor,
                IdPersona = e.IdPersona,
                IsActive = e.IsActive
            });
            return emprendadoresDTO;
        }
        public async Task<EmprendadoresDTO> GetById(int id)
        {
            var emprendadores = await _emprendadoresRepository.GetById(id);
            if (emprendadores == null)
            {
                return null;
            }
            var emprendadoresDTO = new EmprendadoresDTO
            {
                IdEmprendedor = emprendadores.IdEmprendedor,
                IdPersona = emprendadores.IdPersona,
                IsActive = emprendadores.IsActive
            };
            return emprendadoresDTO;
        }
        public async Task<bool> Insert(EmprendadoresInDTO emprendadoresInUpDTO)
        {
            var emprendadores = new Emprendadores
            {
                IdPersona = emprendadoresInUpDTO.IdPersona,
                IsActive = emprendadoresInUpDTO.IsActive
            };
            await _emprendadoresRepository.Insert(emprendadores);
            return true;
        }
        public async Task<bool> Update(EmprendadoresUpDTO emprendadoresUpDTO)
        {
            var emprendadores = new Emprendadores()
            {
                IdPersona = emprendadoresUpDTO.IdPersona,
                IsActive = emprendadoresUpDTO.IsActive
            };

            return await _emprendadoresRepository.Update(emprendadores);
           
            
        }
        public async Task<bool> Delete(int id)
        {
            var emprendadores = await _emprendadoresRepository.GetById(id);
            if (emprendadores == null)
            {
                return false;
            }
            await _emprendadoresRepository.Delete(id);
            return true;
        }
    }
}
