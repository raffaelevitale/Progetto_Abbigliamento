namespace Progetto_Abbigliamento
{
    public class clsPantaloni : clsIndumenti
    {
        public string Tipo { get; set; } // jeans, felpati, leggins, classici
        public int Taglia { get; set; } // 44, 46, 48, 50, 52, 54, 56, 58, 60
        public string Lunghezza { get; set; } // lunghi, corti, pinocchietti
        public string Vestibilita { get; set; } // slim, skinny
    }

}
