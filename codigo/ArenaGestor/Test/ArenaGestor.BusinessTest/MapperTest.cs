using ArenaGestor.Domain;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGestor.BusinessTest
{
    [TestClass]
    internal class MapperTest
    {
        private IMapper mapper;
        private Concert concertOK;

        public void InitTest()
        {
            // mapper = new Mapper();
            concertOK = new Concert()
            {
                ConcertId = 1,
                TourName = "Olé Tour",
                Date = DateTime.Now.AddDays(10),
                Price = 100,
                TicketCount = 500,
                Protagonists = new List<ConcertProtagonist>()
                {
                    new ConcertProtagonist()
                    {
                        MusicalProtagonistId = 1
                    }
                },
                Location = new Location()
                {
                    Country = new Country()
                    {
                        CountryId = 1,
                        Name = "Uruguay"
                    },
                    LocationId = 1,
                    Number = 1234,
                    Place = "Estadio Centenario",
                    Street = "Av. Ricaldoni"
                }
            };
        }

        [TestMethod]
        public void MapToConcertTest() {
           
        }
    }
}
