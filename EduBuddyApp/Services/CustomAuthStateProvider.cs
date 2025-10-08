using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _anonymous =
            new ClaimsPrincipal(new ClaimsIdentity());

        private ClaimsPrincipal _currentUser;

        public CustomAuthStateProvider() => _currentUser = _anonymous;

        public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
            Task.FromResult(new AuthenticationState(_currentUser));

        // Call this after a successful login
        public void MarkUserAsAuthenticated(string userName)
        {
            var identity = new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    // add role/claims here if you need them
                },
                authenticationType: "FakeAuth");

            _currentUser = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(_currentUser)));
        }

        // Call this on logout
        public void MarkUserAsLoggedOut()
        {
            _currentUser = _anonymous;
            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(_currentUser)));
        }
    }
}