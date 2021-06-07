using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GestionareBiblioteca
{
    public interface IStocareCarti
    {

        void AddCarte(Carte c);
        List<Carte> GetCarti();
        void ModificareCarte(string linieDeModificat, string liniaModificata, List<Carte> carti);
        void StergereDateCarte();
        public void StergeLinie(int nr_linie, List<Carte> carti);
    }
}
