using System.Collections.Generic;

namespace eCommerce_BuildWeek
{
    public class Prodotti
    {
        private int id;
        public int Id { get => id; set => id = value; }
        private string nome;
        public string Nome { get => nome; set => nome = value; }
        private string descrizione;
        public string Descrizione { get => descrizione; set => descrizione = value; }
        private double prezzo;
        public double Prezzo { get => prezzo; set => prezzo = value; }
        private int unita;
        public int Unita { get => Unita; set => Unita = value; }
        private string categoria;
        public string Categoria { get => Categoria; set => Categoria = value; }
        private string immagine;
        public string Immagine { get => Immagine; set => Immagine = value; }

        private static List<Prodotti> ListaProdotti = new List<Prodotti>();
        public static List<Prodotti> GetProdotti()
        {
            return ListaProdotti;
        }
        public static void AggiungiProdotto(Prodotti prodotto)
        {
            ListaProdotti.Add(prodotto);
        }
        public static void RimuoviProdotto(Prodotti prodotto)
        {
            ListaProdotti.Remove(prodotto);
        }

        public static void SvuotaProdotti(Prodotti prodotto)
        {
            ListaProdotti.Clear();
        }

        public Prodotti(int id, string nome, string descrizione, double prezzo, int unita, string categoria, string immagine)
        {
            this.id = id;
            this.nome = nome;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
            this.unita = unita;
            this.categoria = categoria;
            this.immagine = immagine;
        }






        public static Prodotti TrovaProdotto(int id)
        {
            foreach (Prodotti prodotto in ListaProdotti)
            {
                if (prodotto.id == id)
                {
                    return prodotto;
                }
            }
            return null;
        }
    }




}
