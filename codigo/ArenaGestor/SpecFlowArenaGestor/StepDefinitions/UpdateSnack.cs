using ArenaGestor.APIContracts.Snack;
using ArenaGestor.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowArenaGestor.StepDefinitions
{
    [Binding]
    public class UpdateSnack
    {
        private readonly ScenarioContext context;
        private readonly SnackDto snackDto = new SnackDto();
        private readonly Assistant assistant = new Assistant();
        private string role;


        public UpdateSnack(ScenarioContext context)
        {
            this.context = context;
            this.role = "";
        }

        [Given(@"un usuario con rol ""([^""]*)"" logueado")]
        public void GivenUnUsuarioConRolLogueado(string rol)
        {
            this.role = rol;
        }


        [Given(@"ingreso los datos caseId ""([^""]*)"", descripcion ""([^""]*)"", precio ""([^""]*)"" y cantidad ""([^""]*)"" y existe un snack con dicho caseId")]
        public void GivenIngresoLosDatosCaseIdDescripcionPrecioYCantidadYExisteUnSnackConDichoCaseId(int id, string descripcion, int precio, int cantidad)
        {
            snackDto.SnackId = id;
            snackDto.Name = descripcion;
            snackDto.Price = precio;
            snackDto.Quantity = cantidad;
        }

        [Given(@"ingreso los datos caseId ""([^""]*)"", descripcion ""([^""]*)"", precio ""([^""]*)"" y cantidad ""([^""]*)"" y no existe un snack con dicho caseId")]
        public void GivenIngresoLosDatosCaseIdDescripcionPrecioYCantidadYNoExisteUnSnackConDichoCaseId(int id, string descripcion, int precio, int cantidad)
        {
            snackDto.SnackId = id;
            snackDto.Name = descripcion;
            snackDto.Price = precio;
            snackDto.Quantity = cantidad;
        }


        [When(@"solicito editar el ""([^""]*)"" con los referidos nuevos datos")]
        public async Task WhenSolicitoEditarElConLosReferidosNuevosDatos(string operation)
        {
            HttpResponseMessage response = await assistant.SendRequest(operation, snackDto, role, "Put");
            context.Set(response.StatusCode, "ResponseStatusCode");
        }

        [Then(@"Veo el mensaje resultante con el codigo ""([^""]*)""")]
        public void ThenVeoElMensajeResultanteConElCodigo(int statusCode)
        {
            Assert.Equal(statusCode, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }
    }
}
