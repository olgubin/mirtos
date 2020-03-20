using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

namespace UC
{
    public class TreeViewState
    {
        public void SaveTreeView(TreeView treeView, string key)
        {
            List<string> list = new List<string>();
            SaveTreeViewExpandedState(treeView.Nodes, list);
            HttpContext.Current.Session[key + treeView.ID] = list;
        }

        public void TreeViewCollapsed(TreeView treeView, string Value, string key)
        {
            List<string> list = (List<string>)HttpContext.Current.Session[key + treeView.ID] ?? new List<string>();
            if (list != null)
            {
                if (list.Remove(Value))
                    HttpContext.Current.Session[key + treeView.ID] = list;
            }
        }

        public void TreeViewExpanded(TreeView treeView, string Value, string key)
        {
            List<string> list = (List<string>)HttpContext.Current.Session[key + treeView.ID] ?? new List<string>();
            if (list != null)
            {
                list.Add(Value);
                HttpContext.Current.Session[key + treeView.ID] = list;
            }
        }

        private int RestoreTreeViewIndex;

        public void RestoreTreeView(TreeView treeView, string key)
        {
            RestoreTreeViewIndex = 0;
            RestoreTreeViewExpandedState(treeView.Nodes,
                (List<string>)HttpContext.Current.Session[key + treeView.ID] ?? new List<string>());
        }

        private void SaveTreeViewExpandedState(TreeNodeCollection nodes, List<string> list)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Expanded==true)
                    list.Add(node.Value);
                if (node.ChildNodes.Count > 0)
                {
                    SaveTreeViewExpandedState(node.ChildNodes, list);
                }
            }
        }

        private void RestoreTreeViewExpandedState(TreeNodeCollection nodes, List<string> list)
        {
            foreach (TreeNode node in nodes)
            {
                if (list.Exists(delegate(string value) { return (value == node.Value); }))
                    node.Expanded = true;

                if (node.ChildNodes.Count > 0)
                {
                    RestoreTreeViewExpandedState(node.ChildNodes, list);
                }
            }
        }
    }
}
