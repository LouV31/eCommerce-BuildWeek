using System;
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
                        Prezzo.InnerHtml = reader["Prezzo"].ToString();
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
    }
}