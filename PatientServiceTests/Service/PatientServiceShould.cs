using Microsoft.EntityFrameworkCore;
using SmileCare.Domain;
using SmileCare.Repository;
using SmileCare.Service;
using System.Collections.Generic;
using Xunit;

namespace SmileCareTests.Service
{
    public class PatientServiceShould
    {
        [Fact]
        public void GetAllPatients()
        {
            // Arrange - set up the test
            var options = new DbContextOptionsBuilder<LaboratoryDbContext>()
                .UseInMemoryDatabase("LaboratoryDatabaseForTesting")
                .Options;

            using (var context = new LaboratoryDbContext(options))
            {
                context.Patients.Add(new Patient()
                {
                    FirstName = "Remus",
                    LastName = "Pavelean",
                    City = "Cluj-Napoca",
                    Email = "remus.pavelean@gmail.com",
                    Phone = "0752436680"
                });

                context.Patients.Add(new Patient()
                {
                    FirstName = "Anca",
                    LastName = "Marcus",
                    City = "Brasov",
                    Email = "anca.marcus@gmail.com",
                    Phone = "0752406360"
                });

                context.SaveChanges();

                var patientRepository = new PatientRepository(context);
                var patientService = new PatientService(patientRepository);



                // Act - invoke the method we want to test
                var patients = patientService.ReadAll();




                //Assert - verify that the action of the tested method behaved as expected
                Assert.Equal(2, patients.Count);
                Assert.Equal("Remus", patients.Find(p => p.Id == 1).FirstName);
                Assert.Equal("Anca", patients.Find(p => p.Id == 2).FirstName);

            }
        }

        [Fact]
        public void GetPatientById()
        {
            // Arrange - set up the test
            var options = new DbContextOptionsBuilder<LaboratoryDbContext>()
                .UseInMemoryDatabase("LaboratoryDatabaseForTesting")
                .Options;

            using (var context = new LaboratoryDbContext(options))
            {
                context.Patients.Add(new Patient()
                {
                    FirstName = "Remus",
                    LastName = "Pavelean",
                    City = "Cluj-Napoca",
                    Email = "remus.pavelean@gmail.com",
                    Phone = "0752436680"
                });

                context.Patients.Add(new Patient()
                {
                    FirstName = "Anca",
                    LastName = "Marcus",
                    City = "Brasov",
                    Email = "anca.marcus@gmail.com",
                    Phone = "0752406360"
                });

                context.SaveChanges();

                var patientRepository = new PatientRepository(context);
                var patientService = new PatientService(patientRepository);



                // Act - invoke the method we want to test
                var patients = patientService.ReadAll();




                //Assert - verify that the action of the tested method behaved as expected
                Assert.Equal("Remus", patients.Find(p => p.Id == 1).FirstName);

            }

        }


        [Fact]
        public void DeletePatient()
        {
            // Arrange - set up the test
            var options = new DbContextOptionsBuilder<LaboratoryDbContext>()
                .UseInMemoryDatabase("LaboratoryDatabaseForTesting")
                .Options;

            using (var context = new LaboratoryDbContext(options))
            {
                context.Patients.Add(new Patient()
                {
                    FirstName = "Remus",
                    LastName = "Pavelean",
                    City = "Cluj-Napoca",
                    Email = "remus.pavelean@gmail.com",
                    Phone = "0752436680"
                });

                context.Patients.Add(new Patient()
                {
                    FirstName = "Anca",
                    LastName = "Marcus",
                    City = "Brasov",
                    Email = "anca.marcus@gmail.com",
                    Phone = "0752406360"
                });

                context.SaveChanges();

                var patientRepository = new PatientRepository(context);
                var patientService = new PatientService(patientRepository);
                patientRepository.Delete(1);


                // Act - invoke the method we want to test
                var patients = patientService.ReadAll();




                //Assert - verify that the action of the tested method behaved as expected
                Assert.Equal("Anca", patients.Find(p => p.Id == 2).FirstName);
            }

        }
    }
}
