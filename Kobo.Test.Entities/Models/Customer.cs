using System;
using System.Collections.Generic;

namespace Kobo.Test.Entities.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Email { get; set; }
        public virtual Person Person { get; set; }
    }
}
