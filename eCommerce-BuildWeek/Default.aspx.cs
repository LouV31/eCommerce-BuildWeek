using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void aggiungiCarrello_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int id = Convert.ToInt32(btn.CommandArgument);
            Prodotti questoProdotto = Prodotti.TrovaProdotto(id);
            Prodotti.AggiungiProdotto(questoProdotto);

            if (Session["carrello"] == null)
            {
                Session["carrello"] = new List<Prodotti>();
            }


            //Articolo questoArticolo = Articolo.TrovaArticolo(id);
            //Articolo.AggiungiCarrello(questoArticolo);




        }
    }
}