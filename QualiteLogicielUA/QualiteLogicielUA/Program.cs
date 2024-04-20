using QualiteLog;
using QualiteLogicielUA;

public class GestionnairePlataformeEtudiant
{
    private List<Etudiant> listeEtudiants;
    private List<Cours> listeCours;
    private List<Note> listeNotes;

    public GestionnairePlataformeEtudiant()
    {
        listeEtudiants = new List<Etudiant>();
        listeCours = new List<Cours>();
        listeNotes = new List<Note>();
    }

    public void Demarrage()
    {
        bool continuer;
        do
        {
            menuOptions();
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "1":
                    creerEtudiant();
                    continuer = demanderContinuer();
                    break;
                case "2":
                    creerCours();
                    continuer = demanderContinuer();
                    break;
                case "3":
                    ajouterNote();
                    continuer = demanderContinuer();
                    break;
                case "4":
                    afficherReleveNotes();
                    continuer = demanderContinuer();
                    break;
                case "5":
                    afficherCoursDisponibles();
                    continuer = demanderContinuer();
                    break;
                case "6":
                    Console.Write("Numéro de l'étudiant : ");
                    int numeroEtudiantFichier = int.Parse(Console.ReadLine());
                    fichierEtudiant(numeroEtudiantFichier);
                    continuer = demanderContinuer();
                    break;
                case "7":
                    sauvegarderNotes();
                    continuer = false;
                    break;
                default:
                    Console.WriteLine("Choix invalide.");
                    continuer = true;
                    break;
            }
        } while (continuer);
    }

    private bool demanderContinuer()
    {
        while (true)
        {
            Console.Write("Voulez-vous continuer (O/N) ? ");
            string reponse = Console.ReadLine().ToUpper();
            if (reponse == "O")
            { return true; }
            else if (reponse == "N")
            { return false; }
            else
            { Console.WriteLine("Veuillez répondre par O pour Oui ou N pour Non."); }
        }
    }

     private void menuOptions()
 {
     Console.WriteLine("1. Créer un étudiant");
     Console.WriteLine("2. Créer un cours");
     Console.WriteLine("3. Ajouter une note à un étudiant");
     Console.WriteLine("4. Afficher le relevé de notes d'un étudiant");
     Console.WriteLine("5. Afficher tous les cours disponibles");
     Console.WriteLine("6. Fichier  étudiant");
     Console.WriteLine("7. Quitter");
     Console.Write("Choisissez une option du menu: ");
 }

 private void creerEtudiant()
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
     Console.Write("Numero de telephone de l'étudiant : ");
     string numeroDeTelephone = Console.ReadLine();

     Etudiant nouvelEtudiant = new Etudiant(numero, nom, prenom, adresse, numeroDeTelephone);
     listeEtudiants.Add(nouvelEtudiant);
     Console.WriteLine("Informations  sauvegardées.");
 }
