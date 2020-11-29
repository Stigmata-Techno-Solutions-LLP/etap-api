using System;
using System.Threading.Tasks;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Domain;

namespace ETapManagement.Repository {
    public interface ICommonRepository {
        void AuditLog (AuditLogs auditLog);
    }
}