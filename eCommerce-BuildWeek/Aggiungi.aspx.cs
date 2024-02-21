using System;
using System.Data.SqlClient;
using System.Globalization;

namespace eCommerce_BuildWeek
{
    public partial class Aggiungi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string isAdmin = (string)Session["isAdmin"];
            if (isAdmin != "True")
            {
                Response.Redirect("Default");
            }
        }

        protected void invioAggiungi_Click(object sender, EventArgs e)
        {
            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string prezzoText = Prezzo.Text.Replace(",", ".");
                double prezzo = double.Parse(prezzoText, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                string query = $"INSERT INTO Prodotti (Nome, Descrizione, Prezzo, Unita, Categoria, Immagine) VALUES ('{Nome.Text}', '{Descrizione.Text}', {prezzo.ToString(CultureInfo.InvariantCulture)}, {Convert.ToInt32(Unita.Text)}, '{Categoria.Text}', '{Immagine.Text}')";
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