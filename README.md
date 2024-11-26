# Progetto_Abbigliamento

Il progetto "Progetto Abbigliamento" è un'applicazione Windows Forms sviluppata in C# utilizzando .NET Framework 4.7.2. L'applicazione gestisce diversi tipi di indumenti, come maglie, pantaloni, scarpe, giacche e borse.
Struttura del Progetto
•	Form1.cs: Contiene la logica principale dell'interfaccia utente, inclusa l'inizializzazione dei tab per ogni categoria di indumenti e la gestione degli eventi dei pulsanti per l'inserimento dei dati.
•	Program.cs: Punto di ingresso dell'applicazione che avvia il form principale Form1.
•	clsIndumenti.cs: Classe base che rappresenta un indumento generico con proprietà comuni come Marca, Prezzo, Colore, Materiale e Genere.
•	clsMaglie.cs: Classe derivata da clsIndumenti che rappresenta una maglia con proprietà aggiuntive come Tipo, Taglia, Manica e Apertura.
•	clsScarpe.cs: Classe derivata da clsIndumenti che rappresenta una scarpa con proprietà aggiuntive come Tipologia, Numero, Apertura e Suola.
Funzionalità Principali
•	Gestione delle Maglie: Possibilità di inserire, salvare e caricare maglie da un file.
•	Gestione delle Scarpe: Possibilità di inserire, salvare e caricare scarpe da un file.
•	Interfaccia Utente: Utilizzo di un TabControl per separare le diverse categorie di indumenti e DataGridView per visualizzare i dati inseriti.
