using System;
using System.Collections.Generic;

namespace CompleteData.Shared.Models
{
    public partial class EmployeeTerritories
    {
        public EmployeeTerritories()
        {
            Employees = new HashSet<Employees>();
        }

        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

         public virtual ICollection<Employees> Employees { get; set; }
        public virtual Territories Territory { get; set; }
    }
}
