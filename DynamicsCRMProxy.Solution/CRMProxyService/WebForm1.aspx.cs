using CRMProxyService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRMProxyService
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccountService service = new AccountService();
            var x = service.GetAllConfirmingBanks();
            var ser = new JavaScriptSerializer().Serialize(x);
            Response.Write(ser);
        }
    }
}