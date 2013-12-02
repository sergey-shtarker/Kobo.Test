using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kobo.Test.DataContracts
{
    [DataContract]
    public class Supplier
    {
        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public string ContactManager { get; set; }
    }
}
