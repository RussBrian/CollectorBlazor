using Collector.Client.Dtos.Login;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace Collector.Client.SessionHelpers
{
    public class SessionManager : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymus = new ClaimsPrincipal(new ClaimsIdentity());
        public SessionManager(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSessionStorageResult = await _sessionStorage.GetAsync<ResLoginDto>("session");
                var userSession = userSessionStorageResult.Success ? userSessionStorageResult.Value : null;
                if (userSession == null)
                {
                    return await Task.FromResult(new AuthenticationState(_anonymus));
                }
                else
                {
                    var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                    {
                      new Claim(ClaimTypes.Name, userSession.UserName),
                      new Claim(ClaimTypes.Role, userSession.RolName),
                      new Claim(ClaimTypes.Email, userSession.Email),
                      new Claim("Jwt", userSession.IdToken),
                      new Claim("UserId", userSession.UserId.ToString())
                        }));
                    return await Task.FromResult(new AuthenticationState(claimsPrincipal));
                }
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymus));
            }
        }


        public async Task UpdateAuthenticationState(ResLoginDto model)
        {
            ClaimsPrincipal claimsPrincipal;

            if (model != null)
            {
                await _sessionStorage.SetAsync("session", model);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                      new Claim(ClaimTypes.Name, model.UserName),
                      new Claim(ClaimTypes.Role, model.RolName),
                      new Claim(ClaimTypes.Email, model.Email),
                      new Claim("Jwt", model.IdToken),
                      new Claim("UserId", model.UserId.ToString())

                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("session");
                claimsPrincipal = _anonymus;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}