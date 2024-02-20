using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Modifica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string isAdmin = (string)Session["isAdmin"];
                if (isAdmin != "True")
                {
                    Response.Redirect("Default");
                }
                string idProdotto = Request.QueryString["ProdottoId"];
                if (idProdotto != null)
                {
                    Connection.ConnectionString();
                    SqlConnection conn = Connection.ConnectionString();
                    try
                    {
                        conn.Open();
                        string query = $"SELECT * FROM Prodotti WHERE idProdotto = {idProdotto}";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            img.ImageUrl = reader["Immagine"].ToString();
                            Nome.Text = reader["Nome"].ToString();
                            Descrizione.Text = reader["Descrizione"].ToString();
                            Prezzo.Text = reader["Prezzo"].ToString();
                            Unita.Text = reader["Unita"].ToString();
                            Categoria.Text = reader["Categoria"].ToString();
                            Immagine.Text = reader["Immagine"].ToString();
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

        protected void invioModifica_Click(object sender, EventArgs e)
        {
            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = $"UPDATE Prodotti SET Nome = '{Nome.Text}', Descrizione = '{Descrizione.Text}', Prezzo = {Convert.ToDouble(Prezzo.Text.Replace(",", "."))}, Unita = {Convert.ToInt32(Unita.Text)}, Categoria = '{Categoria.Text}', Immagine = '{Immagine.Text}' WHERE idProdotto = {Request.QueryString["ProdottoId"]}";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Response.Redirect("backOffice");
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