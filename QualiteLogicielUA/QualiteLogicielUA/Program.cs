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
