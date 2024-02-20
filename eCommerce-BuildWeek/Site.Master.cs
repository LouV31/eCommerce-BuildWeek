using System;
using System.Collections.Generic;
using System.Web.UI;

namespace eCommerce_BuildWeek
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
                if (carrello != null && carrello.Count > 0)
                {
                    badge.Style.Add("display", "block");
                    carrelloCount.Text = carrello.Count.ToString();
                }
                else
                {
                    badge.Style.Add("display", "none");
                }

            }
        }
    }
}