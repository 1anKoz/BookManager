using System.Text.RegularExpressions;
using System;
using BookManagerApp.Models;

namespace BookManagerApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Shelves.Any())
                {
                    context.Shelves.AddRange(
                    new List<Shelf>()
                    {
                        new Shelf()
                        {
                            Name = "DefaultShelf",
                            Books = new List<Book>()
                            {
                                new Book() {
                                    Title = "Metro 2033",
                                    CoverUrl = "https://m.media-amazon.com/images/I/A1Jp9VdxsQL._SY342_.jpg",
                                    Description = "Czy kiedykolwiek przyszło ci do głowy, że ostatni epizod historii cywilizacji człowieka rozegra się w przejmującej " +
                                    "atmosferze moskiewskiego metra? Czy człowiek, który w marzeniach sięgał gwiazd, godzien jest skończyć jak szczur, sto metrów pod ziemią? " +
                                    "Mało prawdopodobne? Po przeczytaniu „Metra 2033” – rosyjskiego, kultowego już bestsellera, który zawładnął wyobraźnią ponad dwuipółmilionowej rzeszy " +
                                    "czytelników – na pewno zmienisz zdanie.\r\nTen thriller SF, którego wartka akcja i niezwykle sugestywnie przedstawiony świat nie pozwolą ci się od niego" +
                                    " oderwać aż do ostatniej strony, to nie tylko wspaniała rozrywka i uczta dla czytelnika. To także portret człowieka u schyłku cywilizacji; przejmująca analiza jego " +
                                    "niezmiennej natury. To obraz świata po końcu świata.\r\nRok 2033. W wyniku konfliktu atomowego świat uległ zagładzie. Ocaleli tylko nieliczni, chroniący się w moskiewskim " +
                                    "metrze, które dzięki unikalnej konstrukcji stało się najprawdopodobniej ostatnim przyczółkiem ludzkości. Na mrocznych stacjach, rozświetlanych światłami " +
                                    "awaryjnymi i blaskiem ognisk, ludzie ci próbują wieść życie zbliżone do tego sprzed katastrofy. Tworzą mikropaństwa spajane ideologią, religią czy po prostu" +
                                    " ochroną filtrów wodnych... Zawierają sojusze, toczą wojny.\r\nWOGN to wysunięta najbardziej na północ zamieszkała stacja metra. Kiedyś była jedną" +
                                    " z najpiękniejszych, a po zagładzie przez długi czas pozostawała bezpieczna. Teraz pojawiło się na niej śmiertelne niebezpieczeństwo.\r\nArtem, młody " +
                                    "mężczyzna z WOGN-u, otrzymuje zadanie: musi przedostać się do legendarnej stacji Polis, serca moskiewskiego metra, aby przekazać ostrzeżenie o nowym niebezpieczeństwie." +
                                    " Od powodzenia jego misji zależy przyszłość nie tylko peryferyjnej stacji, ale być może całej ocalałej w metrze ludzkości.",
                                    Genre = Enum.BookGenre.Fantasy,
                                    Author = "Dmitry Glukhovsky",
                                    Isbn = "9788366071308",
                                    UserDescription = "Najlepsza książka, jaką do tej pory czytałem. Wartka akcja, ciekawe postacie i potwory. Przede wszystkim jednak zachwycił mnie świat..." +
                                    "Opisany został fenomenalnie. Podczas czytania czułem się jakbym się rzeczywiście tam przeniósł. Czułem emocje bohaterów, czułem chłód i widziałem ciemność tuneli;" +
                                    "każda chwila spędzona na stronach książki była jak podróż opuszczonym, moskiewskim metrem.",
                                    Score = 92,
                                    IsBeingRead = false,
                                    IsFavourite = true,
                                    StartedAt = new DateTime(2019, 6, 1, 7, 47, 0),
                                    FinishedAt = DateTime.Now,

                                    Quotes = new List<Quote>()
                                    {
                                        new Quote()
                                        {
                                            Content = "Humans had always been better at killing than any other living thing.",
                                            Page = 123,
                                            IsFavourite = false,
                                        }
                                    }
                                },

                                new Book() {
                                    Title = "Przepis na człowieka, czyli krótki wstęp do odpowiedzi na pytanie: dlaczego jesteśmy, jacy jesteśmy",
                                    CoverUrl = "https://s.lubimyczytac.pl/upload/books/4917000/4917880/822034-352x500.jpg",
                                    Description = "Założę się, że w każde święta ktoś w Twojej rodzinie mówi o tym, że coś jest dziedziczne, że jest genetyczne. Ludzie w Twoim otoczeniu mówią o rodzinnym " +
                                    "obciążeniu chorobami lub cechami charakteru. Tłumaczą swój aktualny stan tym, co mają w genach. I choć czasami jest to uzasadnione, to bądźmy szczerzy – nie każdy, kto " +
                                    "ma cukrzycę jest silnie genetycznie obciążony predyspozycjami do choroby i nie każdy z takim obciążeniem dostanie cukrzycy.\r\nKsiążka „Przepis na człowieka” Dawida Myśliwca " +
                                    "z kanału „Uwaga! Naukowy Bełkot” pomoże Ci zrozumieć, co tak naprawdę odkrywają naukowcy na całym świecie i jak te odkrycia przekładają się na Twoje życie. Po lekturze będziesz " +
                                    "świadomy, że nasze geny nie wydały na nas wyroku i że to, czym jest człowiek, to efekt oddziaływania genów ze środowiskiem.",
                                    Genre = Enum.BookGenre.Science,
                                    Author = "Dawid Myśliwiec",
                                    Isbn = "9788395235498",
                                    UserDescription = "Momentami była trochę nudna, a dygresje zbyt daleko odbiegały od tematu przewodniego, ale mimo wszystko bardzo dużo się dowiedziałem i polecam.",
                                    Score = 81,
                                    IsBeingRead = true,
                                    IsFavourite = false,
                                    StartedAt = new DateTime(2022, 8, 12, 4, 09, 12),
                                    FinishedAt = DateTime.Now
                                }
                            }
                        },

                        new Shelf()
                        {
                            Name = "MyFirstShelf",
                            Books = new List<Book>()
                            {
                                new Book() {
                                    Title = "1984",
                                    CoverUrl = "https://s.lubimyczytac.pl/upload/books/5108000/5108559/1137148-352x500.jpg",
                                    Description = "Nowe tłumaczenie jednej z najbardziej przełomowych książek XX wieku odchodzi od utartych rozwiązań terminologicznych i oferuje świeże spojrzenie na kultowy " +
                                    "tekst Orwella, podkreślające jego niesłabnącą aktualność również w dzisiejszych czasach\r\nNapisana ponad siedemdziesiąt lat temu powieść w chwili wydania była złowrogą" +
                                    " przepowiednią George’a Orwella dotyczącą zagrożenia, jakie niesie za sobą totalitaryzm. I chociaż rok 1984 już dawno minął, dystopijna wizja świata permanentnej wojny, w " +
                                    "którym życie jednostki jest w całości podporządkowane władzom, kłamstwa zastępują prawdę, a samodzielne myślenie może być zbrodnią, jest nadal aktualna.\r\nTrudno przecenić " +
                                    "znaczenie tej powieści dla współczesnej kultury. Orwell nie tylko mistrzowsko obnażył w niej mechanizmy działania totalitaryzmu i propagandy, lecz również trafnie pokazał, jak " +
                                    "wielką rolę w totalnej kontroli nad społeczeństwem mogą odegrać media i język fałszujący rzeczywistość.",
                                    Genre = Enum.BookGenre.Fiction,
                                    Author = "George Orwell",
                                    Isbn = "9788383351759",
                                    UserDescription = "Świetnie się zaczyna, bardzo dobry świat przedstawiony, ale jednocześnie fabularnie książka jest straszliwie nudna. Nieważne, co przydarzało się głównemu" +
                                    " bohaterowi - absolutnie mnie to nie obchodziło. Na początku myślałam, że to celowe, że ma pokazać, że bohater jest idealna owca w tłumie, nudna i płaską, z wypranym mózgiem," +
                                    " która nabierze życia w trakcie lektury, ale srogo się zawiodłam. Książka trąca mizoginią (typową dla męskich autorów tamtych czasów),niemniej, warto ją przeczytać dla tego " +
                                    "antyutopijnego porządku świata, bo w tym aspekcie mrozi i skłania do refleksji.",
                                    Score = 90,
                                    IsBeingRead = true,
                                    IsFavourite = true,
                                    StartedAt = new DateTime(2019, 6, 1, 7, 47, 0),
                                    FinishedAt = new DateTime(2022, 8, 12, 4, 09, 12),

                                    Quotes = new List<Quote>()
                                    {
                                        new Quote()
                                        {
                                            Content = "Perhaps one did not want to be loved so much as to be understood.",
                                            Page = 28,
                                            IsFavourite = false,
                                        },

                                        new Quote()
                                        {
                                            Content = "If you want to keep a secret, you must also hide it from yourself.",
                                            Page = 180,
                                            IsFavourite = true,
                                        }
                                    }
                                },

                                new Book() {
                                    Title = "1984",
                                    CoverUrl = "https://s.lubimyczytac.pl/upload/books/5108000/5108559/1137148-352x500.jpg",
                                    Description = "Nowe tłumaczenie jednej z najbardziej przełomowych książek XX wieku odchodzi od utartych rozwiązań terminologicznych i oferuje świeże spojrzenie na kultowy " +
                                    "tekst Orwella, podkreślające jego niesłabnącą aktualność również w dzisiejszych czasach\r\nNapisana ponad siedemdziesiąt lat temu powieść w chwili wydania była złowrogą" +
                                    " przepowiednią George’a Orwella dotyczącą zagrożenia, jakie niesie za sobą totalitaryzm. I chociaż rok 1984 już dawno minął, dystopijna wizja świata permanentnej wojny, w " +
                                    "którym życie jednostki jest w całości podporządkowane władzom, kłamstwa zastępują prawdę, a samodzielne myślenie może być zbrodnią, jest nadal aktualna.\r\nTrudno przecenić " +
                                    "znaczenie tej powieści dla współczesnej kultury. Orwell nie tylko mistrzowsko obnażył w niej mechanizmy działania totalitaryzmu i propagandy, lecz również trafnie pokazał, jak " +
                                    "wielką rolę w totalnej kontroli nad społeczeństwem mogą odegrać media i język fałszujący rzeczywistość.",
                                    Genre = Enum.BookGenre.Fiction,
                                    Author = "George Orwell",
                                    //Isbn = "9788383351759",
                                    //UserDescription = "Świetnie się zaczyna, bardzo dobry świat przedstawiony, ale jednocześnie fabularnie książka jest straszliwie nudna. Nieważne, co przydarzało się głównemu" +
                                    //" bohaterowi - absolutnie mnie to nie obchodziło. Na początku myślałam, że to celowe, że ma pokazać, że bohater jest idealna owca w tłumie, nudna i płaską, z wypranym mózgiem," +
                                    //" która nabierze życia w trakcie lektury, ale srogo się zawiodłam. Książka trąca mizoginią (typową dla męskich autorów tamtych czasów),niemniej, warto ją przeczytać dla tego " +
                                    //"antyutopijnego porządku świata, bo w tym aspekcie mrozi i skłania do refleksji.",
                                    //Score = 90,
                                    IsBeingRead = true,
                                    IsFavourite = true,
                                    StartedAt = new DateTime(2019, 6, 1, 7, 47, 0),
                                    FinishedAt = new DateTime(2022, 8, 12, 4, 09, 12)
                                }
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
