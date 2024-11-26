namespace Progetto_Abbigliamento
{
    public class clsMaglie : clsIndumenti
    {
        public string Tipo { get; set; } // felpa, t-shirt, polo, canotta
        public string Taglia { get; set; } // XS, S, M, L, XL, XXL, XXXL
        public string Manica { get; set; } // Lunga, Corta, MezzaManica, Smanicata
        public string Apertura { get; set; } // Zip, bottoni, velcro, senza
    }

}
