using System;
using System.Collections.Generic;
using System.Text;

namespace Task8SpecFlow.Spec
{
    public class TestSettings
    {
        public static string MainUrl { get;  } = "http://automationpractice.com/";
        public static string CatalogPageUrl { get; } = "http://automationpractice.com/index.php?controller=search&search_query=Summer&submit_search=&orderby=position&orderway=asc";
        public static string CatalogSortPageUrl { get; } = "http://automationpractice.com/index.php?controller=search&search_query=Summer&submit_search=&orderby=price&orderway=desc";
        public static string CartPageUrl { get; } = "http://automationpractice.com/index.php?controller=order";

        public static string CurrentUrl { get; set; }
        public static string FirstItemName { get; set; }
        public static string FirstItemPrice { get; set; }
    }
}
