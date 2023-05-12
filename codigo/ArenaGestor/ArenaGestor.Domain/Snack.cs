using ArenaGestor.BusinessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArenaGestor.Domain
{
    public class Snack
    {
        public int SnackId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Range(0.0, Double.MaxValue)]
        [Required]
        public double Price { get; set; }
        [Range(0, Int32.MaxValue)]
        [Required]
        public int Quantity { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Snack other
                && (SnackId == other.SnackId);
        }

        public void ValidSnack()
        {
            if (!CommonValidations.ValidRequiredString(this.Name))
            {
                throw new ArgumentException("El nombre del snack es un campo requerido");
            }
            if (this.Name.Length > 50)
            {
                throw new ArgumentException("El nombre del snack debe tener como máximo 50 caracteres");
            }
            if (this.Price < 0)
            {
                throw new ArgumentException("El valor del snack debe ser mayor a 0");
            }
            if (this.Quantity < 0)
            {
                throw new ArgumentException("La cantidad de snacks debe ser mayor a 0");
            }
        }

    }
}
