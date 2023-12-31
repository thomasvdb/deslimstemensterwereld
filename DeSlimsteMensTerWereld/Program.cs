using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models.PuzzelRonde;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

TeamTracker.Teams.Add(new Team(TeamNames.ValerieEnSam));
TeamTracker.Teams.Add(new Team(TeamNames.AlineEnMario));
TeamTracker.Teams.Add(new Team(TeamNames.LynnEnDries));

OpenDeurTracker.Rondes = new List<OpenDeurRondeDetails>();
OpenDeurTracker.ActiveRonde = 1;
OpenDeurTracker.Rondes.Add(new OpenDeurRondeDetails
{
    Antwoord1 = "Times Like These",
    Antwoord2 = "Dave Grohl",
    Antwoord3 = "Taylor Hawkins",
    Antwoord4 = "Josh Freese"
});

OpenDeurTracker.Rondes.Add(new OpenDeurRondeDetails
{
    Antwoord1 = "Chimay",
    Antwoord2 = "Orval",
    Antwoord3 = "Rochefort",
    Antwoord4 = "Westvleteren"
});

OpenDeurTracker.Rondes.Add(new OpenDeurRondeDetails
{
    Antwoord1 = "I’ll be there for you",
    Antwoord2 = "Matthew Perry",
    Antwoord3 = "Amerikaans",
    Antwoord4 = "Central Perk"
});

PuzzelRondeTracker.Rondes = new List<PuzzelRondeDetails>();
PuzzelRondeTracker.ActiveRonde = 1;
PuzzelRondeTracker.Rondes.Add(new PuzzelRondeDetails
{
    Group1 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Callboys",
        Trefwoord2 = "Ella Leyers",
        Trefwoord3 = "Sporting Hasselt",
        Trefwoord4 = "Nonkels",
        Antwoord = "Rik Verheye"
    },
    Group2 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Days of our ...",
        Trefwoord2 = "It's a good day to save ...",
        Trefwoord3 = "Black ... Matter",
        Trefwoord4 = "...treamen",
        Antwoord = "Lives"
    },
    Group3 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Belangrijk op het strand",
        Trefwoord2 = "Factor 30",
        Trefwoord3 = "Of toch 50?",
        Trefwoord4 = "Goed insmeren!",
        Antwoord = "Zonnecrème"
    }
});

PuzzelRondeTracker.Rondes.Add(new PuzzelRondeDetails
{
    Group1 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Durbuy",
        Trefwoord2 = "Omega Pharma",
        Trefwoord3 = "Pairi Daiza",
        Trefwoord4 = "Anderlecht",
        Antwoord = "Marc Coucke"
    },
    Group2 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Tim Cook",
        Trefwoord2 = "iPod",
        Trefwoord3 = "Cupertino",
        Trefwoord4 = "... Music",
        Antwoord = "Apple"
    },
    Group3 = new PuzzelRondeGroup()
    {
        Trefwoord1 = "Tower ...",
        Trefwoord2 = "Sydney Harbour ...",
        Trefwoord3 = "Golden Gate ...",
        Trefwoord4 = "Brooklyn ...",
        Antwoord = "Bridge"
    }
});

PuzzelRondeTracker.Rondes.Add(new PuzzelRondeDetails
{
    Group1 = new PuzzelRondeGroup
    {
        Trefwoord1 = "...tuin",
        Trefwoord2 = "Latijns voor binnen",
        Trefwoord3 = "...venus",
        Trefwoord4 = "...communautair",
        Antwoord = "Intra"
    },
    Group2 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Of via Itsme",
        Trefwoord2 = "Overschrijven vanuit je zetel",
        Trefwoord3 = "Maar waar ligt mijn bakje?",
        Trefwoord4 = "Via GSM of PC",
        Antwoord = "Thuisbankieren"
    },
    Group3 = new PuzzelRondeGroup
    {
        Trefwoord1 = "Gekleurde ballen",
        Trefwoord2 = "Teambuilding",
        Trefwoord3 = "Pijnlijk",
        Trefwoord4 = "Op elkaar schieten",
        Antwoord = "Paintball"
    }
});

