using ArenaGestor.Business;
using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using ArenaGestor.Extensions.DTO;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Business.Helpers;
using Microsoft.EntityFrameworkCore;
using ArenaGestor.DataAccess.Managements;
using ArenaGestor.DataAccessTest;
using System.IO;
using ArenaGestor.APIContracts.Artist;
using ArenaGestor.APIContracts.Band;
using ArenaGestor.APIContracts.Concert;
using ArenaGestor.APIContracts.Country;
using ArenaGestor.APIContracts.Gender;
using ArenaGestor.APIContracts.Roles;
using ArenaGestor.APIContracts.Security;
using ArenaGestor.APIContracts.Soloist;
using ArenaGestor.APIContracts.Ticket;
using ArenaGestor.APIContracts.Users;
using System.Linq;

namespace ArenaGestor.BusinessTest
{
    [TestClass]
    public class ImportExportServiceTest : ManagementTest
    {
        private IReflectionHelpers reflection;
        private IConcertsService concertsService;
        private IConcertsManagement concertManagement;
        private IMusicalProtagonistService musicalProtagonistService;
        private IMusicalProtagonistManagement musicalProtagonistManagement;
        private ICountrysManagement countryManagement;
        private ICountrysService countrysService;
        private ISecurityService securityService;
        private IMapper mapper;
        private ImportExportService service;
        private DbContext context;
        ISessionManagement sessionManagement;
        IUsersManagement usersManagement;
        private ILocationManagement locationManagement;
        private FileComparator fileComparator;
        private string importPathFromProjectXML;
        private string exportPathFromProjectXML;
        private string exportPathFromProjectJSON;
        private string importPathFromProjectJSON;
        private string fileToComparePathFromProjectXML;
        private string fileToComparePathFromProjectJSON;
        private Band rolling;
        private Location location;
        private Gender gender;
        private Country country;
        private readonly string locationPlace = "Antel Arena";
        private readonly string locationStreet = "Av Damaso A. Larrañaga";

        [TestInitialize]
        public void InitTest()
        {
            importPathFromProjectXML = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            exportPathFromProjectXML = fileToComparePathFromProjectJSON = fileToComparePathFromProjectXML = importPathFromProjectJSON = exportPathFromProjectJSON = importPathFromProjectXML;
            importPathFromProjectXML += "/ImportExportFiles/ImportXML.txt";
            exportPathFromProjectXML += "/ImportExportFiles/ExportXML.txt";
            importPathFromProjectJSON += "/ImportExportFiles/ImportJSON.txt";
            exportPathFromProjectJSON += "/ImportExportFiles/ExportJSON.txt";
            fileToComparePathFromProjectJSON += "/ImportExportFiles/FileToCompareJSON.txt";
            fileToComparePathFromProjectXML += "/ImportExportFiles/FileToCompareXML.txt";
            CreateDataBase();
            country = new Country()
            {
                CountryId = 1,
                Name = "Uruguay"
            };
            context.Set<Country>().Add(country);
            location = new Location()
            {
                Country = country,
                CountryId = 1,
                LocationId = 4,
                Number = 1234,
                Place = locationPlace,
                Street = locationStreet,
            };
            context.Set<Location>().Add(location);
            context.SaveChanges();
            fileComparator = new FileComparator();
            gender = new Gender()
            {
                GenderId = 1,
                Name = "Rock",
            };
            rolling = new Band()
            {
                MusicalProtagonistId = 2,
                Gender = gender,
                GenderId = 1,
                StartDate = DateTime.Parse("1962-01-01T00:00:00"),
            };
            context.Set<Band>().Add(rolling);
            context.SaveChanges();

        }

