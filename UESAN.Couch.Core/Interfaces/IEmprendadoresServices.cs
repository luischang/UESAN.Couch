﻿using UESAN.Couch.Core.DTOs;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IEmprendadoresServices
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<EmprendadoresDescDTOS>> GetAll();
        Task<EmprendadoresDTO> GetById(int id);
        Task<bool> Insert(EmprendadoresInDTO emprendadoresInUpDTO);
        Task<bool> Update(EmprendadoresDescDTOS emprendedorDescrDTO);
    }
}