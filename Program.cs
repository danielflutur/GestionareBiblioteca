using System;
using System.Collections;
using System.Collections.Generic;

namespace GestionareBiblioteca
{
    class Program
    {
        enum STATUS
        {
            disponibila = 1,
            imprumutata = 2

        }
        static void Main(string[] args)
        {
            List<Carte> carti;
            List<Persoana> persoane;

            IStocareCarti adminCarti = Stocare_Factory.AdminCarti();
            IStocarePersoane adminPersoane = Stocare_Factory.AdminPersoane();

            carti = adminCarti.GetCarti();
            persoane = adminPersoane.GetPersoane();

            string op;
            do
            {
                Console.Clear();
                Console.WriteLine("A. Afisare carti");
                Console.WriteLine("B. Modificare carte");
                Console.WriteLine("C. Creare si adaugare carti");
                Console.WriteLine("D. Cautare carte");
                Console.WriteLine("E. Afisare persoane");
                Console.WriteLine("F. Modificare persoana");
                Console.WriteLine("G. Adaugare persoana");
                Console.WriteLine("H. Stergere date");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                op = Console.ReadLine();
                op = op.ToUpper();
                switch (op)
                {
                    case "A":
                        Console.WriteLine("Cartile sunt:");
                        for (int i = 0; i < carti.Count; i++)
                        {
                            Console.WriteLine("\n" + (carti[i]).ConversieLaSir());
                        }
                        break;
                    case "B":
                        Console.WriteLine("Introduceti titlul cartii pe care dorriti sa o modificati: ");
                        string modif = Console.ReadLine();
                        for (int i = 0; i < carti.Count; i++)
                        {
                            Carte temp = carti[i];
                            if (modif == temp.Titlu)
                            {
                                Console.WriteLine("Introduceti cartea cu valorile pe care le doriti modificate:");
                                string carte = Console.ReadLine();
                                adminCarti.ModificareCarte(temp.ConversieLaSir_ptFisier(), carte, carti);
                                Carte c = new Carte(carte);
                                carti.RemoveAt(i);
                                carti.Insert(i, c);
                                break;
                            }

                        }
                        
                        break;
                    case "C":
                        Console.WriteLine("Introduceti datele cartii(separate prin virgula)");
                        string carteNoua = Console.ReadLine();
                        Carte c1 = new Carte(carteNoua);
                        //adaugare carte in array
                        carti.Add(c1);
                        //adaugare carte in fisier
                        adminCarti.AddCarte(c1);
                        break;
                    case "D":
                        Console.WriteLine("Introduceti titlul cartii cautate:");
                        string titlu = Console.ReadLine();
                        Carte cautare = Cautare(carti, titlu);
                        if (cautare != null)
                            Console.WriteLine($"Afisare carte: \n{cautare.ConversieLaSir()}");
                        else
                            Console.WriteLine("Cartea nu a fost gasita.");
                        break;
                    case "E":
                        Console.WriteLine("Persoanele existente sunt:");
                        for (int i = 0; i < carti.Count; i++)
                        {
                            Console.WriteLine("\n" + (persoane[i]).ConversieLaSir());
                        }
                        break;
                    case "F":
                        Console.WriteLine("Introduceti numele persoanei pe care doriti sa o modificati: ");
                        string nume = Console.ReadLine();
                        for (int i = 0; i < persoane.Count; i++)
                        {
                            Persoana temp = persoane[i];
                            if (nume == temp.Nume)
                            {
                                Console.WriteLine("Introduceti persoana cu valorile modificate:");
                                string persoana = Console.ReadLine();
                                adminPersoane.ModificarePersoane(temp.ConversieLaSir_ptFisier(), persoana, persoane);
                                Persoana p1 = new Persoana(persoana);
                                persoane.RemoveAt(i);
                                persoane.Insert(i, p1);
                                break;
                            }

                        }
                        break;
                    case "G":
                        Console.WriteLine("Introduceti informatii persoana(separate prin spatiu)");
                        string persNou = Console.ReadLine();
                        Persoana p = new Persoana(persNou);
                        //adaugare persoana in array
                        persoane.Add(p);
                        //adaugare persoana in fisier
                        adminPersoane.AddPersoana(p);
                        break;
                    case "H":
                        carti.Clear();
                        adminCarti.StergereDateCarte();
                        persoane.Clear();
                        adminPersoane.StergereDate();
                        break;
                   
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
                Console.ReadKey();
            } while (op != "X");

    }
        public static Carte Cautare(List<Carte> carti, string titlu)
        {
            Carte temp = null;
            foreach (Carte x in carti)
            {
                if (titlu == x.Titlu)
                {
                    temp = x;

                }
            }
            if (temp != null)
                return temp;
            else
                return null;
        }
    }
}
