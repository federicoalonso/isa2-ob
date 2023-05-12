using ArenaGestor.APIContracts.Snack;
using System.Net;

namespace SpecFlowArenaGestor.StepDefinitions
{
    [Binding]
    internal class BuySnackStepsDefinition
    {
        private readonly ScenarioContext context;
        private readonly SnackDto snackDto = new SnackDto();
        private readonly SnackDto snackDto2 = new SnackDto();
        private readonly List<SnackDto> snacksDto = new List<SnackDto>();
        private readonly Assistant assistant = new Assistant();
        private string role;


        public BuySnackStepsDefinition(ScenarioContext context)
        {
            this.context = context;
            role = "Artista";
        }

        [Given(@"un usuario ""(.*)"" logueado en el sistema")]
        public void GivenTheRole(string role)
        {
            this.role = role;
        }

        [Given(@"el nombre del producto ""(.*)""")]
        public void GivenTheDescription(string name)
        {
            snackDto.Name = name;
        }

        [Given(@"de id ""(.*)""")]
        public void GivenTheSnackId(int id)
        {
            snackDto.SnackId = id;
        }

        [Given(@"la cantidad de compra ""(.*)""")]
        public void GivenTheQuantity(int quantity)
        {
            snackDto.Quantity = quantity;
        }

        [Given(@"la cantidad de compra del segundo producto ""(.*)""")]
        public void GivenTheQuantitySecondProduct(int quantity)
        {
            snackDto2.Quantity = quantity;
        }

        [Given(@"con id ""(.*)""")]
        public void GivenTheSnackIdSecondProduct(int id)
        {
            snackDto2.SnackId = id;
        }

        [Given(@"el nombre del segundo producto ""(.*)""")]
        public void GivenTheDescriptionSecondProduct(string description)
        {
            snackDto2.Name = description;
        }

        [When(@"solicito la compra del ""(.*)""")]
        public async Task WhenIPostThisRequestToTheOperation(string operation)
        {
            snacksDto.Add(snackDto);
            HttpResponseMessage response = await assistant.SendRequest($"{operation}/cart", snacksDto, role, "Put").ConfigureAwait(false);
            context.Set(response.StatusCode, "ResponseStatusCode");
        }

        [When(@"solicito la compra de varios ""(.*)""")]
        public async Task WhenIPostThisRequestToBuySeveralSnack(string operation)
        {
            snacksDto.Add(snackDto);
            snacksDto.Add(snackDto2);
            HttpResponseMessage response = await assistant.SendRequest($"{operation}/cart", snacksDto, role, "Put").ConfigureAwait(false);
            context.Set(response.StatusCode, "ResponseStatusCode");
        }

        [Then(@"verifico el mensaje con el codigo ""(.*)""")]
        public void ThenISeeTheMessageWitStatusCode(int statusCode)
        {
            Assert.Equal(statusCode, (int)context.Get<HttpStatusCode>("ResponseStatusCode"));
        }
    }
}
