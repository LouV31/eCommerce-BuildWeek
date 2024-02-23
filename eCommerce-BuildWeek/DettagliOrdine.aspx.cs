using System;
using System.Data.SqlClient;

namespace eCommerce_BuildWeek
{
    public partial class DettagliOrdine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nome = (string)Session["nome"];
            if (string.IsNullOrEmpty(nome))
            {
                Response.Redirect("Default");
            }

            SqlConnection conn = Connection.ConnectionString();
            string idOrdine = Request.QueryString["ordineId"];
            try
            {
                conn.Open();

                if (!string.IsNullOrEmpty(Request.QueryString["ordineId"]))
                {
                    string SingleOrdineQuery = $"SELECT D.FK_IdOrdine, D.FK_IdProdotto, D.Quantita, D.PercorsoImmagine,  P.Nome, P.Prezzo * D.Quantita AS TOTALE FROM DettagliOrdini AS D JOIN Prodotti AS P ON P.idProdotto = D.FK_IdProdotto WHERE D.FK_IdOrdine = {idOrdine}";

                    SqlCommand cmd = new SqlCommand(SingleOrdineQuery, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DettagliOrdiniRep.DataSource = reader;
                    DettagliOrdiniRep.DataBind();
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
