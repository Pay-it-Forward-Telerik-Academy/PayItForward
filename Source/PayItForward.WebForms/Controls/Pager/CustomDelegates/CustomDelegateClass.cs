using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayItForward.WebForms.Controls.Pager.CustomDelegates
{
    public partial class CustomDelegateClass
    {
        public delegate void PageChangedEventHandler(object sender, CustomPageChangeArgs e);
    }
}