FilmFragmentTracker.Rondes = new List<FilmFragmentRondeDetails>();
FilmFragmentTracker.ActiveRonde = 1;
FilmFragmentTracker.Rondes.Add(new FilmFragmentRondeDetails
{
    Antwoord1 = "Westminster Abbey",
    Antwoord2 = "Charles III",
    Antwoord3 = "Camilla Parker Bowles",
    Antwoord4 = "William",
    Antwoord5 = "Kate Middleton"
});

FilmFragmentTracker.Rondes.Add(new FilmFragmentRondeDetails
{
    Antwoord1 = "Adam Yates",
    Antwoord2 = "Tadej Pogačar",
    Antwoord3 = "Jonas Vingegaard",
    Antwoord4 = "Giulio Ciccone",
    Antwoord5 = "Trine Marie Hansen"
});

FilmFragmentTracker.Rondes.Add(new FilmFragmentRondeDetails
{
    Antwoord1 = "Amerikaanse film",
    Antwoord2 = "Ryan Gosling",
    Antwoord3 = "Margot Robbie",
    Antwoord4 = "Greta Gerwig",
    Antwoord5 = "Dua Lipa"
});

FinaleRondeTracker.Rondes = new List<FinaleRondeDetails>();
FinaleRondeTracker.ActiveRonde = 1;
FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Guga Baúl",
    Antwoord2 = "Danira Boukhriss Terkessidis",
    Antwoord3 = "Geert Meyfroidt",
    Antwoord4 = "Catherine Van Eylen",
    Antwoord5 = "Lieven Scheire"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "VRT",
    Antwoord2 = "Weervrouw",
    Antwoord3 = "Opvolger Frank Deboosere",
    Antwoord4 = "Finalist Slimste Mens",
    Antwoord5 = "Arteveldehogeschool"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Wodka",
    Antwoord2 = "Tomatensap",
    Antwoord3 = "Worcestersaus",
    Antwoord4 = "Tabasco",
    Antwoord5 = "Peterseliezout"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Amerikaans",
    Antwoord2 = "Natuurkundige",
    Antwoord3 = "Vader van de atoombom",
    Antwoord4 = "Verfilmd",
    Antwoord5 = "Robert"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Noah",
    Antwoord2 = "Arthur",
    Antwoord3 = "Liam",
    Antwoord4 = "Louis",
    Antwoord5 = "Adam"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Belg",
    Antwoord2 = "Veldrijder",
    Antwoord3 = "Wielrenner",
    Antwoord4 = "Jumbo-Visma",
    Antwoord5 = "Herentals"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Cyprus",
    Antwoord2 = "Denemarken",
    Antwoord3 = "Estland",
    Antwoord4 = "Finland",
    Antwoord5 = "Frankrijk"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Lieven Scheire",
    Antwoord2 = "Jonas Geirnaert",
    Antwoord3 = "Koen De Poorter",
    Antwoord4 = "Jelle De Beule",
    Antwoord5 = "Debuut Man bijt hond"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Schalkse Ruiters",
    Antwoord2 = "Geslacht De Pauw",
    Antwoord3 = "Koeken Troef",
    Antwoord4 = "Grensoverschrijdend gedrag",
    Antwoord5 = "1ste seizoen Slimste Mens"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Sabine Hagedoren",
    Antwoord2 = "Jill Peeters",
    Antwoord3 = "Eddy De Mey",
    Antwoord4 = "Armand Pien",
    Antwoord5 = "David Dehenauw"
});

FinaleRondeTracker.Rondes.Add(new FinaleRondeDetails
{
    Antwoord1 = "Olivia",
    Antwoord2 = "Emma",
    Antwoord3 = "Louise",
    Antwoord4 = "Mila",
    Antwoord5 = "Lina"
});

app.Run();