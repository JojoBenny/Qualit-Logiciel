// Import des namespaces requis
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Classe principale du gestionnaire de plateforme étudiant
public class GestionnairePlataformeEtudiant
{
    // Listes pour stocker les étudiants, les cours et les notes
    private List<Etudiant> listeEtudiants;
    private List<Cours> listeCours;
    private List<Note> listeNotes;

    // Constructeur de la classe GestionnairePlataformeEtudiant
    public GestionnairePlataformeEtudiant()
    {
        // Initialisation des listes
        listeEtudiants = new List<Etudiant>();
        listeCours = new List<Cours>();
        listeNotes = new List<Note>();
    }

    // Méthode principale pour démarrer l'application
    public void Demarrage()
    {
        bool continuer;
        do
        {
            // Affichage du menu des options
            AfficherMenuOptions();
            string choix = Console.ReadLine();
            // Gestion des options choisies par l'utilisateur
            switch (choix)
            {
                case "1":
                    CreerEtudiant();
                    continuer = DemanderContinuer();
                    break;
                case "2":
                    CreerCours();
                    continuer = DemanderContinuer();
                    break;
                case "3":
                    AjouterNote();
                    continuer = DemanderContinuer();
                    break;
                case "4":
                    AfficherReleveNotes();
                    continuer = DemanderContinuer();
                    break;
                case "5":
                    AfficherCoursDisponibles();
                    continuer = DemanderContinuer();
                    break;
                case "6":
                    Console.Write("Numéro de l'étudiant : ");
                    int numeroEtudiantFichier = int.Parse(Console.ReadLine());
                    FichierEtudiant(numeroEtudiantFichier);
                    continuer = DemanderContinuer();
                    break;
                case "7":
                    SauvegarderNotes();
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    continuer = true;
                    break;
            }
        } while (continuer);
    }

