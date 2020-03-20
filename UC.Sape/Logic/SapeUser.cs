using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace effetto.Sape
{
    public class SapeUser
    {
        public String Id;

        public SapeHost GetHost(string host)
        {
            return SapeFactory.Factory.GetHost(this, host);
        }
        public SapeHost GetHost()
        {
            return SapeFactory.Factory.GetHost(this);
        }
    }
}
