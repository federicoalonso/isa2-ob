using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArenaGestor.DataAccess.Managements
{
    public class SnackManagement : ISnackManagement
    {
        private readonly DbSet<Snack> snacks;
        private readonly DbContext context;

        public SnackManagement(DbContext context)
        {
            this.snacks = context.Set<Snack>();
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Snack> GetSnacks()
        {
            return snacks;
        }

        public void InsertSnack(Snack snack)
        {
            snacks.Add(snack);
        }

        public Snack GetSnackById(int snackId)
        {
            Func<Snack, bool> filter = new Func<Snack, bool>(snack => snack.SnackId == snackId);
            return snacks.AsNoTracking().FirstOrDefault(filter);
        }

        public void DeleteSnack(Snack snack)
        {
            snacks.Remove(snack);
        }

        public void UpdateSnack(Snack snack)
        {
            snacks.Update(snack);
        }
    }
}
