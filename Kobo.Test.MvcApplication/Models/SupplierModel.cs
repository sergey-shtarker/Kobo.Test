using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Kobo.Test.MvcApplication.Models
{
    public class SupplierModel
    {
        [DisplayName("Contact Manager")]
        public string ContactManager { get; set; }

        public string Telephone { get; set; }
    }
}