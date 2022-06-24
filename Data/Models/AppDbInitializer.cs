using BookLibrary.AppContexts;

namespace BookLibrary.Models
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        bookTitle = "Things Fall Apart",
                        description = "One of the best african literature book",
                        isRead = true,
                        dateRead = DateTime.Now.AddDays(-10),
                        publishedYear = DateTime.Now.AddYears(DateTime.Now.Year),
                        rate = 5,
                        genre = "Literature",
                       
                        coverUrl = "https...",
                        CreationDateTime = DateTime.Now,
                        UpdateDateTime = DateTime.Now
                    }, 

                    new Book()
                    {
                        bookTitle = "Aminata",
                        description = "Aminata book description",
                        isRead = false,
                        dateRead = DateTime.Now.AddDays(-5),
                        publishedYear = DateTime.Now.AddYears(DateTime.Now.Year),
                        rate = 5,
                        genre = "Literature",
                       
                        coverUrl = "https...",
                        CreationDateTime = DateTime.Now,
                        UpdateDateTime = DateTime.Now
                    }
                    
                    );
                    context.SaveChanges();
                };
            }
        }
    }
}
