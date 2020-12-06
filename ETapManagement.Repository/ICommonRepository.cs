using System;
using System.Threading.Tasks;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Domain.Models;

namespace ETapManagement.Repository {
    public interface ICommonRepository {
        void AuditLog (AuditLogs auditLog);
    }
}