using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                pwError.Visible = false;

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            try
            {

                conn.Open();
                string query = $"SELECT * FROM Utenti WHERE Email = '{TextEmail.Text}' AND Password = '{TextPassword.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    Session["indirizzo"] = reader["Indirizzo"].ToString();
                    Session["idUtente"] = reader["idUtente"].ToString();
                    Session["email"] = reader["Email"].ToString();
                    Session["password"] = reader["Password"].ToString();
                    Session["nome"] = reader["Nome"].ToString();
                    Session["isAdmin"] = reader["Admin"].ToString();

                    Response.Redirect("Default");
                }
                else
                {
                    if (!string.IsNullOrEmpty(TextPassword.Text))
                    {

                        lblRegistrati1.Visible = true;
                        LinkButton1.Visible = true;
                    }
                    else
                    {

                        pwError.Visible = true;
                    }


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