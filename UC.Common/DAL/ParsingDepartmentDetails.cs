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

namespace UC.DAL
{
    public class ParsingDepartmentDetails
    {
        public ParsingDepartmentDetails() { }

        public ParsingDepartmentDetails(int id, List<ParsingDepartmentDetails> departments, string title, string url)
        {
            this.ID = id;
            this.Departments = departments;
            this.Title = title;
            this.Url = url;
        }

        private int _id = 0;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private List<ParsingDepartmentDetails> _departments;
        public List<ParsingDepartmentDetails> Departments
        {
            get { return _departments; }
            set { _departments = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _url = "";
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
    }
}