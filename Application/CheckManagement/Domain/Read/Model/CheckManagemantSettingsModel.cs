using System;

namespace Application.CheckManagement.Domain.Read.Model
{
    public class CheckManagemantSettingsModel
    {
        public virtual Guid Id { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual int TotalTables { get; set; }
        public virtual int TotalIndividualChecks { get; set; }
        public virtual bool SideMenuAvailableTables { get; set; }
        public virtual bool SideMenuAvailableIndividualChecks { get; set; }
    }
}