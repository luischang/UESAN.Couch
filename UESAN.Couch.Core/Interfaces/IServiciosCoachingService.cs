﻿using UESAN.Couch.Core.DTOs;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Core.Interfaces
{
    public interface IServiciosCoachingService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ServiciosCoachingDescriptionDTO>> GetAll();
        Task<ServiciosCoachingDTO> GetById(int id);
        Task<bool> Insert(ServiciosCoachingInsertDTO serviciosCoachingInsertDTO);
        Task<bool> Update(ServiciosCoachingDescriptionDTO serviciosCoachingDescriptionDTO);
    }
}