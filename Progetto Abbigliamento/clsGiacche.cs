namespace Progetto_Abbigliamento
{
    public class clsGiacche : clsIndumenti
    {
        public string Tipologia { get; set; } // impermeabile, piumino, giacca, kway, giubbotto, cappotto
        public string Taglia { get; set; } // XS, S, M, L, XL, XXL, XXXL
        public string Stagione { get; set; } // invernale, estivo, primaverile
    }

}
