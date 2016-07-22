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
    public partial class AjaxProxy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = Request.QueryString["action"];
            if (action == "confirming")
            {
                AccountService service = new AccountService();
                var x = service.GetAllConfirmingBanks();
                var ser = new JavaScriptSerializer().Serialize(x);
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Write(ser);
            }

            if (action == "issuing")
            {
                AccountService service = new AccountService();
                var x = service.GetAllIssuingBanks();
                var ser = new JavaScriptSerializer().Serialize(x);
                Response.AppendHeader("Access-Control-Allow-Origin", "*");
                Response.Write(ser);
            }
        }
    }
}