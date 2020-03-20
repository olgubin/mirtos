using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace effetto.Sape
{
    [Serializable]    
    public class SapeLinkBase
    {
        public String RawLink { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

            return ((SapeLinkBase)obj).RawLink == RawLink;
        }
        public override int GetHashCode()
        {
            return RawLink.GetHashCode();
        }
    }
}
