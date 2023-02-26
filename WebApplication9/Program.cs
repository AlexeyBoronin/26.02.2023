using WebApplication9;

var builder = WebApplication.CreateBuilder();
//builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logget.txt"));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
var app = builder.Build();

/*app.Run(async (context) =>
{
    var path=context.Request.Path;
    app.Logger.LogCritical($"LogCritical {path}");
    app.Logger.LogError($"LogError {path}");
    app.Logger.LogInformation($"LogInformation {path}");
    app.Logger.LogWarning($"LogWarning{path}");

    await context.Response.WriteAsync("Hello");
});*/
/*ILoggerFactory loggerFactory1=LoggerFactory.Create(builder=>builder.AddConsole());
ILogger logger1 = loggerFactory1.CreateLogger("1");
app.Run(async (context) =>
{
    logger1.LogInformation($"Response Path: {context.Request.Path}");
    await context.Response.WriteAsync("Hello");
});*/
/*app.Map("/hello", (ILoggerFactory loggerFactory1) =>
{
    ILogger logger1 = loggerFactory1.CreateLogger("MapLogger");
    logger1.LogInformation($"Path: /hello  Time: {DateTime.Now.ToLongTimeString()}");
    return "Hello";
});*/

/*var loggerFactory1 = LoggerFactory.Create(builder => builder.AddDebug());
ILogger logger1=loggerFactory1.CreateLogger<Program>();
app.Run(async (context) =>
{
    logger1.LogInformation($"Request Path: {context.Request.Path}");
    await context.Response.WriteAsync("hello");
});*/
/*app.Run(async (context) =>
{
    app.Logger.LogInformation($"Path: {context.Request.Path} Time: {DateTime.Now.ToLongTimeString()}");
    await context.Response.WriteAsync("hello");
});*/
/*app.Use(async (context, next) =>
{
    context.Items["text"] = "Hello from HttpContext.Items";
    await next.Invoke();
});

app.Run(async (context) => await context.Response.WriteAsync($"Text: {context.Items["text"]}"));*/
/*app.Use(async (context,next) =>
{
    context.Items.Add("message", "Hello world!");
    
    await next.Invoke();
});
app.Run(async(context)=>
{
    if (context.Items.ContainsKey("message"))
        await context.Response.WriteAsync($"Message: {context.Items["message"]}");
    else
        await context.Response.WriteAsync("Random Text");
});*/

/*app.Run(async (context) =>
{
    if(context.Request.Cookies.ContainsKey("name"))
    {
        string? name = context.Request.Cookies["name"];
        await context.Response.WriteAsync($"Hello {name}!");
    }
    else
    {
        context.Response.Cookies.Append("name", "Ivan");
        await context.Response.WriteAsync("Hello world!");
    }
});*/

app.UseSession();
app.Run(async (context) =>
{
    if (context.Session.Keys.Contains("human"))
    {
        Human? human = context.Session.Get<Human>("human");
        await context.Response.WriteAsync($"Hello {human?.Name}, your age: {human?.Age}");
    }
        //await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
    else
    {
        Human human = new Human { Name = "Ivan", Age = 23 };
        //context.Session.SetString("name", "Ivan");
        context.Session.Set<Human>("human",human);
        await context.Response.WriteAsync("Hello World!");
    }
});

app.Run();

class Human
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}
