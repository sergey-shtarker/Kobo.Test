﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.DataContracts
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public DateTime? Birthday { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
