using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ETapManagement.Common;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using Microsoft.EntityFrameworkCore;

namespace ETapManagement.Repository {

    public class CommonRepository : ICommonRepository {
        private readonly ETapManagementContext _context;
        public CommonRepository (ETapManagementContext context) {
            _context = context;

        }

        public void Dispose () {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose (bool disposing) {
            if (disposing) {
                _context.Dispose ();
            }
        }

        public void AuditLog (AuditLogs audit) {
            try {
                  LoginUser lgnUser =   WebHelpers.GetLoggedUser();
                audit.CreatedAt = DateTime.Now;
                audit.CreatedBy =lgnUser.Id;
                _context.AuditLogs.Add (audit);
                _context.SaveChanges ();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}