using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Progetto_Abbigliamento
{
    public partial class Form1 : Form
    {
        private List<clsMaglie> maglie = new List<clsMaglie>();

        private TabControl tabControlIndumenti;
        private TabPage tabPageMaglie;
        private TabPage tabPagePantaloni;
        private TabPage tabPageScarpe;
        private TabPage tabPageGiacche;
        private TabPage tabPageBorse;

        private DataGridView dgvMaglie;

        public Form1()
        {
            InitializeComponent();
            InizializzaTabControl();
        }

        private void InizializzaTabControl()
        {
            // Creazione del TabControl e delle TabPage
            tabControlIndumenti = new TabControl();
            tabPageMaglie = new TabPage("Maglie");
            tabPagePantaloni = new TabPage("Pantaloni");
            tabPageScarpe = new TabPage("Scarpe");
            tabPageGiacche = new TabPage("Giacche");
            tabPageBorse = new TabPage("Borse");

            // Configurazione del TabControl
            tabControlIndumenti.Dock = DockStyle.Fill;
            tabControlIndumenti.TabPages.Add(tabPageMaglie);
            tabControlIndumenti.TabPages.Add(tabPagePantaloni);
            tabControlIndumenti.TabPages.Add(tabPageScarpe);
            tabControlIndumenti.TabPages.Add(tabPageGiacche);
            tabControlIndumenti.TabPages.Add(tabPageBorse);

            // Aggiunta del TabControl alla Form
            this.Controls.Add(tabControlIndumenti);

            // Inizializzazione delle TabPage
            InizializzaTabMaglie();
            InizializzaTabPantaloni();
            InizializzaTabScarpe();
            InizializzaTabGiacche();
            InizializzaTabBorse();
        }

        // TabPage Maglie
        public void InizializzaTabMaglie()
        {
        // Controlli per la TabPage Maglie
        Label lblTipo = new Label { Text = "Tipo:", Location = new Point(20, 20) };
            ComboBox cmbTipo = new ComboBox { Name = "cmbTipo", Location = new Point(120, 20), Width = 150 };
            cmbTipo.Items.AddRange(new string[] { "FELPA", "T-SHIRT", "POLO", "CANOTTA" });

            Label lblTaglia = new Label { Text = "Taglia:", Location = new Point(20, 60) };
            ComboBox cmbTaglia = new ComboBox { Name = "cmbTaglia", Location = new Point(120, 60), Width = 150 };
            cmbTaglia.Items.AddRange(new string[] { "XS", "S", "M", "L", "XL", "XXL", "XXXL" });

            // Altri controlli per Manica, Apertura, ecc.

            Button btnInserisci = new Button { Text = "Inserisci", Location = new Point(20, 200) };
            btnInserisci.Click += BtnInserisciMaglie_Click;

            dgvMaglie = new DataGridView
            {
                Name = "dgvMaglie",
                Location = new Point(20, 250),
                Width = 600,
                Height = 200,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };
            tabPageMaglie.Controls.Add(dgvMaglie);
            tabPageMaglie.Controls.Add(lblTipo);
            tabPageMaglie.Controls.Add(cmbTipo);
            tabPageMaglie.Controls.Add(lblTaglia);
            tabPageMaglie.Controls.Add(cmbTaglia);
            tabPageMaglie.Controls.Add(btnInserisci);

            CaricaMaglieDaFile();
        }


        public void BtnInserisciMaglie_Click(object sender, EventArgs e)
        {
            ComboBox cmbTipo = (ComboBox)tabPageMaglie.Controls["cmbTipo"];
            ComboBox cmbTaglia = (ComboBox)tabPageMaglie.Controls["cmbTaglia"];

            if (cmbTipo == null || cmbTaglia == null)
            {
                MessageBox.Show("Controlli non trovati.");
                return;
            }

            if (cmbTipo.SelectedItem == null || cmbTaglia.SelectedItem == null)
            {
                MessageBox.Show("Per favore, seleziona tutti i campi.");
                return;
            }

            string tipo = cmbTipo.SelectedItem.ToString();
            string taglia = cmbTaglia.SelectedItem.ToString();

            clsMaglie nuovaMaglia = new clsMaglie
            {
                Tipo = tipo,
                Taglia = taglia,
                // Impostare altre proprietà se necessario
            };
            maglie.Add(nuovaMaglia);
            SalvaMaglieSuFile();
            CaricaMaglieDaFile();
            MessageBox.Show("Maglia inserita con successo.");
        }





        private void SalvaMaglieSuFile()
        {
            string percorsoFile = "maglie.txt";

            using (StreamWriter writer = new StreamWriter(percorsoFile))
            {
                foreach (var maglia in maglie)
                {
                    // Scrivere i dati separati da un punto e virgola
                    writer.WriteLine($"{maglia.Tipo};{maglia.Taglia}");
                }
            }
        }

        private void CaricaMaglieDaFile()
        {
            string percorsoFile = "maglie.txt";
            if (!File.Exists(percorsoFile))
                return;

            List<clsMaglie> maglieDaFile = new List<clsMaglie>();
            using (StreamReader reader = new StreamReader(percorsoFile))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    string[] dati = linea.Split(';');
                    if (dati.Length >= 2)
                    {
                        clsMaglie maglia = new clsMaglie
                        {
                            Tipo = dati[0],
                            Taglia = dati[1]
                        };
                        maglieDaFile.Add(maglia);
                    }
                }
            }
            dgvMaglie.DataSource = null;
            dgvMaglie.DataSource = maglieDaFile;
        }


        // TabPage Pantaloni
        private void InizializzaTabPantaloni()
        {
            // Controlli per la TabPage Pantaloni
            Label lblTipo = new Label { Text = "Tipo:", Location = new Point(20, 20) };
            ComboBox cmbTipo = new ComboBox { Location = new Point(120, 20), Width = 150 };
            cmbTipo.Items.AddRange(new string[] { "JEANS", "FELPATI", "LEGGINS", "CLASSICI" });

            Label lblTaglia = new Label { Text = "Taglia:", Location = new Point(20, 60) };
            ComboBox cmbTaglia = new ComboBox { Location = new Point(120, 60), Width = 150 };
            cmbTaglia.Items.AddRange(new string[] { "44", "46", "48", "50", "52", "54", "56", "58", "60" });

            Label lblLunghezza = new Label { Text = "Lunghezza:", Location = new Point(20, 100) };
            ComboBox cmbLunghezza = new ComboBox { Location = new Point(120, 100), Width = 150 };
            cmbLunghezza.Items.AddRange(new string[] { "LUNGHI", "CORTI", "PNOCHIETTI" });

            Label lblVestibilita = new Label { Text = "Vestibilità:", Location = new Point(20, 140) };
            ComboBox cmbVestibilita = new ComboBox { Location = new Point(120, 140), Width = 150 };
            cmbVestibilita.Items.AddRange(new string[] { "SLIM", "SKINNY" });

            Button btnInserisci = new Button { Text = "Inserisci", Location = new Point(20, 200) };
            btnInserisci.Click += BtnInserisciPantaloni_Click;

            // Aggiunta dei controlli alla TabPage
            tabPagePantaloni.Controls.Add(lblTipo);
            tabPagePantaloni.Controls.Add(cmbTipo);
            tabPagePantaloni.Controls.Add(lblTaglia);
            tabPagePantaloni.Controls.Add(cmbTaglia);
            tabPagePantaloni.Controls.Add(lblLunghezza);
            tabPagePantaloni.Controls.Add(cmbLunghezza);
            tabPagePantaloni.Controls.Add(lblVestibilita);
            tabPagePantaloni.Controls.Add(cmbVestibilita);
            tabPagePantaloni.Controls.Add(btnInserisci);
        }

        // TabPage Scarpe
        private void InizializzaTabScarpe()
        {
            // Controlli per la TabPage Scarpe
            Label lblTipologia = new Label { Text = "Tipologia:", Location = new Point(20, 20) };
            ComboBox cmbTipologia = new ComboBox { Location = new Point(120, 20), Width = 150 };
            cmbTipologia.Items.AddRange(new string[] { "SANDALI", "DA GINNASTICA", "MOCASSINI", "STIVALI", "CIABATTE" });

            Label lblNumero = new Label { Text = "Numero:", Location = new Point(20, 60) };
            NumericUpDown numNumero = new NumericUpDown { Location = new Point(120, 60), Width = 150, Minimum = 18, Maximum = 50 };

            Label lblApertura = new Label { Text = "Apertura:", Location = new Point(20, 100) };
            ComboBox cmbApertura = new ComboBox { Location = new Point(120, 100), Width = 150 };
            cmbApertura.Items.AddRange(new string[] { "LACCI", "VELCRO", "ZIP", "APERTE" });

            Label lblSuola = new Label { Text = "Suola:", Location = new Point(20, 140) };
            ComboBox cmbSuola = new ComboBox { Location = new Point(120, 140), Width = 150 };
            cmbSuola.Items.AddRange(new string[] { "CUOIO", "GOMNMA", "PLASTICA", "LEGNO" });

            Button btnInserisci = new Button { Text = "Inserisci", Location = new Point(20, 200) };
            btnInserisci.Click += BtnInserisciScarpe_Click;

            // Aggiunta dei controlli alla TabPage
            tabPageScarpe.Controls.Add(lblTipologia);
            tabPageScarpe.Controls.Add(cmbTipologia);
            tabPageScarpe.Controls.Add(lblNumero);
            tabPageScarpe.Controls.Add(numNumero);
            tabPageScarpe.Controls.Add(lblApertura);
            tabPageScarpe.Controls.Add(cmbApertura);
            tabPageScarpe.Controls.Add(lblSuola);
            tabPageScarpe.Controls.Add(cmbSuola);
            tabPageScarpe.Controls.Add(btnInserisci);
        }

        // TabPage Giacche
        private void InizializzaTabGiacche()
        {
            // Controlli per la TabPage Giacche
            Label lblTipologia = new Label { Text = "Tipologia:", Location = new Point(20, 20) };
            ComboBox cmbTipologia = new ComboBox { Location = new Point(120, 20), Width = 150 };
            cmbTipologia.Items.AddRange(new string[] { "IMPERMEABILE", "PIUMINO", "GIACCA", "KWAY", "GIUBOTTO", "CAPPOTTO" });

            Label lblTaglia = new Label { Text = "Taglia:", Location = new Point(20, 60) };
            ComboBox cmbTaglia = new ComboBox { Location = new Point(120, 60), Width = 150 };
            cmbTaglia.Items.AddRange(new string[] { "XS", "S", "M", "L", "XL", "XXL", "XXXL" });

            Label lblStagione = new Label { Text = "Stagione:", Location = new Point(20, 100) };
            ComboBox cmbStagione = new ComboBox { Location = new Point(120, 100), Width = 150 };
            cmbStagione.Items.AddRange(new string[] { "INVERNALE", "ESTIVO", "PRIMAVERILE" });

            Button btnInserisci = new Button { Text = "Inserisci", Location = new Point(20, 200) };
            btnInserisci.Click += BtnInserisciGiacche_Click;

            // Aggiunta dei controlli alla TabPage
            tabPageGiacche.Controls.Add(lblTipologia);
            tabPageGiacche.Controls.Add(cmbTipologia);
            tabPageGiacche.Controls.Add(lblTaglia);
            tabPageGiacche.Controls.Add(cmbTaglia);
            tabPageGiacche.Controls.Add(lblStagione);
            tabPageGiacche.Controls.Add(cmbStagione);
            tabPageGiacche.Controls.Add(btnInserisci);
        }

        // TabPage Borse
        private void InizializzaTabBorse()
        {
            // Controlli per la TabPage Borse
            Label lblTipo = new Label { Text = "Tipo:", Location = new Point(20, 20) };
            ComboBox cmbTipo = new ComboBox { Location = new Point(120, 20), Width = 150 };
            cmbTipo.Items.AddRange(new string[] { "TRACOLLA", "ZAINETTO", "MARSUPIO", "POCHETTE" });

            Label lblTaglia = new Label { Text = "Taglia:", Location = new Point(20, 60) };
            ComboBox cmbTaglia = new ComboBox { Location = new Point(120, 60), Width = 150 };
            cmbTaglia.Items.AddRange(new string[] { "PICCOLA", "MEDIA", "GRANDE" });

            Label lblStagione = new Label { Text = "Stagione:", Location = new Point(20, 100) };
            ComboBox cmbStagione = new ComboBox { Location = new Point(120, 100), Width = 150 };
            cmbStagione.Items.AddRange(new string[] { "INVERNALE", "ESTIVO" });

            Button btnInserisci = new Button { Text = "Inserisci", Location = new Point(20, 200) };
            btnInserisci.Click += BtnInserisciBorse_Click;

            // Aggiunta dei controlli alla TabPage
            tabPageBorse.Controls.Add(lblTipo);
            tabPageBorse.Controls.Add(cmbTipo);
            tabPageBorse.Controls.Add(lblTaglia);
            tabPageBorse.Controls.Add(cmbTaglia);
            tabPageBorse.Controls.Add(lblStagione);
            tabPageBorse.Controls.Add(cmbStagione);
            tabPageBorse.Controls.Add(btnInserisci);
        }


        /***********************************************
         * Eventi per l'inserimento di nuovi indumenti
         ***********************************************/




        private void BtnInserisciPantaloni_Click(object sender, EventArgs e)
        {
            // Logica per inserire un nuovo Pantalone
        }
        private void BtnInserisciScarpe_Click(object sender, EventArgs e)
        {
            // Logica per inserire una nuova Scarpa
        }
        private void BtnInserisciGiacche_Click(object sender, EventArgs e)
        {
            // Logica per inserire una nuova Giacca
        }

        private void BtnInserisciBorse_Click(object sender, EventArgs e)
        {
            // Logica per inserire una nuova Borsa
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Eventuale codice da eseguire al caricamento della Form
        }
    }
}
