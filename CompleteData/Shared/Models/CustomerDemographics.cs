using System;
using System.Collections.Generic;

namespace CompleteData.Shared.Models
{
    public partial class CustomerDemographics
    {
        public CustomerDemographics()
        {
             Customers = new HashSet<Customers>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

       public virtual ICollection<Customers> Customers { get; set; }
    }
}
