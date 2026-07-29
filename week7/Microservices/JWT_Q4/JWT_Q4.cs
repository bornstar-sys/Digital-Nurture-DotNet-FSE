// Question 4: Validate JWT Token Expiry and Handle Unauthorized Access

// Scenario:
// Handle expired or invalid tokens gracefully with custom messages.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Step 1: Program.cs - Add JWT Bearer Events
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        // Step 2: Handle JWT Events
        options.Events = new JwtBearerEvents
        {
            // Fires when authentication fails
            OnAuthenticationFailed = context =>
            {
                // Check if token is expired
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                    context.Response.Headers.Add("Token-Error", "Token has expired");
                }
                return Task.CompletedTask;
            },

            // Fires when request is unauthorized
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(
                    new { error = "You are not authorized. Please provide a valid token." });
                return context.Response.WriteAsync(result);
            },

            // Fires when user does not have required role
            OnForbidden = context =>
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                var result = System.Text.Json.JsonSerializer.Serialize(
                    new { error = "You do not have permission to access this resource." });
                return context.Response.WriteAsync(result);
            }
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Step 3: Generate Short-Lived Token for Testing Expiry
// In AuthController - change expires to 1 minute for testing:
/*
var token = new JwtSecurityToken(
    issuer: "MyAuthServer",
    audience: "MyApiUsers",
    claims: claims,
    expires: DateTime.Now.AddMinutes(1),  // Short expiry for testing
    signingCredentials: creds);
*/

// Testing with POSTMAN:

// Test 1 - Valid Token (200 OK):
// Generate token from /api/auth/login
// Use token immediately on protected endpoint
// Expected: 200 OK

// Test 2 - Expired Token (401 + Token-Expired header):
// Generate token with 1 minute expiry
// Wait 1 minute
// Use expired token on protected endpoint
// Expected: 401 Unauthorized
// Response Header: Token-Expired: true
// Response Body: { "error": "You are not authorized..." }

// Test 3 - Invalid Token (401):
// Modify token manually
// Use on protected endpoint
// Expected: 401 Unauthorized

// Test 4 - Wrong Role (403 Forbidden):
// Login as "user" role
// Access Admin-only endpoint
// Expected: 403 Forbidden
// Response Body: { "error": "You do not have permission..." }

// Key Concepts:
// OnAuthenticationFailed - Fires when token validation fails (expired, invalid)
// OnChallenge           - Fires when 401 response is being sent
// OnForbidden           - Fires when 403 response is being sent
// SecurityTokenExpiredException - Specific exception for expired tokens
// Token-Expired header  - Custom header to signal client that token expired