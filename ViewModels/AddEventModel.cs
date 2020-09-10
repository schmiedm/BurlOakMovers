using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BurlOakMovers.ViewModels
{
    public class AddEventModel
    {
        public int EventId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ThemeColor { get; set; }
        public bool FullDay { get; set; } 
    }
}