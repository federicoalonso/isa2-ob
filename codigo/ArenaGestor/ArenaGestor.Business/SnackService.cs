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

        public List<Snack> BuySnack(string token, List<Snack> snacks)
        {
            if (snacks == null)
            {
                throw new ArgumentException("Datos inválidos en la compra.");
            }
            if(snacks.Count == 0)
            {
                throw new ArgumentException("Seleccione snacks para comprar.");
            }
            foreach(Snack snack in snacks)
            {
                snack.ValidSnack();
            }
            var user = securityService.GetUserOfToken(token);
            if (user == null)
            {
                throw new NullReferenceException("El usuario no está logueado.");
            }
            List<Snack> snacksUpdate = new List<Snack>();
            try
            {
                foreach(Snack snack in snacks)
                {
                    var snackToUpdate = snackManagement.GetSnackById(snack.SnackId);
                    if (snackToUpdate == null)
                    {
                        throw new NullReferenceException("SnackId no existe en el sistema");
                    }
                    if (snackToUpdate.Quantity < snack.Quantity)
                    {
                        throw new NullReferenceException("La cantidad de snacks solicitada supera el stock disponible");
                    }
                    snackToUpdate.Quantity -= snack.Quantity;
                    snacksUpdate.Add(snackToUpdate);
                }
            } catch (Exception e)
            {
                
                if (e.Message.Equals("La cantidad de snacks solicitada supera el stock disponible"))
                {
                    throw new NullReferenceException("La cantidad de snacks solicitada supera el stock disponible");
                }
                else
                {
                    throw new NullReferenceException("El snack no existe.");                
                }

            }
            if (snacksUpdate.Count == 0)
            {
                throw new NullReferenceException("Error al acceder al producto seleccionado, intente nuevamente.");
            }
            foreach (Snack snackUpdate in snacksUpdate)
            {
                snackManagement.UpdateSnack(snackUpdate);

            }
            snackManagement.Save();
            return snacksUpdate;
        }

        public IEnumerable<Snack> GetSnacks(string token)
        {
            var user = securityService.GetUserOfToken(token);
            if (user == null)
            {
                throw new NullReferenceException("El usuario no está logueado");
            }
            return snackManagement.GetSnacks();
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

        public Snack GetSnackById(int snackId)
        {
            CommonValidations.ValidId(snackId);
            Snack snack = snackManagement.GetSnackById(snackId);
            if (snack == null)
            {
                throw new NullReferenceException("El snack no existe");
            }
            return snack;
        }
    }
}
