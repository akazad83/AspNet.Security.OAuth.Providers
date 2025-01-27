﻿/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace AspNet.Security.OAuth.Lichess
{
    /// <summary>
    /// Defines a set of options used by <see cref="LichessAuthenticationHandler"/>.
    /// </summary>
    public class LichessAuthenticationOptions : OAuthOptions
    {
        public LichessAuthenticationOptions()
        {
            // Pkce is now mandatory for LiChess
            UsePkce = true;

            ClaimsIssuer = LichessAuthenticationDefaults.Issuer;
            CallbackPath = LichessAuthenticationDefaults.CallbackPath;

            AuthorizationEndpoint = LichessAuthenticationDefaults.AuthorizationEndpoint;
            TokenEndpoint = LichessAuthenticationDefaults.TokenEndpoint;
            UserInformationEndpoint = LichessAuthenticationDefaults.UserInformationEndpoint;

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonSubKey(ClaimTypes.GivenName, "profile", "firstName");
            ClaimActions.MapJsonSubKey(ClaimTypes.Surname, "profile", "lastName");
        }

        /// <summary>
        /// Gets or sets the address of the endpoint exposing
        /// the email addresses associated with the logged in user.
        /// </summary>
        public string UserEmailsEndpoint { get; set; } = LichessAuthenticationDefaults.UserEmailsEndpoint;
    }
}
