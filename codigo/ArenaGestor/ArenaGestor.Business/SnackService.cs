using ArenaGestor.BusinessHelpers;
using ArenaGestor.BusinessInterface;
using ArenaGestor.DataAccessInterface;
using ArenaGestor.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArenaGestor.Business
{
    public class SnackService : ISnackService
    {

        private ISnackManagement snackManagement;
        private ISecurityService securityService;

        public SnackService(ISnackManagement snackManagement, ITicketStatusManagement ticketStatusManagement, ISecurityService securityService)
        {
            this.snackManagement = snackManagement;
            this.securityService = securityService;
        }


        public Snack InsertSnack(Snack snack)
        {
            snack.ValidSnack();
            snackManagement.InsertSnack(snack);
            snackManagement.Save();
            return snack;
        }

        public Snack UpdateSnack(Snack snack)
        {
            snack.ValidSnack();
            Snack snackToUpdate = snackManagement.GetSnackById(snack.SnackId);
            if (snackToUpdate == null)
            {
                throw new NullReferenceException($"El snack con id: {snack.SnackId} no existe.");
            }
            snackToUpdate.Price = snack.Price;
            snackToUpdate.Quantity = snack.Quantity;
            snackToUpdate.Name = snack.Name;
            snackManagement.UpdateSnack(snack);
            snackManagement.Save();
            return snackToUpdate;
        }

        public void DeleteSnack(int snackId)
        {
            CommonValidations.ValidId(snackId);
            Snack snackToDelete = snackManagement.GetSnackById(snackId);
            if (snackToDelete == null)
            {
                throw new NullReferenceException($"El snack con el id: {snackId} no existe.");
            }
            snackManagement.DeleteSnack(snackToDelete);
            snackManagement.Save();
        }

        public List<Snack> BuySnack(string token, List<Snack> snacks)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Snack> GetSnacks(string token)
        {
            throw new NotImplementedException();
        }

        public Snack GetSnackById(int snackId)
        {
            throw new NotImplementedException();
        }
    }
}
