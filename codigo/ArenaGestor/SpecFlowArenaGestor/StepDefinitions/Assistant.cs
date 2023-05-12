using ArenaGestor.APIContracts.Security;
using ArenaGestor.APIContracts.Snack;
using ArenaGestor.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SpecFlowArenaGestor.StepDefinitions
{
    internal class Assistant
    {
        private readonly HttpClient client;
        private readonly string connectionPath = "https://localhost:44372/Security/login";
        private readonly SecurityLoginDto securityLoginDto = new SecurityLoginDto();
        private readonly Credentials credentials = new Credentials();
        private readonly string port = "44372";
        string token;

        public Assistant() { 
            client = new HttpClient();
        }

        private async Task<string> LoginFromRole(RoleCode role)
        {
            switch (role)
            {
                case RoleCode.Administrador:
                    return await LogInAsync(credentials.EmailAdministrador, credentials.PasswordAdministrador);
                case RoleCode.Vendedor:
                    return await LogInAsync(credentials.EmailVendedor, credentials.PasswordVendedor);
                case RoleCode.Acomodador:
                    return await LogInAsync(credentials.EmailAcomodador, credentials.PasswordAcomodador); 
                case RoleCode.Espectador:
                    return await LogInAsync(credentials.EmailEspectador, credentials.PasswordEspectador); 
                case RoleCode.Artista:
                    return await LogInAsync(credentials.EmailArtista, credentials.PasswordArtista); 
            }
            return await LogInAsync(credentials.EmailSuperUsuario, credentials.PasswordSuperUsuario);
        }

        private async Task<string> LogInAsync(string email, string password)
        {
            securityLoginDto.Email = email;
            securityLoginDto.Password = password;
            string credentials = JsonConvert.SerializeObject(securityLoginDto);
            var loginRequest = new HttpRequestMessage(HttpMethod.Post, connectionPath)
            {
                Content = new StringContent(credentials)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
            // create an http client
            using HttpResponseMessage loginResponse = await client.SendAsync(loginRequest).ConfigureAwait(true);
            string tokenResponse = await loginResponse.Content.ReadAsStringAsync();
            var tokenJSON = JsonConvert.DeserializeObject<object>(tokenResponse);
            string[] token = tokenJSON.ToString().Split(':');
            string tokenValue = token[1].Substring(2, token[1].Length - 6);
            return tokenValue;
        }

        public async Task<HttpResponseMessage> SendRequest(string operation, object snackDto, string role, string verb)
        {
            var roleCode = GetRole(role);
            token = await LoginFromRole(roleCode);
            string requestBody = JsonConvert.SerializeObject(snackDto);
            HttpRequestMessage request = CreateRequest(operation, requestBody, verb);
            request.Headers.Add("token", token);
            // let's post
            var response = await client.SendAsync(request).ConfigureAwait(false);
            return response;
        }

        private RoleCode GetRole(string role)
        {
            var ret = RoleCode.Espectador; 
            switch (role)
            {
                case "Administrador":
                    ret =  RoleCode.Administrador;
                    break;
                case "Vendedor":
                    ret = RoleCode.Vendedor;
                    break;
                case "Acomodador":
                    ret = RoleCode.Acomodador;
                    break;
                case "Espectador":
                    ret = RoleCode.Espectador;
                    break;
                case "Artista":
                    ret = RoleCode.Artista;
                    break;
            }
            return ret;
        }

        private HttpRequestMessage CreateRequest(string operation, string requestBody, string verb)
        {
            switch (verb)
            {
                case "Post":
                    return CreatePost(operation, requestBody);
                case "Put":
                    return CreatePut(operation, requestBody);
                case "Get":
                    return CreateGet(operation, requestBody);
                case "Delete":
                    return CreateDelete(operation, requestBody);
                default:
                    break;
            }
            // ATENCIÓN: Se deberá de modificar el puerto que está en la línea debajo
            return new HttpRequestMessage(HttpMethod.Post, $"https://localhost:{port}/{operation}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
        }

        private HttpRequestMessage CreatePost(string operation, string requestBody)
        {
            // ATENCIÓN: Se deberá de modificar el puerto que está en la línea debajo
            return new HttpRequestMessage(HttpMethod.Post, $"https://localhost:{port}/{operation}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
        }

        private HttpRequestMessage CreatePut(string operation, string requestBody)
        {
            // ATENCIÓN: Se deberá de modificar el puerto que está en la línea debajo
            return new HttpRequestMessage(HttpMethod.Put, $"https://localhost:{port}/{operation}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
        }

        private HttpRequestMessage CreateGet(string operation, string requestBody)
        {
            // ATENCIÓN: Se deberá de modificar el puerto que está en la línea debajo
            return new HttpRequestMessage(HttpMethod.Get, $"https://localhost:{port}/{operation}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
        }

        private HttpRequestMessage CreateDelete(string operation, string requestBody)
        {
            // ATENCIÓN: Se deberá de modificar el puerto que está en la línea debajo
            return new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:{port}/{operation}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
        }
    }
}