    // Méthode pour demander à l'utilisateur s'il veut continuer
    private bool DemanderContinuer()
    {
        while (true)
        {
            Console.Write("Voulez-vous continuer (O/N) ? ");
            string reponse = Console.ReadLine().ToUpper();
            if (reponse == "O")
            {
                return true;
            }
            else if (reponse == "N")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Veuillez répondre par O pour Oui ou N pour Non.");
            }
        }
    }

    // Méthode pour afficher le menu des options
    private void AfficherMenuOptions()
    {
        Console.WriteLine("1. Créer un étudiant");
        Console.WriteLine("2. Créer un cours");
        Console.WriteLine("3. Ajouter une note à un étudiant");
        Console.WriteLine("4. Afficher le relevé de notes d'un étudiant");
        Console.WriteLine("5. Afficher tous les cours disponibles");
        Console.WriteLine("6. Fichier étudiant");
        Console.WriteLine("7. Quitter");
        Console.Write("Choisissez une option du menu: ");
    }

    // Méthode pour créer un nouvel étudiant
    private void CreerEtudiant()
    {
        Console.Write("Numéro d'étudiant : ");
        if (!int.TryParse(Console.ReadLine(), out int numero) || numero <= 0)
        {
            Console.WriteLine("Numéro d'étudiant invalide.");
            return;
        }
        if (listeEtudiants.Any(e => e.NumeroEtudiant == numero))
        {
            Console.WriteLine("Un étudiant avec ce numéro existe déjà.");
            return;
        }
        Console.Write("Prénom : ");
        string prenom = Console.ReadLine();
        Console.Write("Nom : ");
        string nom = Console.ReadLine();
        Console.Write("Adresse de l'étudiant : ");
        string adresse = Console.ReadLine();
        Console.Write("Numero de téléphone de l'étudiant : ");
        string numeroDeTelephone = Console.ReadLine();

        Etudiant nouvelEtudiant = new Etudiant(numero, nom, prenom, adresse, numeroDeTelephone);
        listeEtudiants.Add(nouvelEtudiant);
        Console.WriteLine("Informations sauvegardées.");
    }

    // Méthode pour créer un nouveau cours
    private void CreerCours()
    {
        Console.Write("Numéro du cours : ");
        if (!int.TryParse(Console.ReadLine(), out int numero) || numero <= 0)
        {
            Console.WriteLine("Numéro de cours invalide.");
            return;
        }

        if (listeCours.Any(c => c.NumeroCours == numero))
        {
            Console.WriteLine("Un cours avec ce numéro existe déjà.");
            return;
        }
        Console.Write("Code : ");
        string code = Console.ReadLine();
        Console.Write("Titre : ");
        string titre = Console.ReadLine();
        Console.Write("Nom du professeur en charge : ");
        string nomProfesseur = Console.ReadLine();

        Cours nouveauCours = new Cours(numero, code, titre, nomProfesseur);
        listeCours.Add(nouveauCours);
        Console.WriteLine("Informations sauvegardées.");
    }

    // Méthode pour ajouter une note à un étudiant pour un cours donné
    private void AjouterNote()
    {
        Console.Write("Numéro d'étudiant : ");
        if (!int.TryParse(Console.ReadLine(), out int numeroEtudiant) || numeroEtudiant <= 0)
        {
            Console.WriteLine("Numéro d'étudiant invalide.");
            return;
        }
        Console.Write("Numéro du cours : ");
        if (!int.TryParse(Console.ReadLine(), out int numeroCours) || numeroCours <= 0)
        {
            Console.WriteLine("Numéro de cours invalide.");
            return;
        }
        if (listeNotes.Any(n => n.NumeroEtudiant == numeroEtudiant && n.NumeroCours == numeroCours))
        {
            Console.WriteLine("Une note pour cette combinaison étudiant-cours existe déjà.");
            return;
        }
        Console.Write("Note : ");
        if (!double.TryParse(Console.ReadLine(), out double noteValue) || noteValue < 0 || noteValue > 100)
        {
            Console.WriteLine("Note invalide. Veuillez entrer une note entre 0 et 100.");
            return;
        }
        Note nouvelleNote = new Note(numeroEtudiant, numeroCours, noteValue);
        listeNotes.Add(nouvelleNote);
        Console.WriteLine("Informations sauvegardées.");
    }

    // Méthode pour afficher le relevé de notes d'un étudiant
    private void AfficherReleveNotes()
    {
        Console.Write("Numéro de l'étudiant : ");
        int numeroEtudiant = int.Parse(Console.ReadLine());

        var notesEtudiant = listeNotes.Where(n => n.NumeroEtudiant == numeroEtudiant);
        if (notesEtudiant.Any())
        {
            Console.WriteLine($"Relevé de notes pour l'étudiant numéro {numeroEtudiant}:");
            foreach (var note in notesEtudiant)
            {
                Console.WriteLine($"Cours : {note.NumeroCours}, Note : {note.NoteValue}");
            }
        }
        else
        {
            Console.WriteLine("Aucune note trouvée pour cet étudiant.");
        }
    }

    // Méthode pour afficher tous les cours disponibles
    private void AfficherCoursDisponibles()
    {
        Console.WriteLine("Cours disponibles :");
        foreach (var cours in listeCours)
        {
            Console.WriteLine($"Numéro du cours : {cours.NumeroCours}");
            Console.WriteLine($"Code : {cours.Code}");
            Console.WriteLine($"Titre : {cours.Titre}");
            Console.WriteLine($"Nom du professeur : {cours.NomProfesseur}");
            Console.WriteLine();
        }
    }

    // Méthode pour sauvegarder les notes dans un fichier texte
    private void SauvegarderNotes()
    {
        Console.Write("Nom du fichier : ");
        string nomFichier = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(nomFichier + ".txt"))
        {
            foreach (var note in listeNotes)
            {
                writer.WriteLine($"Numéro d'étudiant : {note.NumeroEtudiant}, Numéro du cours : {note.NumeroCours}, Note : {note.NoteValue}");
            }
        }
        Console.WriteLine("Informations sauvegardées.");
    }

    // Méthode pour générer le fichier étudiant
    private void FichierEtudiant(int numeroEtudiant)
    {
        var etudiant = listeEtudiants.FirstOrDefault(e => e.NumeroEtudiant == numeroEtudiant);
        if (etudiant != null)
        {
            string nomFichier = $"Etudiant_{etudiant.NumeroEtudiant}.txt";
            using (StreamWriter writer = new StreamWriter(nomFichier))
            {
                writer.WriteLine($"Numéro d'étudiant : {etudiant.NumeroEtudiant}");
                writer.WriteLine($"Nom : {etudiant.Nom}");
                writer.WriteLine($"Prénom : {etudiant.Prenom}");
                writer.WriteLine($"Adresse : {etudiant.Adresse}");
                writer.WriteLine($"Numéro de téléphone : {etudiant.NumeroDeTelephone}");
            }
            Console.WriteLine($"Fichier {nomFichier} généré avec succès.");
        }
        else
        {
            Console.WriteLine("Étudiant non trouvé.");
        }
    }

    // Méthode pour afficher les informations d'un fichier étudiant
    private void InformationsFichierEtudiant(int numeroEtudiant)
    {
        string nomFichier = $"Etudiant_{numeroEtudiant}.txt";
        if (File.Exists(nomFichier))
        {
            Console.WriteLine($"Informations du fichier {nomFichier}:");
            string[] lignesFichier = File.ReadAllLines(nomFichier);
            foreach (string ligne in lignesFichier)
            {
                Console.WriteLine(ligne);
            }
        }
        else
        {
            Console.WriteLine("Fichier introuvable.");
        }
    }

    // Méthode principale pour démarrer l'application
    public static void Main(string[] args)
    {
        GestionnairePlataformeEtudiant gestionnaire = new GestionnairePlataformeEtudiant();
        gestionnaire.Demarrage();
    }
}
