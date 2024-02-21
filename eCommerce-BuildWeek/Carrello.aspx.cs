using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace eCommerce_BuildWeek
{
    public partial class Carrello : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
                if (carrello != null && carrello.Count > 0)
                {
                    alert.Style.Add("display", "none");
                    Repeater2.DataSource = carrello;
                    Repeater2.DataBind();
                    CalcoloTotale(carrello);
                    Session["Totale"] = CalcoloTotale(carrello);
                }
                else
                {
                    alert.Style.Add("display", "block");
                    alert.InnerHtml = "Nessun articolo nel carrello";
                }
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

        protected double CalcoloTotale(List<Prodotti> carrello)
        {
            double Totale = 0;
            foreach (Prodotti prodotto in carrello)
            {
                Totale += prodotto.Prezzo;
            }

            contoTotale.InnerHtml = "Totale provvisorio: " + Totale.ToString("0.00") + "€";
            if (carrello.Count > 1)
            {
                contoTotale.InnerHtml += " (" + carrello.Count + " articoli)";
            }
            else
            {
                contoTotale.InnerHtml += " (" + carrello.Count + " articolo)";
            }
            procediOrdine.Visible = true;
            return Totale;
        }

        protected void procediOrdine_Click(object sender, EventArgs e)
        {
            List<Prodotti> carrello = (List<Prodotti>)Session["carrello"];
            int idUtente = Convert.ToInt32(Session["idUtente"]);
            SqlConnection conn = Connection.ConnectionString();
            if (idUtente != 0)
            {
                string indirizzo = Session["indirizzo"].ToString();
                decimal totale = Convert.ToDecimal(Session["Totale"]);
                try
                {
                    conn.Open();
                    string query = "Insert into Ordini (FK_IdUtente, Indirizzo_Spedizione, Totale) VALUES (@idUtente, @indirizzo, @totale)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@idUtente", idUtente);
                    cmd.Parameters.AddWithValue("@indirizzo", indirizzo);
                    cmd.Parameters.AddWithValue("@totale", totale);
                    cmd.ExecuteNonQuery();
                    SqlConnection conn2 = Connection.ConnectionString();
                    try
                    {
                        conn2.Open();
                        string idOrdineQuery = $"SELECT idOrdine FROM Ordini WHERE FK_IdUtente = {idUtente} ORDER BY idOrdine DESC";
                        SqlCommand getIdOrdineCmd = new SqlCommand(idOrdineQuery, conn2);
                        int idOrdine = (int)getIdOrdineCmd.ExecuteScalar();
                        foreach (Prodotti prodotto in carrello)
                        {
                            string query2 = $"INSERT INTO DettagliOrdini (FK_IdOrdine, FK_IdProdotto, Quantita) VALUES ( {idOrdine}, {prodotto.Id}, 1)";
                            SqlCommand cmd2 = new SqlCommand(query2, conn2);
                            cmd2.ExecuteNonQuery();
                        }
                        Session.Remove("carrello");
                        Response.Redirect(Request.RawUrl);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: ");
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        conn2.Close();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error: ");
                    Response.Write(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
