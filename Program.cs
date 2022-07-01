var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.MapGet("/", () => "Working");

List<LoginModel> obj = new List<LoginModel>();
obj.Add(new LoginModel { Username = "user123", Password = "user123"});

app.MapPost("/", (LoginModel login) => {
    if (obj.Contains(login))
        return Results.Created("Success", login);
    return Results.Created("Not working",  "Not Working");
});


app.Run();

public class LoginModel
{
    public LoginModel()
    {
    }

    public LoginModel(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string? Username { get; set; }
    public string? Password { get; set; }
}
public class AboutModel : Microsoft.AspNetCore.Mvc.RazorPages.PageModel
{
    private readonly ILogger _logger;

    public AboutModel(ILogger<AboutModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("About page visited at {DT}",
            DateTime.UtcNow.ToLongTimeString());
    }
}