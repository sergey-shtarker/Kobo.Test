using System;
using System.Collections.Generic;

namespace Kobo.Test.Entities.Models
{
    public partial class Supplier
    {
        public long Id { get; set; }
        public string Telephone { get; set; }
        public string ContactManager { get; set; }
        public virtual Person Person { get; set; }
    }
}
