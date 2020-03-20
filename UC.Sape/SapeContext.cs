using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;

namespace effetto.Sape
{
    [ParseChildren(true)]
    [ToolboxData("<{0}:SapeContext runat=server></{0}:SapeContext>")]
    public class SapeContext : SapeControl, INamingContainer 
    {
        private List<SapeContextLink> links;
        private Dictionary<String, SapeContextLink> linksWithStrings;


        public SapeContext()
        {

        }

        [Browsable(false), DefaultValue(null), PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(typeof(SapeContentTemplateItem))]
        public ITemplate Content { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Content != null)
            {
                Controls.Clear();
                SapeContentTemplateItem i = new SapeContentTemplateItem();
                Content.InstantiateIn(i);
                Controls.Add(i);
            }
            if (page != null)
            {
                links = page.GetContextLinks();
                PrecessKeys();
            }

        }
        private void PrecessKeys()
        {
            linksWithStrings = new Dictionary<String, SapeContextLink>();
            foreach (SapeContextLink l in links)
            {
                string text = l.RawLink;
                text = Regex.Replace(text, "<[^>]*>", "");
                linksWithStrings.Add(text, l);
            }
        }

        private string MakeContextLinks(string input)
        {
            if (linksWithStrings!=null)
                foreach (String key in linksWithStrings.Keys)
                {
                    input = input.Replace(key, linksWithStrings[key].RawLink);
                }
            return input;
        }
        public override Control FindControl(string id)
        {
            if (Controls.Count > 0)
            {
                SapeContentTemplateItem i = (SapeContentTemplateItem)Controls[0];
                return i.FindControl(id);
            }
            return null;
        }       
        protected override void RenderChildren(HtmlTextWriter writer)
        {            
            TextWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            base.RenderChildren(htmlWriter);
            if (IsSapeBot)
                writer.Write("<sape_index>");
            writer.Write(MakeContextLinks(stringWriter.ToString()));
            if (IsSapeBot)
                writer.Write("</sape_index>");
            if (IsSapeBot || config.ForceCheckCode.Value)
                writer.Write(host.ContextCheckCode);
        }
    }
    [ToolboxItem(false)]
    public class SapeContentTemplateItem : Control, INamingContainer
    {
    }
}
