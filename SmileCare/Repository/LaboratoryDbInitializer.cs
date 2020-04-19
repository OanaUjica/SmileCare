using SmileCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileCare.Repository
{
    public static class LaboratoryDbInitializer
    {
        public static void Seed(LaboratoryDbContext context)
        {
            if (context.Dentists.Any())
            {
                return;
            }

            var dentists = new Dentist[]
            {
                new Dentist { FirstName = "Oana", LastName = "Alexandru", City = "Brasov", Email = "oana.alexandru@gmail.com", Phone = "0743243990"},
                new Dentist { FirstName = "Paul", LastName = "Muresan", City = "Cluj-Napoca", Email = "paul.muresan@gmail.com", Phone = "0753843455"},
                new Dentist { FirstName = "Vlad", LastName = "Horvat", City = "Turda", Email = "vlad.horvat@gmail.com", Phone = "0744256978"},
                new Dentist { FirstName = "Luiza", LastName = "Natura", City = "Cluj-Napoca", Email = "luiza.natura@gmail.com", Phone = "0752723950"},
                new Dentist { FirstName = "Carol", LastName = "Isopescu", City = "Cluj-Napoca", Email = "carol.isopescu@gmail.com", Phone = "0757240900"},
                new Dentist { FirstName = "Florin", LastName = "Mihai", City = "Bistrita", Email = "florin.mihai@gmail.com", Phone = "0744333580"}
            };

            foreach (var dentist in dentists)
            {
                context.Dentists.Add(dentist);
            }
            context.SaveChanges();






            var patients = new Patient[]
            {
                new Patient { FirstName = "Remus", LastName = "Pavelean", City = "Cluj-Napoca", Email = "remus.pavelean@gmail.com", Phone = "0754386092" },
                new Patient { FirstName = "Oana", LastName = "Pavelean", City = "Cluj-Napoca", Email = "oana.pavelean@gmail.com", Phone = "0744082045" },
                new Patient { FirstName = "Andreea", LastName = "Mihasan", City = "Bistrita", Email = "andreea.mihasan@gmail.com", Phone = "0757240900" },
                new Patient { FirstName = "Mihaela", LastName = "Marcus", City = "Cluj-Napoca", Email = "mihaela.marcus@gmail.com", Phone = "0744333580" },
                new Patient { FirstName = "Andrei", LastName = "Atodiresei", City = "Bistrita", Email = "andrei.atodiresei@gmail.com", Phone = "0722776032" },
                new Patient { FirstName = "Horatiu", LastName = "Cailean", City = "Brasov", Email = "horatiu.cailean@gmail.com", Phone = "0752386702" }
            };

            foreach (var patient in patients)
            {
                context.Patients.Add(patient);
            }
            context.SaveChanges();






            var cases = new Case[]
            {
                new Case { DentistId = dentists.Single(d => d.Email == "oana.alexandru@gmail.com").Id, PatientId = patients.Single(p => p.Email == "horatiu.cailean@gmail.com").Id, Employee = "Oana Ujica", Stage = Stage.Received, Category = Category.SingleUnit, Tooth = Tooth.LowerCanine, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.A1, Comment = "The case should be ready in 5 working days. Please verify the calendar.", Price = 250.00M, CreationDate = DateTime.Now, IsImplant = true },
                new Case { DentistId = dentists.Single(d => d.Email == "paul.muresan@gmail.com").Id, PatientId = patients.Single(p => p.Email == "remus.pavelean@gmail.com").Id, Employee = "Daniel Moldovan", Stage = Stage.Accepted, Category = Category.MissingTooth, Tooth = Tooth.LowerSecondMolar, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.C2, Comment = "Please verify the color chart for more details.", Price = 3440.00M, CreationDate = DateTime.Now, IsImplant = true },
                new Case { DentistId = dentists.Single(d => d.Email == "carol.isopescu@gmail.com").Id, PatientId = patients.Single(p => p.Email == "oana.pavelean@gmail.com").Id, Employee = "Daniel Moldovan", Stage = Stage.CaseInProduction, Category = Category.SingleUnit, Tooth = Tooth.UpperCentralIncisor, RestorationType = RestorationType.Veneer, Shade = Shade.B2, Comment = "Attention to color and shape.", Price = 700.00M, CreationDate = DateTime.Now, IsImplant = false },
                new Case { DentistId = dentists.Single(d => d.Email == "florin.mihai@gmail.com").Id, PatientId = patients.Single(p => p.Email == "andreea.mihasan@gmail.com").Id, Employee = "Oana Ujica", Stage = Stage.Received, Category = Category.Bridge, Tooth = Tooth.UpperFirstMolar, RestorationType = RestorationType.CoronoRadicular, Shade = Shade.B4, Comment = "The case should be ready in 14 days.", Price = 1475.00M, CreationDate = DateTime.Now, IsImplant = false },
                new Case { DentistId = dentists.Single(d => d.Email == "paul.muresan@gmail.com").Id, PatientId = patients.Single(p => p.Email == "mihaela.marcus@gmail.com").Id, Employee = "Bianca Anastasia", Stage = Stage.Delayed, Category = Category.SingleUnit, Tooth = Tooth.UpperThirdMolar, RestorationType = RestorationType.CrownOverImplant, Shade = Shade.C3, Comment = "Problems with the color.", Price = 1200.00M, CreationDate = DateTime.Now, IsImplant = true },
                new Case { DentistId = dentists.Single(d => d.Email == "florin.mihai@gmail.com").Id, PatientId = patients.Single(p => p.Email == "andrei.atodiresei@gmail.com").Id, Employee = "Daniel Moldovan", Stage = Stage.CaseInProduction, Category = Category.MissingTooth, Tooth = Tooth.UpperFirstPremolar, RestorationType = RestorationType.SingleUnitWaxUpOnNaturalImplant, Shade = Shade.A1, Comment = "Attention to the shape.", Price = 235.00M, CreationDate = DateTime.Now, IsImplant = true }
            };

            foreach (var laboratoryCase in cases)
            {
                context.Cases.Add(laboratoryCase);
            }
            context.SaveChanges();

        }
    }
}
