using Application.CheckManagement.Domain.Read.Model;
using FluentNHibernate.Mapping;

namespace Application.CheckManagement.Domain.Read.Maps
{
    public class CheckManagementSettingsMap: ClassMap<CheckManagemantSettingsModel>
    {
        public CheckManagementSettingsMap()
        {
            ReadOnly();
            
            Table("[CheckManagementSetting]");

            Id(x => x.Id);

            Map(x => x.TotalTables);
            Map(x => x.TotalIndividualChecks);
            Map(x => x.SideMenuAvailableTables);
            Map(x => x.SideMenuAvailableIndividualChecks);
            Map(x => x.UserId);
            
        }
    }
}