using System.Collections.Generic;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        public static string Icon(this HtmlHelper htmlHelper, string iconName)
        {
            var tag = new TagBuilder("i");
            tag.AddCssClass(iconName);

            return tag.ToString();
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml)
        {
            return Button(helper, innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(null));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, object htmlAttributes)
        {
            return Button(helper, innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string innerHtml, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button") { InnerHtml = innerHtml };
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        //TODO - ESTA FUNCIONANDO, MAS PODE SER MELHOR
        //public static MvcHtmlString DropDownMunicipioSelect2For(this HtmlHelper helper, string id = "")
        //{
        //    var format = $"<select id=\'{id}\' style=\'width: 300px\'>";
        //    format += "<option></option>";
        //    format += "</select>";
        //    return MvcHtmlString.Create(format);
        //}
    }
}