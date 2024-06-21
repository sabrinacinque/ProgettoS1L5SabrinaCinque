using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoS1L5SabrinaCinque
{
    enum Sesso
    {
        M, F
    }

    internal class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public Sesso Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public double RedditoAnnuale { get; set; }

        
        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, Sesso sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }



        public string CalcoloImposta()
        {
            double impostaDaVersare = 0;

            //qua ci sono tutti i vari calcoli dell'imposta, secondo i parametri forniti nella traccia
            if (RedditoAnnuale <= 15000)
            {
                impostaDaVersare = RedditoAnnuale * 0.23;
            }
            else if (RedditoAnnuale <= 28000)
            {
                impostaDaVersare = 3450 + ((RedditoAnnuale - 15000) * 0.27);
            }
            else if (RedditoAnnuale <= 55000)
            {
                impostaDaVersare = 6960 + ((RedditoAnnuale - 28000) * 0.38);
            }
            else if (RedditoAnnuale <= 75000)
            {
                impostaDaVersare = 17220 + ((RedditoAnnuale - 55000) * 0.41);
            }
            else
            {
                impostaDaVersare = 25420 + ((RedditoAnnuale - 75000) * 0.43);
            }

            return impostaDaVersare + " euro.";
        }


        public string Riepilogo() //metodo per stampare un riepilogo del contribuente
        {
            return $"RIEPILOGO:\n" +
                   $"Contribuente: {Nome} {Cognome}, \n" +
                   $"nato/a il {DataNascita:dd/MM/yyyy} ({Sesso}), \n" +
                   $"residente in {ComuneResidenza}, \n" +
                   $"codice fiscale: {CodiceFiscale}\n" +
                   $"Reddito dichiarato: {RedditoAnnuale} euro\n\n";
        }

    }
}
