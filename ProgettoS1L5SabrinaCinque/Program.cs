using System;
using System.Collections;
using System.Globalization;

namespace ProgettoS1L5SabrinaCinque
{                   
    internal class Program
    {
        static void Main(string[] args)  //****PREMESSA PER IL PROF: nel caso non dovesse funzionare qualcosa, me lo dici? perchè sul mio gestionale funziona tutto. Non vorrei aver caricato erroneamente su ghithub...****
        {
            ArrayList contribuenti = new ArrayList();

            Console.WriteLine("Benvenuto nel nostro sistema di imposte");
            int scelta;
            do
            { // ho inserito anche una scelta menu che facesse vedere i dati di un utente già registrato,per questo il codice è un pò più lungo e ho aggiunto un arraylist
                Console.WriteLine("Che cosa vuoi fare?");
                Console.WriteLine("1 - Inserire un nuovo contribuente");
                Console.WriteLine("2 - Consultare i dati di un contribuente già registrato");
                Console.WriteLine("3 - Uscire dall'applicazione");

                
                if (int.TryParse(Console.ReadLine(), out scelta))
                {
                    switch (scelta)
                    {
                        case 1:
                            Console.WriteLine("Inserisci il nome del contribuente: ");
                            string nome = Console.ReadLine();

                            Console.WriteLine("Inserisci il cognome del contribuente: ");
                            string cognome = Console.ReadLine();

                            DateTime dataNascita;
                            while (true) //ho presupposto i vari controlli nel caso in cui no si inserissero i dati correttamente.
                            {            //li ho messi dentro i while inmodo che non mi faceva "uscire" dalla scelta e ritornare al menu principale, ma mi chiede di riprovare da quel punto
                                Console.WriteLine("Inserisci la data di nascita del contribuente (yyyy-mm-dd): ");
                                if (DateTime.TryParse(Console.ReadLine(), out dataNascita))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Formato data non valido. Riprova.");
                                }
                            }

                            Console.WriteLine("Inserisci il codice fiscale del contribuente: ");
                            string codiceFiscale = Console.ReadLine();

                            Sesso sesso;
                            while (true)
                            {
                                Console.WriteLine("Inserisci il sesso del contribuente (M/F): ");
                                if (Enum.TryParse(Console.ReadLine(), true, out sesso) && Enum.IsDefined(typeof(Sesso), sesso))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Sesso non valido. Inserisci M o F.");
                                }
                            }

                            Console.WriteLine("Inserisci il comune di residenza del contribuente: ");
                            string comuneResidenza = Console.ReadLine();

                            double redditoAnnuale;
                            while (true)
                            {
                                Console.WriteLine("Inserisci il reddito annuale del contribuente: ");
                                if (double.TryParse(Console.ReadLine(), out redditoAnnuale) && redditoAnnuale >= 0)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Reddito annuale non valido. Riprova.");
                                }
                            }
                            //viene creato unnuovo contribuente ,secondo i dati raccolti con il readLine
                            Contribuente nuovoContribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
                            contribuenti.Add(nuovoContribuente);//viene aggiunto questo contribuente all'arraylist creato, in modo che se vogliamo , nel punto 2, possiamo consultare i vari contribuenti creati
                            Console.WriteLine("Contribuente inserito con successo!\n");

                            // Stampa il riepilogo del contribuente
                            Console.WriteLine(nuovoContribuente.Riepilogo());

                            // Calcola e stampa l'imposta da versare del contribuente creato
                            string impostaDaVersare = nuovoContribuente.CalcoloImposta();
                            Console.WriteLine($"IMPOSTA DA VERSARE: {impostaDaVersare}");
                            Console.WriteLine(" "); //queste tre righe di writeline le ho inserite anche negli altri case,per " separare" la fine di un case con la riproposta del menu che avviene (fino a quando non si decide di uscire)
                            Console.WriteLine(" *******************************************************************");
                            Console.WriteLine(" ");
                            break;

                        case 2:
                            if (contribuenti.Count == 0)//qui dico , se non abbiamo registrato ancor nessun contribuente e quindi l'arraylist è vuoto
                            {    //allora mi dici (nessun contribuente registrato)
                                Console.WriteLine("Nessun contribuente registrato.");
                            }
                            else
                            {   //altrimenti facciamo la ricerca con il codice fiscale, dato che è univoco, a differenza degli altri dati tipo nome,cognome,comune ecc che possono essere ripetuti in altri contribuenti
                                Console.WriteLine("Inserisci il codice fiscale del contribuente da consultare: ");
                                string codiceFiscaleDaCercare = Console.ReadLine();
                                Contribuente contribuente = null;
                                foreach (Contribuente c in contribuenti) //cerco il contribuente nell'array
                                {
                                    if (c.CodiceFiscale == codiceFiscaleDaCercare) //se c'è la corrispondenza con il codice fiscale ,allora viene recuperato
                                    {
                                        contribuente = c;
                                        break;
                                    }
                                }

                                if (contribuente != null)
                                {
                                    Console.WriteLine(contribuente.Riepilogo());//e qui stampa il riepilogo e l'imposta da pagare
                                    string impostaDaVersareContribuente = contribuente.CalcoloImposta();
                                    Console.WriteLine($"IMPOSTA DA VERSARE: {impostaDaVersareContribuente}");
                                    Console.WriteLine(" ");
                                    Console.WriteLine(" *******************************************************************");
                                    Console.WriteLine(" ");
                                }
                                else
                                {  //se invece non c'è quel codice fiscale, dice che non lo ha trovato
                                    Console.WriteLine("Contribuente non trovato.");
                                    Console.WriteLine(" ");
                                    Console.WriteLine(" *******************************************************************");
                                    Console.WriteLine(" ");

                                }
                            }
                            break;
                            

                        case 3: //qua esco dal programma ,dato che nel while gli dico che mi deve fare questo fino a quando la scelta non è uguale a 3
                            Console.WriteLine("Grazie per aver utilizzato il nostro servizio. A presto!");
                            break;

                        default:
                            Console.WriteLine("Scelta non valida. Riprova."); //qui è nel caso in cui inserisce una lettera o un numero che non sia 1,2,3
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Inserisci un valore valido.");
                }

            } while (scelta != 3);
        
        }
    }
}
