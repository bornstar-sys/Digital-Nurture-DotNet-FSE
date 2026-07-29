// Question 2: Secure an API Endpoint Using JWT

// Scenario:
// Restrict access to a sensitive endpoint using JWT authentication.

// Step 1: Add [Authorize] to a controller
// Step 2: Test access with and without a valid token

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    // This endpoint is protected - requires valid JWT token
    [HttpGet("data")]
    [Authorize]
    public IActionResult GetSecureData()
    {
        return Ok("This is protected data.");
    }

    // This endpoint is public - no token required
    [HttpGet("public")]
    [AllowAnonymous]
    public IActionResult GetPublicData()
    {
        return Ok("This is public data - no token required.");
    }
}

// Testing with POSTMAN:

// Test 1 - Without Token (401 Unauthorized):
// Method: GET
// URL: https://localhost:[port]/api/secure/data
// No Authorization header
// Expected: 401 Unauthorized

// Test 2 - With Valid Token (200 OK):
// Method: GET
// URL: https://localhost:[port]/api/secure/data
// Headers: Authorization: Bearer [token from Q1 login]
// Expected: 200 OK - "This is protected data."

// Test 3 - Public Endpoint (200 OK without token):
// Method: GET
// URL: https://localhost:[port]/api/secure/public
// No Authorization header
// Expected: 200 OK - "This is public data - no token required."