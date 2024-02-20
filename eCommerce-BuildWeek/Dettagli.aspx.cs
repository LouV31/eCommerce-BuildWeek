using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Dettagli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            Response.Write(Request.QueryString["IdProdotto"]);
            try
            {
                conn.Open();
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    string query = $"SELECT * FROM Prodotti WHERE idProdotto = {Convert.ToInt32(Request.QueryString["IdProdotto"])}";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        alert.Style.Add("display", "none");
                        Immagine.Src = reader["Immagine"].ToString();
                        Nome.InnerHtml = reader["Nome"].ToString();
                        Descrizione.InnerHtml = reader["Descrizione"].ToString();
                        // aggiunto euro convertito per leggere solo 2 decimali
                        Prezzo.InnerHtml = "€" + Convert.ToDouble(reader["Prezzo"]).ToString("0.00");


                        // aggiunto if per la disponibilità
                        if (Convert.ToInt32(reader["Unita"]) > 0)
                        {
                            Disponibilita.InnerHtml = "Disponibile";
                            Disponibilita.Style.Add("color", "green");
                        }
                        else
                        {
                            Disponibilita.InnerHtml = "Non disponibile";
                            Disponibilita.Style.Add("color", "red");
                        }

                        //categoria
                        Categoria.InnerHtml = reader["Categoria"].ToString();
                    }
                    else
                    {
                        alert.Style.Add("display", "block");
                        alert.InnerHtml = "Prodotto non trovato";

                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
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

        protected void aggiungiCarrello_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["IdProdotto"]);
                    conn.Open();
                    string query = $"SELECT * FROM Prodotti WHERE idProdotto = {id}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int quantità = Convert.ToInt32(Quantità.Text);

                        Prodotti prodotto = new Prodotti(Convert.ToInt32(reader["idProdotto"]), reader["Nome"].ToString(), reader["Descrizione"].ToString(), Convert.ToDouble(reader["Prezzo"]), Convert.ToInt32(reader["Unita"]), reader["Categoria"].ToString(), reader["Immagine"].ToString());
                        List<Prodotti> carrello;
                        if (Session["carrello"] == null)
                        {
                            carrello = new List<Prodotti>();
                        }
                        else
                        {
                            carrello = (List<Prodotti>)Session["carrello"];
                        }


                        for (int i = 0; i < quantità; i++)
                        {
                            carrello.Add(prodotto);
                        }

                        Session["carrello"] = carrello;
                        Response.Redirect(Request.RawUrl);
                    }
                }
                else
                {
                    Response.Write("Prodotto non trovato");
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