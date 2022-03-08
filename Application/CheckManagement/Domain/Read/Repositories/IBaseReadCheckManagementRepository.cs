using System;
using Application.CheckManagement.Domain.Read.Model;

namespace Application.CheckManagement.Domain.Read.Repositories
{
    public interface IBaseReadCheckManagementRepository
    {
        public CheckManagemantSettingsModel GetSettingsByUserId(Guid id);
    }
}