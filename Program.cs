using Corsi.Models.Services.Application;
using Corsi.Models.Services.Infrastracture;
using Corsi.Models.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Crea nuova istanzia del servizio ogni volta che un componente
// ne ha bisogno. Una volta usata la distrugge (garbage collector).
// Uso quando ho interfaccia semplice no grande logica
builder.Services.AddTransient<ICourseService, AdoNetCourseService>();
builder.Services.AddTransient<IDatabaseAccess, SqliteDatabaseAccess>();

// Crea nuova istanzia del servizio ogni volta che un componente
// ne ha bisogno. L'istanza può essere riusata all'interno della
// stessa istanza HTTPS.
// Uso quando ho interfaccia con media logica 
//(Es. db context entity framework)
//builder.Services.AddScoped<ICourseService, CourseService>();

// Crea nuova istanzia del servizio la inietta anche in richieste HTTP
// diverse e concorrenti. Ho solo UNA istanza nell'applicazione.
// Uso quando servizi che funzionano anche al di fuori di una singola
// richiesta HTTP. 
// Attenzione se utilizza variabili interne, la classe deve essere Thread-Safe
// utilizzando Interlocked che fa passare un Thread solo alla volta.
// Es. Servizio invio mail (una alla volta)
//builder.Services.AddSingleton<ICourseService, CourseService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//Routing
//controller/Action/param
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
