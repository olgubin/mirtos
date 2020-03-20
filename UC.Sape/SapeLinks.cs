using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Linq;
using System.Net;

namespace effetto.Sape
{
    [ToolboxData("<{0}:SapeLinks runat=server></{0}:SapeLinks>")]
    public class SapeLinks : SapeControl
    {
        private List<SapeLink> links;

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        [DefaultValue(0)]
        public byte Priority { get; set; }

        [Bindable(true)]
        [Category("Data")]
        [Localizable(false)]
        [DefaultValue(255)]
        public byte Capacity { get; set; }   

        public SapeLinks()
        {
            Capacity = 255;

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (page != null)
            {
                if (Context.Items["SapePageLinks"] == null)
                {
                    Context.Items["SapePageLinks"] = page.GetLinks();
                }
            }
            if (Context.Items["SapePageLinkControls"] == null)
            {
                Context.Items["SapePageLinkControls"] = new List<SapeLinks>();
            }
            ((List<SapeLinks>)Context.Items["SapePageLinkControls"]).Add(this);
            links = new List<SapeLink>();
        }
        protected override void OnLoad(EventArgs e)
        {
            List<SapeLinks> controls = (List<SapeLinks>)Context.Items["SapePageLinkControls"];
            List<SapeLink> allLinks = (List<SapeLink>)Context.Items["SapePageLinks"];
            if (allLinks == null) return;
            var result = from c in controls orderby c.Priority descending select c;
            while (allLinks.Count != 0)
            {                
                SapeLink link = allLinks[0];
                SapeLinks control = null;
                foreach (SapeLinks c in result)
                {
                    if (c.Capacity > c.links.Count)
                    {
                        control = c;
                        break;
                    }                    
                }
                if (control != null)
                {
                    allLinks.RemoveAt(0);
                    control.links.Add(link);
                }
                else
                {
                    break;
                }
            }
            
            base.OnLoad(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            if (IsSapeBot)
                writer.Write("<sape_noindex>");
            foreach (SapeLink l in this.links)
            {
                writer.Write(l.RawLink);
                writer.Write(host.Delimiter);
            }
            if (IsSapeBot)
                writer.Write("</sape_noindex>");
            if (IsSapeBot || config.ForceCheckCode.Value)
                writer.Write(host.CheckCode);
        }
    }
}
