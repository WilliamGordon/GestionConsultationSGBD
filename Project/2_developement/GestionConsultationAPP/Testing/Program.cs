using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            MedecinRepository repoM = new MedecinRepository();
            SpecialiteRepository repoS = new SpecialiteRepository();
            MedecinSpecialiteRepository repoMS = new MedecinSpecialiteRepository();

            //List<DAL.Medecin> med = repoM.GetAllMedecins();
            //foreach (var md in med)
            //{
            //    Console.WriteLine(md.Medecin_ID + ") " + md.Lastname + " " + md.Firstname);
            //}

            //List<DAL.Specialite> specs = repoS.GetAllSpecialites();
            //foreach (var spec in specs)
            //{
            //    Console.WriteLine(spec.Specialite_ID + ") " + spec.Name);
            //}

            //DAL.Medecin Ray = repoM.GetMedecinbyId(3);
            //Console.WriteLine(Ray.Medecin_ID);
            //Console.WriteLine(Ray.Firstname);
            //Console.WriteLine(Ray.Lastname);

            //DAL.Specialite generaliste = repoS.GetSpecialiteById(10);
            //Console.WriteLine(generaliste.Specialite_ID);
            //Console.WriteLine(generaliste.Name);

            //DAL.MedecinSpecialite medSpec = new DAL.MedecinSpecialite();
            //medSpec.Medecin_ID = Ray.Medecin_ID;
            //medSpec.Specialite_ID = generaliste.Specialite_ID;

            //int idmedSpec = repoMS.AddMedecinSpecialite(medSpec);

            //DAL.MedecinSpecialite newMedSpec = repoMS.GetMedecinSpecialitebyId(idmedSpec);
            //Console.WriteLine(newMedSpec.MedecinSpecialite_ID);
            //Console.WriteLine(newMedSpec.Medecin_ID);
            //Console.WriteLine(newMedSpec.Specialite_ID);

            // Get All specialite for Medecin

            var med = repoM.GetMedecinbyId(3);

            foreach (var medspec in repoMS.GetAllMedecinSpecialites())
            {
                if (medspec.Medecin_ID == med.Medecin_ID)
                {
                    Console.WriteLine(repoS.GetSpecialiteById(medspec.Specialite_ID).Name);
                }
            }

            Console.ReadLine(); 
        }
    }
}
