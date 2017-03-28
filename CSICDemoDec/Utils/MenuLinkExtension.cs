using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;


namespace CSICDemoDec.Utils
{

    public static class MenuLinkExtension
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string itemText, string actionName, string controllerName, MvcHtmlString[] childElements = null)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            string finalHtml;
            var linkBuilder = new TagBuilder("a");
            var liBuilder = new TagBuilder("li");

            if (childElements != null && childElements.Length > 0)
            {
                linkBuilder.MergeAttribute("href", "#");
                linkBuilder.AddCssClass("dropdown-toggle");
                linkBuilder.InnerHtml = itemText + " <b class=\"caret\"></b>";
                linkBuilder.MergeAttribute("data-toggle", "dropdown");
                var ulBuilder = new TagBuilder("ul");
                ulBuilder.AddCssClass("dropdown-menu");
                ulBuilder.MergeAttribute("role", "menu");
                foreach (var item in childElements)
                {
                    ulBuilder.InnerHtml += item + "\n";
                }

                liBuilder.InnerHtml = linkBuilder + "\n" + ulBuilder;
                liBuilder.AddCssClass("dropdown");
                if (controllerName == currentController)
                {
                    liBuilder.AddCssClass("active");
                }

                finalHtml = liBuilder.ToString() + ulBuilder;
            }
            else
            {
                var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
                linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, controllerName));
                linkBuilder.SetInnerText(itemText);
                liBuilder.InnerHtml = linkBuilder.ToString();
                if (controllerName == currentController && actionName == currentAction)
                {
                    liBuilder.AddCssClass("active");
                }

                finalHtml = liBuilder.ToString();
            }

            return new MvcHtmlString(finalHtml);
        }
    }
}