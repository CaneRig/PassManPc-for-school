using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasManPC.Core.Session.Exceptions
{
    [System.Serializable]
    public class ElementAlreadyExists : Exception
    {
        public ElementAlreadyExists() : base("Error: element with this name already exists") { }
        public ElementAlreadyExists(string name) : base("Error: element \"" + name + "\" already exists") { }
        public ElementAlreadyExists(string name, Exception inner) : base("Error: element \"" + name + "\" already exists", inner) { }
        protected ElementAlreadyExists(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
