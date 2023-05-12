using ArenaGestor.Domain;
using System;
using System.Collections.Generic;

namespace ArenaGestor.DataAccessInterface
{
    public interface ISnackManagement
    {
        IEnumerable<Snack> GetSnacks();
        void InsertSnack(Snack snack);
        Snack GetSnackById(int snackId);
        void DeleteSnack(Snack snack);
        void UpdateSnack(Snack snack);
        void Save();
    }
}
