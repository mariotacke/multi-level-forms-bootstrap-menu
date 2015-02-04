using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

// adapted from:
// https://jeremyknight.wordpress.com/2014/02/25/asp-net-forms-bootstrap-menu-control/
// https://codelibrary.codeplex.com/SourceControl/latest#Main/Source/DL.Core.Web/Controls/BootstrapMenu.cs
namespace MultiLevelFormsBootstrapMenu
{
    [ControlValueProperty("SelectedValue")]
    [DefaultEvent("MenuItemClick")]
    [SupportsEventValidation]
    [ToolboxData("<{0}:BootstrapMenu runat=\"server\"></{0}:BootstrapMenu>")]
    public sealed class BootstrapMenu : Menu
    {
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            // don't call base.RenderBeginTag()
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            // don't call base.RenderEndTag()
        }

        protected override void OnPreRender(EventArgs e)
        {
            // don't call base.OnPreRender(e);
            this.EnsureDataBound();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            this.BuildItems(writer, this.Items, true);
        }

        protected override void EnsureDataBound()
        {
            base.EnsureDataBound();
        }

        private void BuildItems(HtmlTextWriter writer, MenuItemCollection items, bool isRoot = false)
        {
            if (items.Count <= 0)
            {
                return;
            }

            string cssClass = "dropdown-menu";

            if (isRoot)
            {
                cssClass = "nav navbar-nav";

                // append any css that previously existed
                if (!string.IsNullOrEmpty(this.CssClass))
                {
                    cssClass += " " + this.CssClass;
                }
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            foreach (MenuItem item in items)
            {
                this.BuildItem(writer, item);
            }

            writer.RenderEndTag(); // </ul>
        }

        private void BuildItem(HtmlTextWriter writer, MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            if (this.HasChildren(item))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, 
                    item.Depth < this.StaticDisplayLevels 
                    ? "dropdown" : "dropdown-submenu");
            }

            writer.RenderBeginTag(HtmlTextWriterTag.Li);

            if (this.IsLink(item) && this.HasChildren(item))
            {
                this.RenderDropDown(writer, item);
            }
            else
            if (this.IsLink(item))
            {
                this.RenderLink(writer, item);
            }
            else 
            if (this.HasChildren(item))
            {
                this.RenderDropDown(writer, item);
            }
            else
            {
                writer.RenderBeginTag(HtmlTextWriterTag.A);
                writer.Write(item.Text);
                writer.RenderEndTag();
            }

            writer.RenderEndTag(); // </li>
        }

        private void RenderLink(HtmlTextWriter writer, MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Href, this.GetLink(item));

            string toolTip = !string.IsNullOrEmpty(item.ToolTip)
                ? item.ToolTip
                : item.Text;
            writer.AddAttribute(HtmlTextWriterAttribute.Title, toolTip);

            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(item.Text);
            writer.RenderEndTag(); // </a>
        }

        private void RenderDropDown(HtmlTextWriter writer, MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "dropdown-toggle");
            writer.AddAttribute("data-toggle", "dropdown");
            writer.RenderBeginTag(HtmlTextWriterTag.A);

            string anchorValue = item.Text + "&nbsp;";
            writer.Write(anchorValue);

            if (item.Depth < this.StaticDisplayLevels)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "caret");
            }

            writer.RenderBeginTag(HtmlTextWriterTag.B);
            writer.RenderEndTag(); // </b>          

            writer.RenderEndTag(); // </a>

            this.BuildItems(writer, item.ChildItems);
        }

        private bool HasChildren(MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.ChildItems.Count > 0;
        }

        private bool IsLink(MenuItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return item.Enabled && !string.IsNullOrEmpty(item.NavigateUrl);
        }

        private string GetLink(MenuItem item)
        {
            return !string.IsNullOrEmpty(item.NavigateUrl)
                ? this.Page.Server.HtmlEncode(this.ResolveClientUrl(item.NavigateUrl))
                : this.Page.ClientScript.GetPostBackClientHyperlink(
                    this,
                    "b" + item.ValuePath.Replace(this.PathSeparator.ToString(), "\\"),
                    true);
        }
    }
}