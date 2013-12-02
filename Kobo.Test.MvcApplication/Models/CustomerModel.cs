using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Kobo.Test.MvcApplication.Models
{
    public class CustomerModel
    {
        [DisplayName("Birthday yyyy/mm/dd ")]
        public DateTime? Birthday { get; set; }

        public string Email { get; set; }
    }
}