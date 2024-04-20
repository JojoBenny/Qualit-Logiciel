using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualiteLogicielUA
{
    internal class Note
    {
        // Propriétés de la note
     public int NumeroEtudiant { get; set; }
     public int NumeroCours { get; set; }
     public double NoteValue { get; set; }

     // Constructeur de la classe Note
     public Note(int numeroEtudiant, int numeroCours, double note)
     {
         NumeroEtudiant = numeroEtudiant;
         NumeroCours = numeroCours;
         NoteValue = note;

     }
    }
}
