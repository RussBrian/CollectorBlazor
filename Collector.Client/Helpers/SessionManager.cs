using Collector.Client.Dtos.Login;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Collector.Client.SessionHelpers
{
    public class SessionManager
    {
        private readonly ProtectedSessionStorage _protectedSessionStorage;

        public SessionManager(ProtectedSessionStorage protectedSessionStorage)
        {
            _protectedSessionStorage = protectedSessionStorage;
        }

        public async Task SetSessions(string key, object value) 
            => await _protectedSessionStorage.SetAsync(key, value);

        public async Task<ProtectedBrowserStorageResult<ResLoginDto>> GetSessions(string key)
            => await _protectedSessionStorage.GetAsync<ResLoginDto>(key);

        public async Task DeleteSession(string key) 
            => await _protectedSessionStorage.DeleteAsync(key);
    }
}