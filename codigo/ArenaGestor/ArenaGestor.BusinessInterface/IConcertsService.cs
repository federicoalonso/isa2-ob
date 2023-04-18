using ArenaGestor.Domain;
using System.Collections.Generic;

namespace ArenaGestor.BusinessInterface
{
    public interface IConcertsService
    {
        Concert GetConcertById(int concertId);
        IEnumerable<Concert> GetConcerts(ConcertFilter concertFilter = null);
        IEnumerable<Concert> GetConcerts(string token, ConcertFilter concertFilter = null);
        Concert InsertConcert(Concert concert);
        Concert InsertConcertFromImport(Concert concert);
        ConcertsInsertResult InsertConcerts(List<Concert> concert);
        ConcertsInsertResult InsertConcertsFromImport(List<Concert> concert);
        Concert UpdateConcert(Concert concert);
        void DeleteConcert(int concertId);
    }
}
