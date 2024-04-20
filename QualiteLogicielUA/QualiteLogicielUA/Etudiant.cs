using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteLog
{
    internal class Etudiant
    {
        // Propriétés de l'étudiant
        public int NumeroEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Adresse { get; set; }
        public string NumeroDeTelephone { get; set; }

        // Constructeur de la classe Etudiant
        public Etudiant(int numero, string nom, string prenom, string adresse, string numeroDeTelephone)
        {
            NumeroEtudiant = numero;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            NumeroDeTelephone = numeroDeTelephone;

        }

    }
}
