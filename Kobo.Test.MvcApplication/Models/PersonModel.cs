using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kobo.Test.MvcApplication.Models
{
    public class PersonModel : PersonItemModel
    {
        public CustomerModel CustomerModel { get; set; }

        public SupplierModel SupplierModel { get; set; }

    }
}