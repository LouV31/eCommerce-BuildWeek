using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            alert.Style.Add("display", "none");
        }

        protected void Registrati_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = $"SELECT * FROM Utenti WHERE Email = '{TextEmail.Text}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    alert.Style.Add("display", "block");
                    alert.InnerHtml = "Utente già registrato";
                }
                else
                {
                    SqlConnection conn2 = Connection.ConnectionString();
                    try
                    {
                        conn2.Open();

                        if (
                            TextName.Text == ""
                            || TextName.Text == ""
                            || TextEmail.Text == ""
                            || TextPassword.Text == ""
                        )
                        {
                            alert.Style.Add("display", "block");
                            alert.InnerHtml =
                                "I seguenti campi sono obbligatori: Nome, Cognome, Email, Password";
                        }

                        string query2 =
                            $"INSERT INTO Utenti(Nome, Cognome, Email, Password, Indirizzo, Citta, Cap) VALUES('{TextName.Text}', '{TextCognome.Text}', '{TextEmail.Text}', '{TextPassword.Text}', '{TextInirizzo.Text}', '{TextCittà.Text}', '{TextCap.Text}'); ";
                        SqlCommand cmd2 = new SqlCommand(query2, conn2);
                        cmd2.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: ");
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        conn2.Close();
                        TextCap.Text = string.Empty;
                        TextCittà.Text = string.Empty;
                        TextCognome.Text = string.Empty;
                        TextEmail.Text = string.Empty;
                        TextInirizzo.Text = string.Empty;
                        TextName.Text = string.Empty;
                        TextPassword.Text = string.Empty;
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
