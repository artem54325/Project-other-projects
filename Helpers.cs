using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters.Xml.Extensions;

namespace ProjectAboutProjects
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class FormatReponseFilterAttribute : Attribute, IActionFilter
    {
        private enum FormatResponseType { Json, Xml, View, Unknown }
        private FormatResponseType _requestedType { get; set; }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var _result = (ObjectResult)filterContext.Result;
            switch (_requestedType)
            {

                case FormatResponseType.Json:
                    var data = new { Data = _result.Value };
                    filterContext.Result = new JsonResult(data);
                    break;
                case FormatResponseType.Xml:
                    filterContext.Result = new XmlResult(_result.Value);
                    break;
                case FormatResponseType.View:
                    filterContext.Result = new XmlResult(_result.Value);
                    break;

                case FormatResponseType.Unknown:
                default:
                    throw new InvalidOperationException("Uknown Content Type ain Accept Header");
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var _contentType = filterContext.HttpContext.Request.Headers["Accept"];

            switch (_contentType)
            {
                case string s when (s.Contains("application/json")):
                    _requestedType = FormatResponseType.Json;
                    break;
                case string e when (e.Contains("/xml")):
                    _requestedType = FormatResponseType.Xml;
                    break;
                case string e when (e.Contains("/html")):
                    _requestedType = FormatResponseType.Xml;
                    break;
                default:
                    throw new ArgumentException("Unknown Accept Type - dont know how to handle: " + _contentType);
            }
        }
    }
}
