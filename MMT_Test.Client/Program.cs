using System;
using System.Linq;

namespace MMT_Test.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var MMT_API = new MMT_Test_API("https://localhost:44329");

            var exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Enter 1 for categories, 2 for Featured Products,E to exit");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.NumPad1 || key == ConsoleKey.D1)
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
                    var exitCategories = false;
                    while (!exitCategories)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter 1 to view the products for a category, E to exit.");
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
                                else if (int.TryParse(categoryCode,out int categoryCodeId))
                                {

                                    var products = MMT_API.GetCategoryProducts(categoryCodeId);
                                    if (products.Any())
                                    {
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
