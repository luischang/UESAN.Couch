﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Couch.Infrastructure.Data;

namespace UESAN.Couch.Infrastructure.Repositories
{
    public class UsuariosRepository : ITiposUsuariosRepository
    {
        private readonly CoachServicesContext _context;
        public UsuariosRepository(CoachServicesContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> SignIn(string email, string password)
        {
            return await _context
                .Usuarios
                .Where(x => x.CorreoElectronico == email && x.Contrasena == password)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SignUp(Usuarios user)
        {
            await _context.Usuarios.AddAsync(user);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string correoElectronico)
        {
            return await _context
                .Usuarios
                .Where(x => x.CorreoElectronico == correoElectronico).AnyAsync();
        }
    }

}


        

