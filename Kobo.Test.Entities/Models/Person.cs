using System;
using System.Collections.Generic;

namespace Kobo.Test.Entities.Models
{
    public partial class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
