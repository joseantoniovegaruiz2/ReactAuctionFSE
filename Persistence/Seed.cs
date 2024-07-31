using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(context.Products.Any()) return;
            var products=new List<Product>
            {
                new Product{
                    ProductName="Fundamentals of Wavelets",
                    ShortDescription="Fundamentals",
                    DetailedDescription="Hawking, Stephen	mathematics	Height 197	Penguin",
                    Category="Science",
                    StartingPrice="3.0",
                    BidEnDate= DateTime.Now.AddMonths(-2).ToUniversalTime(),
                },
                    new Product{
                    ProductName="Image Processing & Mathematical Morphology",
                    ShortDescription="Imaging",
                    DetailedDescription="Shih, Frank	signal_processing	241	CRC",
                    Category="Science",
                    StartingPrice="4.0",
                    BidEnDate= DateTime.Now.AddMonths(-4).ToUniversalTime(),
                },
                    new Product{
                    ProductName="Birth of a Theorem	Villani",
                    ShortDescription="Mathemathics",
                    DetailedDescription="Birth of a Theorem	Villani, Cedric	mathematics	234	Bodley Head",
                    Category="Science",
                    StartingPrice="6.0",
                    BidEnDate= DateTime.Now.AddMonths(-3).ToUniversalTime(),
                },
                  new Product{
                    ProductName="Machine Learning for Hackers",
                    ShortDescription="Mathemathics",
                    DetailedDescription="Drew	tech	data_science	233	O'Reilly",
                    Category="Science",
                    StartingPrice="7.0",
                    BidEnDate= DateTime.Now.AddMonths(-1).ToUniversalTime(),

                }




            };
                            await context.Products.AddRangeAsync(products);
            var sellers=new List<Seller>
            {
                new Seller{
                    FirstName="Geoffrey",
                    LastName="Lessel",
                    Address="120 jefferson st.",
                    City="Riverside",
                    State= "NJ",
                    Pin= "89876",
                    Phone= "8004445555",
                    Email= "geoffrey.Lessel@mockcompany.com",
                },
                new Seller{
                    FirstName="Jack",
                    LastName="McGinnis",
                    Address="220 hobo Av.",
                    City="Riverside",
                    State= "PA",
                    Pin= "9119",
                    Phone= "8003332222",
                    Email= "jack.McGinnis@mockcompany.com",
                },
                new Seller{
                    FirstName="Geoffrey",
                    LastName="Lessel",
                    Address="120 jefferson st.",
                    City="Riverside",
                    State= "NJ",
                    Pin= "89876",
                    Phone= "8004445555",
                    Email= "geoffrey.Lessel@mockcompany.com",
                },
                new Seller{
                    FirstName="Stephen",
                    LastName="Tyler",
                    Address="7452 Terrace At the Plaza road",
                    City="Phila",
                    State= " PA",
                    Pin= "91234",
                    Phone= "8004446666",
                    Email= "Stephen.Tyler@mockcompany.com",
                },
                new Seller{
                    FirstName="Joan",
                    LastName="Jet",
                    Address="9th, at Terrace plc",
                    City="Desert City",
                    State= "CO",
                    Pin= "99909",
                    Phone= "8004449999",
                    Email= "Joan.Jet@mockcompany.com",
                }




            };
            await context.Sellers.AddRangeAsync(sellers);
            var bids=new List<Bid>
            {
                new Bid{
                    BidAmount=300.00,
                    ProductId="Machine Learning for Hackers",
                    SellerId="geoffrey.Lessel@mockcompany.com",
                    BuyerId="don.smith@buyersmock.com",
                },
                new Bid{
                    BidAmount=200.00,
                    ProductId="Image Processing & Mathematical Morphology",
                    SellerId="Joan.Jet@mockcompany.com",
                    BuyerId="mark.joe@buyersmock.com",

                },
                new Bid{
                    BidAmount=100.00,
                    ProductId="Image Processing & Mathematical Morphology",
                    SellerId="jack.McGinnis@mockcompany.com",
                    BuyerId="carl.yamato@mockcompany.com",

                },
                new Bid{
                    BidAmount=500.00,
                    ProductId="Machine Learning for Hackers",
                    SellerId="Joan.Jet@mockcompany.com",
                    BuyerId="mark.yoshida@mockcompany.com",

                },
                new Bid{
                    BidAmount=600.00,
                    ProductId="Birth of a Theorem	Villani",
                    SellerId="Stephen.Tyler@mockcompany.com",
                     BuyerId="don.yoshiro@mockcompany.com",

                }
 

            };
            await context.Bids.AddRangeAsync(bids);
            await context.SaveChangesAsync();
        }    
    }
}