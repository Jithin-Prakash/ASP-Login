var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.MapGet("/", () => "Working");

List<LoginModel> obj = new List<LoginModel>();
obj.Add(new LoginModel { Username = "user123", Password = "user123"});

app.MapPost("/", (LoginModel login) => {
    if (obj.Any(user => user.Username == login.Username && user.Password == login.Password))
    {
        System.Diagnostics.Debug.WriteLine("Successful!");
        return Results.Created("Success", login);
    }

    System.Diagnostics.Debug.WriteLine("Successful!");
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

    public bool equals(object obj)
    {
        LoginModel? login = obj as LoginModel;
        if (login == null) return false;
        return login.Username == this.Username && login.Password == this.Password;
    }
}
