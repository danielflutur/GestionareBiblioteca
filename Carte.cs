using System;
using System.Collections.Generic;
using System.Text;

namespace GestionareBiblioteca
{
    public class Carte
    {
        private string titlu;
        private string autor;
        private int an_publicare;
        private string editura;
        public string status;
        public int nr_exemplare = 0;
        
        //constructor implicit
        public Carte()
        {
            titlu = string.Empty;
            autor = string.Empty;
            an_publicare = 0;
            editura = string.Empty;
            status = string.Empty;
        }
        //constructor ce foloseste sirul de caractere
        public Carte(string informatii)
        {
            //separarea sirului si alocarea informatiilor
            string[] info = informatii.Split(',');
            titlu = info[0];
            autor = info[1];
            an_publicare = Int32.Parse(info[2]);
            editura = info[3];
            status = info[4];
            nr_exemplare++;
        }
        public string ConversieLaSir()
        {
            return $"Titlu: {titlu}\nAutor: {autor}\nAn publicare: {an_publicare}\n" +
                $"Editura: {editura}\nStatus: {status}\nNr. exemplare: {nr_exemplare}";
        }
        public string ConversieLaSir_ptFisier()
        {
            return $"{titlu},{autor},{an_publicare},{editura},{status}";
        }
        public string Titlu
        {
            get
            {
                return titlu;
            }
        }
        public string Autor
        {
            get
            {
                return autor;
            }
        }
    }
}
