using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace eCommerce_BuildWeek
{
    public partial class backOffice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




            string isAdmin = (string)Session["isAdmin"];
            if (isAdmin != "True")
            {
                Response.Redirect("Default");
            }

            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotti";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                backOfficeRepeater.DataSource = reader;
                backOfficeRepeater.DataBind();
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

        protected void Rimuovi_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int idProdotto = Convert.ToInt32(button.CommandArgument);

            Connection.ConnectionString();
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = $"DELETE FROM Prodotti WHERE idProdotto = {idProdotto}";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Response.Redirect(Request.RawUrl);
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

        /*protected void Button1_Click(object sender, EventArgs e)
        {


            LinkButton button = (LinkButton)sender;
            int idProdotto = Convert.ToInt32(button.CommandArgument);
            System.Diagnostics.Debug.WriteLine("Ciao: " + idProdotto);
            Response.Write("Ciao: " + idProdotto);
            scriviqualcosa.InnerHtml = idProdotto.ToString();
            Rimuovi.CommandArgument = idProdotto.ToString();

        }*/
    }
}