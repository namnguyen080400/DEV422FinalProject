//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//// Read the JWT secret cde from the configuration and convet to bytes
//var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]);

//// Configure JWT authentication
//builder.Services.AddAuthentication(option =>
//{
//    // set the default authencation scheme to JWT
//    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    // set the default challenge scheme to JWT
//    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}
//).AddJwtBearer(options =>
//{
//    //Configure the parameters for validating tokens
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        // Specify that the signing key should be validated
//        ValidateIssuerSigningKey = true,

//        // Set the key used to validate the token's signature
//        IssuerSigningKey = new SymmetricSecurityKey(key),


//        // Disable issuer validation
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});

//var app = builder.Build();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add CORS (optional, if needed in your project).
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add Swagger (optional, for API documentation).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read the JWT secret key from appsettings.json and convert to bytes.
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]);

// Add JWT authentication.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Enable Swagger in development.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Enable CORS and authentication middleware.
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
