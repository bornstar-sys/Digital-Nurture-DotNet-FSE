// Question 3: Add Role-Based Authorization

// Scenario:
// Allow only users with the "Admin" role to access certain endpoints.

// Step 1: Modify Token Generation - Add Role Claim

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// Modified AuthController - Add Role to Token
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "password")
        {
            var token = GenerateJwtToken(model.Username, "Admin");
            return Ok(new { Token = token });
        }
        else if (model.Username == "user" && model.Password == "password")
        {
            var token = GenerateJwtToken(model.Username, "User");
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }

    private string GenerateJwtToken(string username, string role)
    {
        // Step 1: Add Role Claim to token
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtToken"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "MyAuthServer",
            audience: "MyApiUsers",
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

// Step 2: AdminController - Only Admin Role Allowed
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    // Only Admin role can access this
    [HttpGet("dashboard")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminDashboard()
    {
        return Ok("Welcome to the admin dashboard.");
    }

    // Both Admin and User roles can access this
    [HttpGet("reports")]
    [Authorize(Roles = "Admin,User")]
    public IActionResult GetReports()
    {
        return Ok("Reports - accessible by Admin and User.");
    }
}

// Testing with POSTMAN:

// Test 1 - Login as Admin:
// Method: POST
// URL: https://localhost:[port]/api/auth/login
// Body: { "username": "admin", "password": "password" }
// Expected: 200 OK with Admin token

// Test 2 - Login as User:
// Method: POST
// URL: https://localhost:[port]/api/auth/login
// Body: { "username": "user", "password": "password" }
// Expected: 200 OK with User token

// Test 3 - Admin token on /admin/dashboard:
// Method: GET
// URL: https://localhost:[port]/api/admin/dashboard
// Headers: Authorization: Bearer [Admin token]
// Expected: 200 OK - "Welcome to the admin dashboard."

// Test 4 - User token on /admin/dashboard:
// Method: GET
// URL: https://localhost:[port]/api/admin/dashboard
// Headers: Authorization: Bearer [User token]
// Expected: 403 Forbidden