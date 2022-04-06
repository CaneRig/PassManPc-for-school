using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasManPC.Core.Session.Exceptions
{

    [Serializable]
    public class ElementNotExists : Exception
    {
        public ElementNotExists(): base("Error: element dont exist") { }
        public ElementNotExists(string name) : base("Error: element \""+name+"\" dont exists") { }
        public ElementNotExists(string name, Exception inner) : base("Error: element \"" + name + "\" dont exists", inner) { }
        protected ElementNotExists(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
