namespace Progetto_Abbigliamento
{
    public class clsScarpe : clsIndumenti
    {
        public string Tipologia { get; set; } // sandali, da ginnastica, mocassini, stivali, ciabatte
        public int Numero { get; set; } // 18 .. 50
        public string Apertura { get; set; } // lacci, velcro, zip, aperte
        public string Suola { get; set; } // cuoio, gomma, plastica, legno
    }

}
