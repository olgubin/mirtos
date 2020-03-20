using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using UC.Core;

namespace UC.IpBlocking.BLL
{
    public class BlockIp : BaseEntity
    {
        public BlockIp()
        {
        }
        public string Ip { get; set; }
        public string Comment { get; set; }
        public DateTime DateLast { get; set; }
        public DateTime DateAdd { get; set; }
        public bool Block { get; set; }
    }
}