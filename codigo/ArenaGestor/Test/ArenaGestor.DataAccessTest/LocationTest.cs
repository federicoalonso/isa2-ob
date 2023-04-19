using ArenaGestor.DataAccess.Managements;
using ArenaGestor.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.DataAccessTest
{
    [TestClass]
    public class LocationTest : ManagementTest
    {
        private DbContext context;
        private LocationManagement management;
        private Country country;
        private const int countryId = 1;
        private const string countryName = "Uruguay";
        private const int locationId1 = 4;
        private const int locationId2 = 5;
        private const int locationIdNotExist = 126;
        private const int numberLocation1 = 1234;
        private const int numberLocation2 = 11400;
        private const string placeLocation1 = "Antel Arena";
        private const string placeLocation2 = "Estadio Centenario";
        private const string streetLocation1 = "Av Damaso A. Larrañaga";
        private const string streetLocation2 = "Av Dr Américo Ricaldoni";
        private Location location1;
        private Location location2;

        [TestInitialize]
        public void InitTest()
        {
            country = new Country()
            {
                CountryId = countryId,
                Name = countryName
            };
            location1 = new Location()
            {
                CountryId = countryId,
                LocationId = locationId1,
                Country = country,
                Number = numberLocation1,
                Place = placeLocation1,
                Street = streetLocation1
            };
            location2 = new Location()
            {
                CountryId = countryId,
                LocationId = locationId2,
                Country = country,
                Number = numberLocation2,
                Place = placeLocation2,
                Street = streetLocation2
            };
            CreateDataBase();
        }
        private void CreateDataBase()
        {
            context = CreateDbContext();
            context.Set<Location>().Add(location1);
            context.Set<Location>().Add(location2);
            context.SaveChanges();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            management = new LocationManagement(context);
        }

        [TestMethod]
        public void GetLocation1Test()
        {
            var result = management.GetLocationById(location1.LocationId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Country.Equals(country));
            Assert.IsTrue(result.LocationId == locationId1);
            Assert.IsTrue(result.CountryId == countryId);
            Assert.IsTrue(result.Place == placeLocation1);
            Assert.IsTrue(result.Number == numberLocation1);
            Assert.IsTrue(result.Street.Equals(streetLocation1));
        }
        
        [TestMethod]
        public void GetLocation1Test2()
        {
            var result = management.GetLocationById(location1.LocationId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Country.Equals(country));
            Assert.IsFalse(result.LocationId == locationId2);
            Assert.IsTrue(result.CountryId == countryId);
            Assert.IsFalse(result.Place == placeLocation2);
            Assert.IsFalse(result.Number == numberLocation2);
            Assert.IsFalse(result.Street.Equals(streetLocation2));
        }

        [TestMethod]
        public void GetLocation2Test()
        {
            var result = management.GetLocationById(location2.LocationId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Country.Equals(country));
            Assert.IsTrue(result.LocationId == locationId2);
            Assert.IsTrue(result.CountryId == countryId);
            Assert.IsTrue(result.Place == placeLocation2);
            Assert.IsTrue(result.Number == numberLocation2);
            Assert.IsTrue(result.Street.Equals(streetLocation2));
        }

        [TestMethod]
        public void GetLocationNotExistTest()
        {
            var result = management.GetLocationById(locationIdNotExist);
            Assert.IsNull(result);
        }
    }
}
