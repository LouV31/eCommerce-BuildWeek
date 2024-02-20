using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace eCommerce_BuildWeek
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            if (carrello != null && carrello.Count > 0)
            {
                alert.Style.Add("display", "none");



                Repeater2.DataSource = carrello;
                Repeater2.DataBind();

                CalcoloTotale(carrello);
            }
            else
            {
                alert.Style.Add("display", "block");
                alert.InnerHtml = "Nessun articolo nel carrello";
            }
        }

        protected void rimuoviCarrello_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rimuoviId = Convert.ToInt32(btn.CommandArgument);
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            Prodotti prodotto = carrello.Find(p => p.Id == rimuoviId);
            if (prodotto != null)
            {
                carrello.Remove(prodotto);
            }
            Response.Redirect(Request.RawUrl);

        }

        protected void CalcoloTotale(List<Prodotti> carrello)
        {
            double Totale = 0;
            foreach (Prodotti prodotto in carrello)
            {
                Totale += prodotto.Prezzo;

                // controllo articoli > 1

                contoTotale.InnerHtml = "Totale provvisorio: " + Totale.ToString("0.00") + "€";

                if (carrello.Count > 1)
                    contoTotale.InnerHtml += " (" + carrello.Count + " articoli)";
                else
                    contoTotale.InnerHtml += " (" + carrello.Count + " articolo)";

            }

            procediOrdine.Visible = true;
        }
    }
}