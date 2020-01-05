using System;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAboutProjects.Helpers
{
    public class MyOjbectResult: ObjectResult
    {
        public string View { get; set; }

        public MyOjbectResult(object value, string view):base(value)
        {
            this.View = view;
        }
    }
}
