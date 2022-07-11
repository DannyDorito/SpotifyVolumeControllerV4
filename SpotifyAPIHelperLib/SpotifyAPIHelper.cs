using SpotifyAPI.Web;

namespace SpotifyAPIHelperLib
{
    public class SpotifyAPIHelper
    {
        private readonly string? ClientID = Environment.GetEnvironmentVariable("CLIENTID");
        private readonly string? ClientSecret = Environment.GetEnvironmentVariable("CLIENTSECRET");


        public async Task<bool> GetAuth()
        {
            var loginRequest = new LoginRequest(
              new Uri("http://localhost:5000"),
              "ClientId",
              LoginRequest.ResponseType.Code
            )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };
            var uri = loginRequest.ToUri();
            return await Task.FromResult(false);
        }

        public async Task GetCallback(string code)
        {
            var response = await new OAuthClient().RequestToken(
              new AuthorizationCodeTokenRequest(ClientID ?? string.Empty, ClientSecret ?? string.Empty, code, new Uri("http://localhost:5000"))
            );
            var config = SpotifyClientConfig
              .CreateDefault()
              .WithAuthenticator(new AuthorizationCodeAuthenticator(ClientID ?? string.Empty, ClientSecret ?? string.Empty, response));

            var spotify = new SpotifyClient(config);
        }

    }
}