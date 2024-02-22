using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();

                string categoria = Request.QueryString["categoria"];

                if (categoria != null)
                {

                    switch (categoria.ToLower())
                    {
                        case "mitraglietta":
                            categoryHeading.InnerText = "Mitraglietta";
                            categoryBanner.Src = "../Content/assets/banner-2.png";
                            break;
                        case "pistola":
                            categoryHeading.InnerText = "Pistola";
                            categoryBanner.Src = "../Content/assets/banner-3.png";
                            break;
                        case "fucile d'assalto":
                            categoryHeading.InnerText = "Fucile d'assalto";
                            categoryBanner.Src = "../Content/assets/banner-1.png";
                            break;
                        default:
                            categoryHeading.InnerText = "Nessun articolo disponibile per questa categoria";
                            break;
                    }
                }
                else
                {
                    categoryHeading.InnerText = "Tutti gli articoli";
                    categoryBanner.Src = "./Content/assets/banner-0.png";
                }



                if (categoria == null)
                {
                    string query = "SELECT * FROM Prodotti";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
                else
                {
                    string query = "SELECT * FROM Prodotti WHERE Categoria = @categoria";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
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