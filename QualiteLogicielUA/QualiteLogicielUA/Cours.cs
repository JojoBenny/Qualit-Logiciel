using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteLogicielUA
{
    internal class Cours
    {
        public int NumeroCours { get; set; }    
        public string Code { get; set; }
        public string Titre { get; set; }
        public string NomProfesseur { get; set; }

        // Constructeur de la classe Cours
        public Cours(int numero, string code, string titre, string nomProfesseur)
        {
            NumeroCours = numero;
            Code = code;
            Titre = titre;
            NomProfesseur = nomProfesseur;
        }

    }
}