        private void CreateDataBase()
        {
            context = CreateDbContext();
            context.Set<Location>();
            context.Set<Concert>();
            context.Set<Country>();
            context.Set<MusicalProtagonist>();
            context.SaveChanges();
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            locationManagement = new LocationManagement(context);
            reflection = new ReflectionHelpers();
            concertManagement = new ConcertsManagement(context);
            musicalProtagonistManagement = new MusicalProtagonistManagement(context);
            musicalProtagonistService = new MusicalProtagonistService(musicalProtagonistManagement);
            countryManagement = new CountrysManagement(context);
            countrysService = new CountrysService(countryManagement);
            securityService = new SecurityService(sessionManagement, usersManagement);
            concertsService = new ConcertsService(concertManagement, musicalProtagonistService, countrysService, securityService);
            InitializeMapper();
            service = new ImportExportService(concertsService, reflection, mapper, locationManagement);
        }
        private void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile<AppProfile>();
                cfg.CreateMap<ArtistGetArtistsDto, Artist>();
                cfg.CreateMap<ArtistInsertArtistDto, Artist>();
                cfg.CreateMap<Artist, ArtistResultArtistDto>()
                    .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.UserId));
                cfg.CreateMap<List<Artist>, IEnumerable<ArtistResultArtistDto>>();
                cfg.CreateMap<ArtistUpdateArtistDto, Artist>();

                cfg.CreateMap<BandGetArtistsDto, Artist>();
                cfg.CreateMap<BandGetBandsDto, Band>();
                cfg.CreateMap<BandInsertArtistDto, ArtistBand>();
                cfg.CreateMap<BandInsertBandDto, Band>();
                cfg.CreateMap<ArtistBand, BandResultArtistDto>()
                    .ForMember(x => x.Name, y => y.MapFrom(z => z.Artist.Name));
                cfg.CreateMap<Artist, BandResultArtistDto>();
                cfg.CreateMap<Band, BandResultBandDto>();
                cfg.CreateMap<List<Band>, IEnumerable<BandResultBandDto>>();
                cfg.CreateMap<Gender, BandResultGenderDto>();
                cfg.CreateMap<Concert, BandResultConcertDto>();
                cfg.CreateMap<BandUpdateArtistDto, ArtistBand>();
                cfg.CreateMap<BandUpdateBandDto, Band>();
                cfg.CreateMap<ConcertProtagonist, BandResultConcertDto>()
                    .ForMember(dto => dto.TourName, x => x.MapFrom(prot => prot.Concert.TourName))
                    .ForMember(dto => dto.Date, x => x.MapFrom(prot => prot.Concert.Date))
                    .ForMember(dto => dto.Price, x => x.MapFrom(prot => prot.Concert.Price))
                    .ForMember(dto => dto.TicketCount, x => x.MapFrom(prot => prot.Concert.TicketCount))
                    .ForMember(dto => dto.Location, x => x.MapFrom(prot => prot.Concert.Location));

                cfg.CreateMap<RoleArtist, BandResultRoleArtistDto>();
                cfg.CreateMap<List<RoleArtist>, IEnumerable<BandResultRoleArtistDto>>();

                cfg.CreateMap<SoloistInsertRoleArtistDto, RoleArtist>();
                cfg.CreateMap<List<SoloistInsertRoleArtistDto>, IEnumerable<RoleArtist>>();
                cfg.CreateMap<SoloistUpdateRoleArtistDto, RoleArtist>();
                cfg.CreateMap<List<SoloistUpdateRoleArtistDto>, IEnumerable<RoleArtist>>();
                cfg.CreateMap<RoleArtist, SoloistResultRoleArtistDto>();
                cfg.CreateMap<List<RoleArtist>, IEnumerable<SoloistResultRoleArtistDto>>();

                cfg.CreateMap<GenderGetGendersDto, Gender>();
                cfg.CreateMap<GenderInsertGenderDto, Gender>();
                cfg.CreateMap<Gender, GenderResultGenderDto>();
                cfg.CreateMap<List<Gender>, IEnumerable<GenderResultGenderDto>>();
                cfg.CreateMap<GenderUpdateGenderDto, Gender>();

                cfg.CreateMap<SoloistGetArtistsDto, Artist>();
                cfg.CreateMap<SoloistGetSoloistsDto, Soloist>();
                cfg.CreateMap<SoloistInsertSoloistDto, Soloist>();
                cfg.CreateMap<Artist, SoloistResultArtistDto>();
                cfg.CreateMap<Soloist, SoloistResultSoloistDto>();
                cfg.CreateMap<List<Soloist>, IEnumerable<SoloistResultSoloistDto>>();
                cfg.CreateMap<Gender, SoloistResultGenderDto>();
                cfg.CreateMap<ConcertProtagonist, SoloistResultConcertDto>()
                    .ForMember(dto => dto.TourName, x => x.MapFrom(prot => prot.Concert.TourName))
                    .ForMember(dto => dto.Date, x => x.MapFrom(prot => prot.Concert.Date))
                    .ForMember(dto => dto.Price, x => x.MapFrom(prot => prot.Concert.Price))
                    .ForMember(dto => dto.TicketCount, x => x.MapFrom(prot => prot.Concert.TicketCount))
                    .ForMember(dto => dto.Location, x => x.MapFrom(prot => prot.Concert.Location));

                cfg.CreateMap<SoloistUpdateSoloistDto, Soloist>();

                cfg.CreateMap<UserGetUsersDto, User>();
                cfg.CreateMap<UserInsertUserDto, User>();
                cfg.CreateMap<User, UserResultUserDto>();
                cfg.CreateMap<UserUpdateUserDto, User>();
                cfg.CreateMap<UserChangePasswordDto, UserChangePassword>();
                cfg.CreateMap<UserRoleDto, UserRole>();
                cfg.CreateMap<List<UserRoleDto>, IEnumerable<UserRole>>();
                cfg.CreateMap<UserRole, UserRoleDto>().ForMember(x => x.Name, y => y.MapFrom(y => y.Role.Name));
                cfg.CreateMap<List<UserRole>, IEnumerable<UserRoleDto>>();

                cfg.CreateMap<ConcertGetConcertsDto, ConcertFilter>();
                cfg.CreateMap<ConcertGetDateRangeConcertsDto, DateRange>();

                cfg.CreateMap<ConcertInsertConcertDto, Concert>();
                cfg.CreateMap<ConcertInsertProtagonistDto, ConcertProtagonist>();
                cfg.CreateMap<ConcertUpdateConcertDto, Concert>();
                cfg.CreateMap<ConcertUpdateProtagonistDto, ConcertProtagonist>();

                cfg.CreateMap<Location, ConcertResultLocationDto>();
                cfg.CreateMap<Country, ConcertResultCountryDto>();
                cfg.CreateMap<ConcertInsertCountryDto, Country>();
                cfg.CreateMap<ConcertInsertLocationDto, Location>();
                cfg.CreateMap<Location, BandResultLocationDto>();
                cfg.CreateMap<Country, BandResultCountryDto>();
                cfg.CreateMap<Location, SoloistResultLocationDto>();
                cfg.CreateMap<Country, SoloistResultCountryDto>();

                cfg.CreateMap<Concert, ConcertResultConcertDto>();
                cfg.CreateMap<ConcertProtagonist, ConcertGetMusicalProtagonistDto>()
                    .ForMember(dto => dto.Name, x => x.MapFrom(prot => prot.Protagonist.Name));

                cfg.CreateMap<TicketStatus, TicketStatusDto>();
                cfg.CreateMap<Ticket, TicketSellTicketResultDto>();
                cfg.CreateMap<Ticket, TicketBuyTicketResultDto>();
                cfg.CreateMap<Ticket, TicketScanTicketResultDto>();
                cfg.CreateMap<TicketSellTicketDto, TicketSell>();
                cfg.CreateMap<TicketBuyTicketDto, TicketBuy>();
                cfg.CreateMap<Ticket, TicketGetTicketResultDto>();
                cfg.CreateMap<Concert, TicketConcertDto>();
                cfg.CreateMap<List<Ticket>, IEnumerable<TicketGetTicketResultDto>>();

                cfg.CreateMap<User, SecurityLoggedUser>();
                cfg.CreateMap<UserRole, SecurityUserRole>().ForMember(x => x.Name, y => y.MapFrom(y => y.Role.Name));

                cfg.CreateMap<ConcertDto, Concert>();
                cfg.CreateMap<IEnumerable<ConcertProtagonistDto>, List<ConcertProtagonist>>();
                cfg.CreateMap<ConcertProtagonistDto, ConcertProtagonist>();
                cfg.CreateMap<Role, RolesResultDto>();
                cfg.CreateMap<RoleArtist, RolesArtistResultDto>();

                cfg.CreateMap<List<Concert>, IEnumerable<ConcertDto>>();
                cfg.CreateMap<Concert, ConcertDto>();
                cfg.CreateMap<Gender, GenderDto>();
                cfg.CreateMap<MusicalProtagonist, ProtagonistDto>();
                cfg.CreateMap<ProtagonistDto, MusicalProtagonist>();
                cfg.CreateMap<ConcertProtagonist, ConcertProtagonistDto>();

                cfg.CreateMap<ArtistInsertUserDto, User>();
                cfg.CreateMap<ArtistUpdateUserDto, User>();
                cfg.CreateMap<Country, CountryResultDto>();
                cfg.CreateMap<ConcertUpdateCountryDto, Country>();
                cfg.CreateMap<ConcertUpdateLocationDto, Location>();
            });
            mapper = config.CreateMapper();
        }


        [TestMethod]
        public void GetMethodsTest()
        {
            List<string> methodsTest = service.GetMethods();
            Assert.IsTrue(2 == methodsTest.Count);
        }

        [TestMethod]
        public void ExportImportationSuccessXML()
        {
            InitTest();
            service.ImportData("XML", importPathFromProjectXML);
            service.ExportData("XML", exportPathFromProjectXML);
            Assert.IsTrue(!fileComparator.IsEmpty(exportPathFromProjectXML));
            Assert.IsTrue(fileComparator.CompareFiles(exportPathFromProjectXML, fileToComparePathFromProjectXML));
        }

        [TestMethod]
        public void ExportImportationSuccessJSON()
        {
            InitTest();
            service.ImportData("JSON", importPathFromProjectJSON);
            service.ExportData("JSON", exportPathFromProjectJSON);
            Assert.IsTrue(!fileComparator.IsEmpty(exportPathFromProjectJSON));
            Assert.IsTrue(fileComparator.CompareFiles(exportPathFromProjectJSON, fileToComparePathFromProjectJSON));
        }

        [TestMethod]
        public void CrossedImportationXMLToJSONTest()
        {
            InitTest();
            service.ImportData("XML", importPathFromProjectXML);
            service.ExportData("JSON", exportPathFromProjectJSON);
            Assert.IsTrue(!fileComparator.IsEmpty(exportPathFromProjectJSON));
            Assert.IsTrue(fileComparator.CompareFiles(exportPathFromProjectJSON, fileToComparePathFromProjectJSON));
        }

        [TestMethod]
        public void CrossedImportationJSONToXMLTest()
        {
            InitTest();
            service.ImportData("JSON", importPathFromProjectJSON);
            service.ExportData("XML", exportPathFromProjectXML);
            Assert.IsTrue(!fileComparator.IsEmpty(exportPathFromProjectXML));
            Assert.IsTrue(fileComparator.CompareFiles(exportPathFromProjectXML, fileToComparePathFromProjectXML));
        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ExportMethodNotExist()
        {
            InitTest();
            service.ExportData("", "");
        }
    }
}
