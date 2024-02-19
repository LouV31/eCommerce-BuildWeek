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


    }
}