using System.Net;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.Domain;
using Microsoft.AspNetCore.Http;

namespace SpecFlowArenaGestor.StepDefinitions
{
    [Binding]
    internal class AddSnackStepsDefinition
    {
        private ScenarioContext context;
        private readonly SnackDto snackDto = new SnackDto();
        private readonly Assistant assistant = new Assistant();
        private string role;

        //private string token;

        public AddSnackStepsDefinition(ScenarioContext context)
        {
            this.context = context;
            role = "Artista";
        }

        [Given(@"un ""(.*)"" logueado en el sistema")]
        public void GivenTheRole(string role)
        {
            this.role = role;
        }

        [Given(@"el nombre ""(.*)""")]
        public void GivenTheDescription(string name)
        {
            snackDto.Name = name;
        }

        [Given(@"el precio ""(.*)""")]
        public void GivenThePrice(double price)
        {
            snackDto.Price = price;
        }

        //[Given(@"el id ""(.*)""")]
        //public void GivenTheID(int id)
        //{
        //    snackDto.SnackId = id;
        //}

        [Given(@"la cantidad ""(.*)""")]
        public void GivenTheQuantity(int quantity)
        {
            snackDto.Quantity = quantity;
        }

        [When(@"solicito el alta del ""(.*)"" generado con esos valores")]
        public async Task WhenIPostThisRequestToTheOperation(string operation)
        {
            HttpResponseMessage response = await assistant.SendRequest(operation, snackDto, role, "Post");
            //try
            //{
            context.Set(response.StatusCode, "ResponseStatusCode");
            //}
            //finally
            //{
            //    // move along, move along
            //}
        }        

        [Then(@"Veo el mensaje con el codigo ""(.*)""")]
        public void ThenISeeTheMessageWitStatusCode(int statusCode)
        {
            Assert.Equal(statusCode, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }
        
        [Then(@"Veo el mensaje con el codigo ""(.*)"" o el error ""(.*)""")]
        public void ThenISeeTheMessageWitStatusCode2(int statusCode1, int statusCode2)
        {
            bool valid = statusCode1 == (int)context.Get<HttpStatusCode>("ResponseStatusCode") || statusCode2 == (int)context.Get<HttpStatusCode>("ResponseStatusCode");
            Assert.True(valid);
        }
    }
}
