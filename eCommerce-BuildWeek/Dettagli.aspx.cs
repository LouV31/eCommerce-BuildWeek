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

            try
            {
                conn.Open();
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    string query =
                        $"SELECT * FROM Prodotti WHERE idProdotto = {Convert.ToInt32(Request.QueryString["IdProdotto"])}";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        alert.Style.Add("display", "none");
                        Immagine.Src = reader["Immagine"].ToString();
                        Nome.InnerHtml = reader["Nome"].ToString();
                        Descrizione.InnerHtml = reader["Descrizione"].ToString();
                        // aggiunto euro convertito per leggere solo 2 decimali
                        Prezzo.InnerHtml =
                            "€" + Convert.ToDouble(reader["Prezzo"]).ToString("0.00");

                        // aggiunto if per la disponibilità
                        if (Convert.ToInt32(reader["Unita"]) < 1)
                        {
                            Disponibilita.InnerHtml = "Non disponibile";
                            Disponibilita.Style.Add("color", "red");
                            aggiungiCarrello.Enabled = false;
                            Quantità.Enabled = false;
                        }
                        else if ((Convert.ToInt32(reader["Unita"]) < 5))
                        {
                            Disponibilita.InnerHtml = "Ultimi pezzi !";
                            Disponibilita.Style.Add("color", "#CD8626");
                        }
                        else
                        {
                            Disponibilita.InnerHtml = "Disponibile";
                            Disponibilita.Style.Add("color", "green");
                        }

                        //categoria
                        Categoria.InnerHtml = reader["Categoria"].ToString();
                    }
                    else
                    {
                        alert.Style.Add("display", "block");
                        alert.InnerHtml = "Prodotto non trovato";
                    }

                    string categoria = reader["Categoria"].ToString();
                    string querySimili =
                        "SELECT * FROM Prodotti WHERE Categoria = @Categoria AND idProdotto != @IdProdotto";

                    SqlCommand cmdSimili = new SqlCommand(querySimili, conn);

                    cmdSimili.Parameters.AddWithValue("@Categoria", categoria);
                    cmdSimili.Parameters.AddWithValue(
                        "@IdProdotto",
                        Convert.ToInt32(Request.QueryString["IdProdotto"])
                    );
                    reader.Close();
                    SqlDataReader readerSimili = cmdSimili.ExecuteReader();
                    Repeater10.DataSource = readerSimili;
                    Repeater10.DataBind();
                    readerSimili.Close();
                    //se vogliamo, ma non vogliamo qua si puo fare for per limitare correlati a 3.
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
                        string immagineSkin = Session["immagineProdotto"] != null ? Session["immagineProdotto"].ToString() : null;

                        string immagineProdotto = string.IsNullOrEmpty(Mimetica.SelectedValue) ? reader["Immagine"].ToString() : immagineSkin;



                        int quantità = Convert.ToInt32(Quantità.Text);

                        Prodotti prodotto = new Prodotti(Convert.ToInt32(reader["idProdotto"]), reader["Nome"].ToString(), reader["Descrizione"].ToString(), Convert.ToDouble(reader["Prezzo"]), Convert.ToInt32(reader["Unita"]), reader["Categoria"].ToString(), immagineProdotto);
                        List<Prodotti> carrello;
                        if (Session["carrello"] == null)
                        {
                            carrello = new List<Prodotti>();
                        }
                        else
                        {
                            carrello = (List<Prodotti>)Session["carrello"];
                        }

                        // Cerca il prodotto nel carrello
                        Prodotti prodottoEsistente = carrello.Find(p => p.Id == prodotto.Id && p.Immagine == prodotto.Immagine);
                        if (prodottoEsistente != null)
                        {
                            // Se il prodotto esiste, aumenta la quantità
                            prodottoEsistente.QuantityInCart += quantità;
                        }
                        else
                        {
                            // Se il prodotto non esiste, aggiungi al carrello
                            prodotto.QuantityInCart = quantità;
                            carrello.Add(prodotto);
                        }

                        Session["carrello"] = carrello;
                        //Session.Remove("immagineProdotto");
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

        protected void Mimetica_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                if (!string.IsNullOrEmpty(Request.QueryString["IdProdotto"]))
                {
                    string valoreSelezionato = Mimetica.SelectedValue;
                    Session["immagineProdotto"] = valoreSelezionato;



                    string query =
                        $"SELECT * FROM ProdottiColori WHERE idProdotto = {Convert.ToInt32(Request.QueryString["IdProdotto"])} AND NomeColore = '{valoreSelezionato}'";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Immagine.Src = reader["PercorsoImmagine"].ToString();
                        string immagine = reader["PercorsoImmagine"].ToString();
                        Session["immagineProdotto"] = immagine;


                    }
                    else
                    {
                        alert.Style.Add("display", "block");
                        alert.InnerHtml = "Colore non disponibile";
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
    }
}
