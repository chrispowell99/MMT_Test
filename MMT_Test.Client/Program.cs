using System;
using System.Linq;

namespace MMT_Test.Client
{
    class Program
    {
        const string DEFAULTURL = "https://localhost:44329";

        static void Main(string[] args)
        {
            var url = DEFAULTURL;

            Console.WriteLine("The deafult API address is 'https://localhost:44329'.");
            Console.Write("Enter Y to confirm this is correct or N to enter a different address ");
            var key3 = Console.ReadKey().Key;
            if (key3 == ConsoleKey.N)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the API address and press enter");
                url = Console.ReadLine();
            }

            var MMT_API = new MMT_Test_API(url);

            var exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.Write("Enter 1 for categories, 2 for Featured Products,E to exit");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Wait...");
                    try
                    {
                        var categories = MMT_API.GetCategories();
                        if (categories.Any())
                        {
                            Console.WriteLine();
                            Console.WriteLine("All Categories:");
                            Console.WriteLine("-----------");
                            foreach (var category in categories)
                            {
                                Console.WriteLine("Id: " + category.Id.ToString() + ", Name: " + category.Name);
                            }
                            Console.WriteLine("-----------");
                        }
                        else
                        {
                            Console.WriteLine("No categories found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    var exitCategories = false;
                    while (!exitCategories)
                    {
                        Console.WriteLine();
                        Console.Write("Enter 1 to view the products for a category, E to exit.");
                        var key2 = Console.ReadKey().Key;
                        if (key2 == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
                        {
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter the category Id to view the products for the category, or E to exit, then press enter.");
                                var categoryCode = Console.ReadLine().Trim().ToLower();
                                if (categoryCode == "e")
                                {
                                    exitCategories = true;
                                }
                                else if (int.TryParse(categoryCode, out int categoryCodeId))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Please Wait...");
                                    try
                                    {
                                        var products = MMT_API.GetCategoryProducts(categoryCodeId);
                                        if (products.Any())
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("All products for cartgory Id" + categoryCode + ":");
                                            Console.WriteLine("-----------");
                                            foreach (var product in products)
                                            {
                                                Console.WriteLine("Id: " + product.Id.ToString() + ", Name: " + product.Name);
                                            }
                                            Console.WriteLine("-----------");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No products found for cartgory Id" + categoryCode);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            }
                        }
                        else if (key2 == ConsoleKey.E)
                        {
                            exitCategories = true;
                        }
                    }
                }
                else if (key == ConsoleKey.NumPad2 || key == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please Wait...");
                    try
                    {
                        var products = MMT_API.GetFeaturedProducts();
                        Console.WriteLine();
                        if (products.Any())
                        {
                            Console.WriteLine();
                            Console.WriteLine("Featured products:");
                            Console.WriteLine("-----------");
                            foreach (var product in products)
                            {
                                Console.WriteLine("Id: " + product.Id.ToString() + ", Name: " + product.Name);
                            }
                            Console.WriteLine("-----------");
                        }
                        else
                        {
                            Console.WriteLine("No featured products Found");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (key == ConsoleKey.E)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please try again.");
                }
            }
        }
    }
}
