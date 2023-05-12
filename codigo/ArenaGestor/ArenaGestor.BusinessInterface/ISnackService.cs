using ArenaGestor.Domain;
using System;
using System.Collections.Generic;

namespace ArenaGestor.BusinessInterface
{
    public interface ISnackService
    {
        List<Snack> BuySnack(string token, List<Snack> snacks);
        IEnumerable<Snack> GetSnacks(string token);
        Snack InsertSnack(Snack snack);
        Snack UpdateSnack(Snack snack);
        void DeleteSnack(int snackId);
        Snack GetSnackById(int snackId);
    }
}
