﻿using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class InfoUtente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int idUtente = Convert.ToInt32(Request.QueryString["utente"]);
                SqlConnection conn = Connection.ConnectionString();
                try
                {
                    conn.Open();
                    string query = $"SELECT * FROM Utenti WHERE idUtente = {idUtente}";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {


                        Nome.Text = reader["Nome"].ToString();
                        Cognome.Text = reader["Cognome"].ToString();
                        Email.Text = reader["Email"].ToString();
                        Password.Text = reader["Password"].ToString();
                        Indirizzo.Text = reader["Indirizzo"].ToString();
                        Citta.Text = reader["Citta"].ToString();
                        Cap.Text = reader["Cap"].ToString();
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


                SqlConnection ordiniConnection = Connection.ConnectionString();
                try
                {
                    ordiniConnection.Open();
                    //string query = $"SELECT "

                }
                catch (Exception ex)
                {
                    Response.Write("Error: ");
                    Response.Write(ex.Message);
                }
                finally
                {
                    ordiniConnection.Close();
                }
            }
        }

        protected void Modifica_Click(object sender, EventArgs e)
        {
            string idUtente = Request.QueryString["utente"];
            SqlConnection conn = Connection.ConnectionString();
            try
            {
                conn.Open();
                string query = $"UPDATE Utenti SET Nome = '{Nome.Text}', Cognome = '{Cognome.Text}', Email = '{Email.Text}', Password = '{Password.Text}', Indirizzo = '{Indirizzo.Text}', Citta = '{Citta.Text}', Cap = '{Cap.Text}' WHERE idUtente = {idUtente}";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Response.Redirect("Default.aspx");
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