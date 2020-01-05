using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters.Xml.Extensions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;

namespace ProjectAboutProjects
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class FormatReponseFilterAttribute : Attribute, IActionFilter
    {
        private enum FormatResponseType { Json, Xml, View, Unknown }
        private FormatResponseType _requestedType { get; set; }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var _result = (MyOjbectResult) filterContext.Result;
            switch (_requestedType)
            {
                //https://localhost:44342/api/Post/Search?id=qwe
                case FormatResponseType.Json:
                var data = new { Data = _result.Value };
                filterContext.Result = new JsonResult(data);
                break;
                case FormatResponseType.Xml:
                filterContext.Result = new XmlResult(_result.Value);
                break;
                case FormatResponseType.View:

                var v = new ViewResult
                {
                    ViewName = _result.View
                };

                ViewDataDictionary dataDictionary = new ViewDataDictionary(v.ViewData);
                dataDictionary.Add("Data", _result.Value);
                v.ViewData = dataDictionary;
                filterContext.Result = v;

                filterContext.ExceptionHandled = true;

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
                case string e when (e.Contains("/xml")):
                _requestedType = FormatResponseType.Xml;
                break;
                case string e when (e.Contains("/html")):
                _requestedType = FormatResponseType.View;
                break;
                case string s when (s.Contains("application/json")):
                default:
                _requestedType = FormatResponseType.Json;
                break;
            }

            _requestedType = FormatResponseType.View;//Убрать после

        }
    }

    public class MyOjbectResult : ObjectResult
    {
        public string View { get; set; }

        public MyOjbectResult(object value, string view) : base(value)
        {
            this.View = view;
        }
    }
}
