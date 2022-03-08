using System;
using System.Linq;
using Application.CheckManagement.Domain.Read.Model;
using NHibernate;

namespace Application.CheckManagement.Domain.Read.Repositories
{
    public class CheckManagementReadRepository : IBaseReadCheckManagementRepository
    {
        private readonly ISession _session;
        public CheckManagementReadRepository(ISession _session)
        {
            this._session = _session;
        }
        
        public CheckManagemantSettingsModel GetSettingsByUserId(Guid id)
        {
            var checkManagemantSettings = new CheckManagemantSettingsModel();
            var list = _session.Query<CheckManagemantSettingsModel>().Where(x => x.UserId == id).ToList();

            checkManagemantSettings = list.FirstOrDefault();

            return checkManagemantSettings;
        }
    }
}