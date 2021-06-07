using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GestionareBiblioteca
{
    public interface IStocarePersoane
    {
        void AddPersoana(Persoana p);
        List<Persoana> GetPersoane();
        void ModificarePersoane(string linieDeModificat, string liniaModificata, List<Persoana> persoane);
        void StergereDate();
        void StergeLinie(int nr_linie, List<Persoana> persoane);
    }
}
