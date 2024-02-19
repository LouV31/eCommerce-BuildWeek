using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace eCommerce_BuildWeek
{
    public partial class _Default : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Repeater1.DataSource = reader;
                Repeater1.DataBind();

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

            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);


            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = $"SELECT * FROM Prodotti WHERE idProdotto = {id}";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
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
                    carrello.Add(prodotto);
                    Session["carrello"] = carrello;
                    Response.Redirect(Request.RawUrl);

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