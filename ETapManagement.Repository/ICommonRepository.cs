using System;
using System.Threading.Tasks;
using ETapManagement.Domain.Models;
using ETapManagement.ViewModel.Dto;
using ETapManagement.Common;

namespace ETapManagement.Repository {
    public interface ICommonRepository {
        void AuditLog (AuditLogs auditLog);
    }
}