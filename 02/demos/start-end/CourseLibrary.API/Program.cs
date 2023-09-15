

using CourseLibrary.API;

var builder = WebApplication.CreateBuilder(args);
  
var app = builder
    //++1.Configurar servicios
       .ConfigureServices()
       //++2.Configurar middleware(peticiones)
       .ConfigurePipeline();

// for demo purposes, delete the database & migrate on startup so 
// we can start with a clean slate
await app.ResetDatabaseAsync();

// run the app
app.Run();
