using System;
using System.Data.SqlClient;
using System.Web.UI;


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

                string categoria = Request.QueryString["categoria"];


                if (categoria == null)
                {
                    string query = "SELECT * FROM Prodotti";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    return;
                }

                if (categoria != null)
                {
                    string query = "SELECT * FROM Prodotti WHERE Categoria = @categoria";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    return;
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