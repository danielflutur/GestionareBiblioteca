using System;
using System.Collections.Generic;
using System.Text;

namespace GestionareBiblioteca
{
    public static class Stocare_Factory
    {
        public static IStocareCarti AdminCarti()
        {
            return new AdministrareCarti("carti.txt");
        }
        public static IStocarePersoane AdminPersoane()
        {
            return new AdministrarePersoane("persoane.txt");
        }
    }
}
