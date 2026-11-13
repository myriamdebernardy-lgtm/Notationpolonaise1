using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        /// <summary>
        /// Calcul d'une formule en notation polonaise
        /// </summary>
        /// <param name="laFormule">formule en notation polonaise</param>
        /// <returns>résultat du calcul, ou NaN si la formule est incorrecte</returns>
        static float Polonaise(string laFormule)
        {
            try
            {
                // découpage de la formule en cases d'un tableau
                string[] tab = laFormule.Split(' ');
                // boîte qui compte les cases "vivantes" du tableau 
                int nbCase = tab.Length;
                //tant qu'il reste plus d'un case
                while (nbCase > 1)
                {
                    int n = nbCase - 1;


                    while (tab[n] != "+" && tab[n] != "-" && tab[n] != "*" && tab[n] != "/")
                    {
                        // rechercheur de signe qui vient ici
                        n--;
                    }
                    float a = float.Parse(tab[n + 1]);
                    float b = float.Parse(tab[n + 2]);
                    float r;
                    if (tab[n] == "+")
                    {
                        r = a + b;
                    }
                    else if (tab[n] == "-")
                    {
                        r = a - b;
                    }
                    else if (tab[n] == "*")
                    {
                        r = a * b;
                    }
                    else
                    {
                        if (b == 0)
                        {
                            return float.NaN;
                        }
                        r = a / b;
                    }
                    tab[n] = r.ToString();
                    // décalage : on tasse les cases vivantes qui suivent les 2 mortes, vers la gauche
                    for (int i = n + 3; i < nbCase; i++)
                    {
                        tab[i - 2] = tab[i];
                    }
                    nbCase = nbCase - 2;
                }
                return float.Parse(tab[0]);
            }
            catch
            {
                return float.NaN;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
