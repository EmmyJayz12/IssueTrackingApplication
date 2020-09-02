using System;

namespace IssueTrackingApplication1.Models
{
    internal class SqlDefaultValueAttribute : Attribute
    {
        public string Defaultvalue { get; set; }
    }
}