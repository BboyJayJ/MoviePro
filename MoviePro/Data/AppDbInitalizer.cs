using MoviePro.Controllers;
using MoviePro.Data;
using MoviePro.Models;


namespace MoviePro.Data
{
    public class AppDbInitalizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context?.Database.EnsureCreated();

                //Cinema
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema
                        {
                            Name = "Cinema1",
                            Logo = "https://i.pinimg.com/564x/58/5d/c4/585dc4b8f99fde633987d9e8a3d88d19.jpg",
							Description = "測試片商"

						},


						new Cinema()
						{
							Name = "Cinema 1",
							Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
							Description = "This is the description of the first cinema"
						},
						new Cinema()
						{
							Name = "Cinema 2",
							Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
							Description = "This is the description of the first cinema"
						},
						new Cinema()
						{
							Name = "Cinema 3",
							Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
							Description = "This is the description of the first cinema"
						},
						new Cinema()
						{
							Name = "Cinema 4",
							Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
							Description = "This is the description of the first cinema"
						},
						new Cinema()
						{
							Name = "Cinema 5",
							Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
							Description = "This is the description of the first cinema"
						},
					});

                    context.SaveChanges();
                    
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                             FullName = "史蒂芬",
                            PictureUrl = "https://api.agentm.tw/images/artist/91251fb1-d1c9-4ba9-8b26-6a10eed29679.jpg",
                            Bio = "這是第一個演員"
                        },

						new Actor()
						{
							FullName = "Actor 1",
							Bio = "This is the Bio of the first actor",
							PictureUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

						},
						new Actor()
						{
							FullName = "Actor 2",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
						},
						new Actor()
						{
							FullName = "Actor 3",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
						},
						new Actor()
						{
							FullName = "Actor 4",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
						},
						new Actor()
						{
							FullName = "Actor 5",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
						}
					});
                    
					context.SaveChanges();
				}

                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName ="好萊烏",
							PictureUrl="http://blog.logo123.com/wp-content/uploads/2014/10/%E5%8D%8E%E7%BA%B3%E5%85%84%E5%BC%9F%E5%BD%B1%E4%B8%9A%E5%85%AC%E5%8F%B8-Warner-Bros.jpg",
                            Bio = "這是第一個片商"

						},

						 new Producer()
						{
							FullName = "Producer 1",
							Bio = "This is the Bio of the first actor",
							PictureUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

						},
						new Producer()
						{
							FullName = "Producer 2",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
						},
						new Producer()
						{
							FullName = "Producer 3",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
						},
						new Producer()
						{
							FullName = "Producer 4",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
						},
						new Producer()
						{
							FullName = "Producer 5",
							Bio = "This is the Bio of the second actor",
							PictureUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
						}
					});
					context.SaveChanges();
				}
				//Movies
				if (!context.Movies.Any())
				{
					context.Movies.AddRange(new List<Movie>()
					{
						new Movie()
						{
							Name = "金鋼狼",
							Description = "金剛你娘郎復仇",
							Price = 35.20,
							ImageURL ="https://img2.jiemian.com/jiemian/original/20161117/14793789712243300_a700xH.jpg",
							StartDate = DateTime.Now,
							EndDate = DateTime.Now.AddDays(7),
							CinemaID = 1,
							ProducerID = 1,
							MovieCategroy = MovieCategroy.Action

						},
						new Movie()
						{
							Name = "Life",
							Description = "This is the Life movie description",
							Price = 39.50,
							ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
							StartDate = DateTime.Now.AddDays(-10),
							EndDate = DateTime.Now.AddDays(10),
							CinemaID = 3,
							ProducerID = 3,
							MovieCategroy =MovieCategroy.Documentary
						},
						new Movie()
						{
							Name = "The Shawshank Redemption",
							Description = "This is the Shawshank Redemption description",
							Price = 29.50,
							ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
							StartDate = DateTime.Now,
							EndDate = DateTime.Now.AddDays(3),
							CinemaID = 1,
							ProducerID = 1,
							MovieCategroy =MovieCategroy.Action
						},
						new Movie()
						{
							Name = "Ghost",
							Description = "This is the Ghost movie description",
							Price = 39.50,
							ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
							StartDate = DateTime.Now,
							EndDate = DateTime.Now.AddDays(7),
							CinemaID = 4,
							ProducerID = 4,
							MovieCategroy =MovieCategroy.Horror
						},
						new Movie()
						{
							Name = "Race",
							Description = "This is the Race movie description",
							Price = 39.50,
							ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
							StartDate = DateTime.Now.AddDays(-10),
							EndDate = DateTime.Now.AddDays(-5),
							CinemaID = 1,
							ProducerID = 2,
							MovieCategroy =MovieCategroy.Documentary
						},
						new Movie()
						{
							Name = "Scoob",
							Description = "This is the Scoob movie description",
							Price = 39.50,
							ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
							StartDate = DateTime.Now.AddDays(-10),
							EndDate = DateTime.Now.AddDays(-2),
							CinemaID = 1,
							ProducerID = 3,
							MovieCategroy =MovieCategroy.Cartoon
						},
						new Movie()
						{
							Name = "Cold Soles",
							Description = "This is the Cold Soles movie description",
							Price = 39.50,
							ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
							StartDate = DateTime.Now.AddDays(3),
							EndDate = DateTime.Now.AddDays(20),
							CinemaID = 1,
							ProducerID = 5,
							MovieCategroy =MovieCategroy.Drama
						}
					});
					context.SaveChanges();

				}
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                       
						 new Actor_Movie()
						{
							ActorId = 1,
							MovieId = 1
						},
						new Actor_Movie()
						{
							ActorId = 3,
							MovieId = 1
						},

						 new Actor_Movie()
						{
							ActorId = 1,
							MovieId = 2
						},
						 new Actor_Movie()
						{
							ActorId = 4,
							MovieId = 2
						},

						new Actor_Movie()
						{
							ActorId = 1,
							MovieId = 3
						},
						new Actor_Movie()
						{
							ActorId = 2,
							MovieId = 3
						},
						new Actor_Movie()
						{
							ActorId = 5,
							MovieId = 3
						},


						new Actor_Movie()
						{
							ActorId = 2,
							MovieId = 4
						},
						new Actor_Movie()
						{
							ActorId = 3,
							MovieId = 4
						},
						new Actor_Movie()
						{
							ActorId = 4,
							MovieId = 4
						},


						new Actor_Movie()
						{
							ActorId = 2,
							MovieId = 5
						},
						new Actor_Movie()
						{
							ActorId = 3,
							MovieId = 5
						},
						new Actor_Movie()
						{
							ActorId = 4,
							MovieId = 5
						},
						new Actor_Movie()
						{
							ActorId = 5,
							MovieId = 5
						},


						new Actor_Movie()
						{
							ActorId = 3,
							MovieId = 6
						},
						new Actor_Movie()
						{
							ActorId = 4,
							MovieId = 6
						},
						new Actor_Movie()
						{
							ActorId = 5,
							MovieId = 6
						}
					});

					context.SaveChanges();

				}
            }
        }
    }
}
