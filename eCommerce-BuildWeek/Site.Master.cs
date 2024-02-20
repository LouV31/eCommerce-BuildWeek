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

                login.Style.Add("display", "flex");
                pannelloUtente.Style.Add("display", "none");
                backOffice.Style.Add("display", "none");
                string nome = (string)Session["nome"];
                string isAdmin = (string)Session["isAdmin"];
                if (!string.IsNullOrEmpty(nome))
                {
                    login.Style.Add("display", "none");
                    pannelloUtente.Style.Add("display", "flex");
                    benvenuto.InnerHtml = "Benvenuto " + nome;

                    if (isAdmin == "True")
                    {
                        backOffice.Style.Add("display", "block");

                    }
                }

            }

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(Request.RawUrl);
        }
    }
}