using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActiveInvoice.Domain.Write.States
{
    public class ActiveInvoiceState
    {
        public virtual Guid? Id { get; set; }
        public virtual Guid? UserId { get; set; }
        public virtual Guid? WorkerId { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string? ClientName { get; set; }
        public virtual int? TableNumber { get; set; }
        public virtual int? IndividualCheckNumber { get; set; }
        public virtual string? StartTime { get; set; }

        public virtual List<ActiveInvoiceItemState> ActiveInvoiceItemsState { get; set; }


    }
}
