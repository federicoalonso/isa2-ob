using ArenaGestor.BusinessInterface;
using ArenaGestor.Domain;
using ArenaGestor.Extensions.DTO;
using ArenaGestor.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using ArenaGestor.APIContracts.Concert;
using Microsoft.AspNetCore.Authorization;
using ArenaGestor.DataAccessInterface;
using System.Runtime.CompilerServices;

namespace ArenaGestor.Business
{
    public class ImportExportService : IImportExportService
    {
        private readonly IConcertsService concertsService;
        private readonly IReflectionHelpers reflectionHelpers;
        private readonly IMapper mapper;
        private readonly ILocationManagement locationManager;
        private const int locationByDefault = 4;

        public ImportExportService(IConcertsService concertsService, IReflectionHelpers reflectionHelpers, IMapper mapper, ILocationManagement locationManager)
        {
            this.concertsService = concertsService;
            this.reflectionHelpers = reflectionHelpers;
            this.mapper = mapper;
            this.locationManager = locationManager;
        }

        public List<string> GetMethods()
        {
            return this.reflectionHelpers.GetMethods();
        }

        public void ExportData(string method, string path)
        {
            IImportExportMethod importExportMethod = this.reflectionHelpers.GetMethod(method);
            if (importExportMethod == null)
            {
                throw new ArgumentException("ImportExport method not found");
            }       
            var concerts = concertsService.GetConcerts();
            var resultDto = new List<ConcertDto>();
            foreach ( var concert in concerts)
            {
                ConcertDto concertDTO = mapper.Map<ConcertDto>(concert);
                resultDto.Add(concertDTO);
            }
            importExportMethod.Export(path, resultDto);
        }

        public ConcertsInsertResult ImportData(string method, string path)
        {
            IImportExportMethod importExportMethod = this.reflectionHelpers.GetMethod(method);
            if (importExportMethod == null)
            {
                throw new ArgumentException("ImportExport method not found");
            }
            var concerts = importExportMethod.Import(path);
            var concertsMapped = new List<Concert>();
            Location location = locationManager.GetLocationById(locationByDefault);
            foreach (var concertDto in concerts)
            {
                var concertProtagonists = new List<ConcertProtagonist>();

                Concert concert = mapper.Map<Concert>(concertDto);
                foreach (var concertProtagonistDto in concertDto.Protagonists)
                {
                    ConcertProtagonist concertProtagonist = new ConcertProtagonist
                    {
                        ConcertId = concertDto.ConcertId,
                        Concert = concert,
                        MusicalProtagonistId = concertProtagonistDto.MusicalProtagonistId
                    };
                    concertProtagonists.Add(concertProtagonist);
                }
                concert.Protagonists = concertProtagonists;
                concert.LocationId = location.LocationId;
                concert.Location = location;
                concertsMapped.Add(concert);
            }
            ConcertsInsertResult result = concertsService.InsertConcertsFromImport(concertsMapped);
            return result;
        }
    }
}
