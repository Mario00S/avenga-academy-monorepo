// Data Sample
using Class01.Homework.Enums;
using Class01.Homework.Models;
using System.Reflection;
using static System.Net.WebRequestMethods;



#region Products Data
List<Product> products = new List<Product>()
{
    new Product(1, "iPhone 9", "An apple mobile which is nothing like apple", 549, 4.69, 94, "Apple", ProductCategory.Smartphones),
    new Product(2, "iPhone X", "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...", 899, 4.44, 34, "Apple", ProductCategory.Smartphones),
    new Product(3, "Samsung Universe 9", "Samsung's new variant which goes beyond Galaxy to the Universe", 1249, 4.09, 36, "Samsung", ProductCategory.Smartphones),
    new Product(4, "OPPOF19", "OPPO F19 is officially announced on April 2021.", 280, 4.3, 123, "OPPO", ProductCategory.Smartphones),
    new Product(5, "Huawei P30", "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.", 499, 4.09, 32, "Huawei", ProductCategory.Smartphones),
    new Product(6, "MacBook Pro", "MacBook Pro 2021 with mini-LED display may launch between September, November", 1749, 4.57, 83, "Apple", ProductCategory.Laptops),
    new Product(7, "Samsung Galaxy Book", "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched", 1499, 4.25, 50, "Samsung", ProductCategory.Laptops),
    new Product(8, "Microsoft Surface Laptop 4", "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen.", 1499, 4.43, 68, "Microsoft Surface", ProductCategory.Laptops),
    new Product(9, "Infinix INBOOK", "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty", 1099, 4.54, 96, "Infinix", ProductCategory.Laptops),
    new Product(10, "HP Pavilion 15-DK1056WM", "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10", 1099, 4.43, 89, "HP Pavilion", ProductCategory.Laptops),
    new Product(11, "perfume Oil", "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil", 13, 4.26, 65, "Impression of Acqua Di Gio", ProductCategory.Fragrances),
    new Product(12, "Brown Perfume", "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml", 40, 4, 52, "Royal_Mirage", ProductCategory.Fragrances),
    new Product(13, "Fog Scent Xpressio Perfume", "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men", 13, 4.59, 61, "Fog Scent Xpressio", ProductCategory.Fragrances),
    new Product(14, "Non-Alcoholic Concentrated Perfume Oil", "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil", 120, 4.21, 114, "Al Munakh", ProductCategory.Fragrances),
    new Product(15, "Eau De Perfume Spray", "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality", 30, 4.7, 105, "Lord - Al-Rehab", ProductCategory.Fragrances),
    new Product(16, "Hyaluronic Acid Serum", "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic Acid", 19, 4.83, 110, "L'Oreal Paris", ProductCategory.Skincare),
    new Product(17, "Tree Oil 30ml", "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,", 12, 4.52, 78, "Hemani Tea", ProductCategory.Skincare),
    new Product(18, "Oil Free Moisturizer 100ml", "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramides, hyaluronic acid & sunscreen.", 40, 4.56, 88, "Dermive", ProductCategory.Skincare),
    new Product(19, "Skin Beauty Serum.", "Product name: rorec collagen hyaluronic acid white face serum riceNet weight: 15 m", 46, 4.42, 54, "ROREC White Rice", ProductCategory.Skincare),
    new Product(20, "Freckle Treatment Cream- 15gm", "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no side effects.", 70, 4.06, 140, "Fair & Clear", ProductCategory.Skincare),
    new Product(21, "- Daal Masoor 500 grams", "Fine quality Branded Product Keep in a cool and dry place", 20, 4.44, 133, "Saaf & Khaas", ProductCategory.Groceries),
    new Product(22, "Elbow Macaroni - 400 gm", "Product details of Bake Parlor Big Elbow Macaroni - 400 gm", 14, 4.57, 146, "Bake Parlor Big", ProductCategory.Groceries),
    new Product(23, "Orange Essence Food Flavou", "Specifications of Orange Essence Food Flavour For Cakes and Baking Food Item", 14, 4.85, 26, "Baking Food Items", ProductCategory.Groceries)
};
#endregion

#region Workspace
//1.Get the title of the first product in the Fragrances category with a price above $100.
string? firstFragranceAbove100 =
    products
    .Where(p => p.Category == ProductCategory.Fragrances && p.Price > 100)
    .Select(p => p.Title)
    .FirstOrDefault();
//must add ? to make the variable nullable
Console.WriteLine("1.Get the title of the first product in the Fragrances category with a price above $100");
Console.WriteLine(firstFragranceAbove100);
Console.ReadLine();

//2.Select the brand of the last product that has a stock lower than 40.
string brandOfLastProductStockLowerThan40 =
    products
    .Where(a => a.Stock < 40)
    .Select(a => a.Brand)
    .LastOrDefault()
    ?? "No such item: stock lower than 40";
//Need to add the case that handles null 
Console.WriteLine("2.Select the brand of the last product that has a stock lower than 40");
Console.WriteLine(brandOfLastProductStockLowerThan40);
Console.ReadLine();

//3.Retrieve the description of the first product with a rating equal to 4.43.
//var firstProductRatingDescription =
//    products
//    .Where(p => p.Rating == 4.43)
//    .Select(p => new { p.Title, p.Description })
//    .FirstOrDefault();
//must use var because i return two properties using anonymous object 
//Console.WriteLine("3.Retrieve the description of the first product with a rating equal to 4.43");
//Console.WriteLine($"The product named: {firstProductRatingDescription.Title} has the following description: \n{firstProductRatingDescription.Description}");
//Console.ReadLine();

//3.1 simpler approach
string firstProductRatingDescriptionString =
    products
        .Where(p => p.Rating == 4.43)
        .Select(p => $"{p.Title} - {p.Description}")
        .FirstOrDefault()
    ?? "No product with rating 4.43 was found.";
Console.WriteLine("3.Retrieve the description of the first product with a rating equal to 4.43");
Console.WriteLine(firstProductRatingDescriptionString);
Console.ReadLine();

//4.Get the title of the last Skincare product with a price under $50.
string lastSkincareProducteUnder50 =
    products
        .Where(p => p.Category == ProductCategory.Skincare && p.Price < 50)
        .Select(p => p.Title)
        .LastOrDefault()
        ?? "No product with a price under 50$ in the skincare category";
Console.WriteLine("4.Get the title of the last Skincare product with a price under $50.");
Console.WriteLine(lastSkincareProducteUnder50);
Console.ReadLine();

//5.Select the rating of the first product with a brand that contains the word "Apple".
//using var to combine different data types
var ratingOfFirstProductApple =
    products
        .Where(p => p.Brand.Contains("Apple"))
        .Select(p => new { p.Title, p.Rating })
        .First();
//better practice to use .FirstOrDefault be if we use .First we are trying to intentionally fail the app
//by not handling the is null scenario
Console.WriteLine("5.Select the rating of the first product with a brand that contains the word \"Apple\".");
Console.WriteLine($"Title of the product: {ratingOfFirstProductApple.Title} has rating: {ratingOfFirstProductApple.Rating}");
Console.ReadLine();

//6.Get the description of the last product with "display" in the description.
Product? lastWithDisplay =
    products
        .LastOrDefault(p => p.Description.Contains("display"));
if (lastWithDisplay != null)
{
    Console.WriteLine("6.Get the description of the last product with \"display\" in the description.");
    Console.WriteLine($"{lastWithDisplay.Title} has description:\n{lastWithDisplay.Description}");
    Console.ReadLine();
}
else
{
    Console.WriteLine("No product found with 'display' in description.");
}

//7.Select the title of the first Laptop that has a stock greater than 80.
string titleOfFirstLaptopWithStockGreaterThan80 =
    products
        .Where(p => p.Stock > 80 && p.Category == ProductCategory.Laptops)
        .Select(p => p.Title)
        .FirstOrDefault()
        ?? "No such product";
Console.WriteLine("7.Select the title of the first Laptop that has a stock greater than 80");
Console.WriteLine(titleOfFirstLaptopWithStockGreaterThan80);
Console.ReadLine();

//8.Get the brand of the last product with "Pro" in the title.
string brandOfLastProductContainsPro =
    products
        .Where(p => p.Title.Contains("Pro"))
        .Select(p => p.Brand)
        .LastOrDefault()
        ?? "No such product";
Console.WriteLine("8.Get the brand of the last product with \"Pro\" in the title.");
Console.WriteLine(brandOfLastProductContainsPro);
Console.ReadLine();

//9.Retrieve the title of the first product that has a price above $1200.
string titleOfFirstProductPriceGreaterThan1200 =
    products
        .Where(p => p.Price > 1200)
        .Select(p => p.Title)
        .FirstOrDefault()
        ?? "No such product with price greater than 1200$";
Console.WriteLine("9.Retrieve the title of the first product that has a price above $1200.");
Console.WriteLine(titleOfFirstProductPriceGreaterThan1200);
Console.ReadLine();

//10.Select the stock count of the last product that belongs to the Smartphones category.
int stockCountOfLastSmartphone =
    products
        .Where(p => p.Category == ProductCategory.Smartphones)
        .Select(p => p.Stock)
        .LastOrDefault();
Console.WriteLine("10.Select the stock count of the last product that belongs to the Smartphones category.");
Console.WriteLine(stockCountOfLastSmartphone);
Console.ReadLine();

//11.Get the description of the first product with a brand name starting with 'H'.
string descriptionOfFirstProductStartsWithLetterH =
    products
        .Where(p => p.Brand.StartsWith("H"))
        .Select(p => p.Description)
        .FirstOrDefault()
        ?? "no such product";
Console.WriteLine("11.Get the description of the first product with a brand name starting with 'H'.");
Console.WriteLine(descriptionOfFirstProductStartsWithLetterH);
Console.ReadLine();

//12.Retrieve the price of the last product that has "Essence" in its title.
double priceOfLastProductEssence =
    products
        .Where(p => p.Title.Contains("Essence"))
        .Select(p => p.Price)
        .LastOrDefault();
Console.WriteLine("12.Retrieve the price of the last product that has \"Essence\" in its title.");
Console.WriteLine(priceOfLastProductEssence);
Console.ReadLine();

//13.Select the brand of the first product with a description longer than 100 characters.
string brandOfFirstLongDescription =
    products
        .Where(p => p.Description.Length > 100)
        .Select(p => p.Brand)
        .FirstOrDefault()
        ?? "No such product";
Console.WriteLine("13.Select the brand of the first product with a description longer than 100 characters.");
Console.WriteLine(brandOfFirstLongDescription);
Console.ReadLine();

//14.Get the title of the last product with a rating below 4.1 and stock over 30.
string titleLastProductRbellow4RatingOver30 =
    products
        .Where(p => p.Rating < 4.1 && p.Stock > 30)
        .Select(p => p.Title)
        .LastOrDefault()
        ?? "No product with such details";
Console.WriteLine("14.Get the title of the last product with a rating below 4.1 and stock over 30.");
Console.WriteLine(titleLastProductRbellow4RatingOver30);
Console.ReadLine();

//15.Retrieve the description of the first product that has "Serum" in the title.
string descriptionFproductContainsSerum =
    products
        .Where(p => p.Title.Contains("Serum"))
        .Select(p => p.Description)
        .FirstOrDefault()
        ?? "No such product with the words Serum in the title";
Console.WriteLine("15.Retrieve the description of the first product that has \"Serum\" in the title.");
Console.WriteLine(descriptionFproductContainsSerum);
Console.ReadLine();

//16.Use a dictionary to map products by their category.
//using a general maping with the toDictionary method to have all of the categories that can be reused later on
Dictionary<ProductCategory, List<Product>> productsByCategory =
    products
        .GroupBy(p => p.Category)
        .ToDictionary(
            group => group.Key,
            group => group.ToList());
//now we can use a forEachLoop to manipulate with the whole categorey of the products
Console.WriteLine("16.Use a dictionary to map products by their category.");
Console.WriteLine("retriving all smartphones:");
List<Product> smartphones = productsByCategory[ProductCategory.Smartphones];
int counter = 1;
foreach (var phone in smartphones)
{
    Console.WriteLine($"{counter}. {phone.Title}");
    counter++;
}
Console.ReadLine();

//16.1 additional category with multiple properties
Console.WriteLine("Additional list of skincare products:");
List<Product> skincare = productsByCategory[ProductCategory.Skincare];
foreach (var product in skincare)
{
    Console.WriteLine($"{counter}. {product.Title} | {product.Brand} | {product.Price}$");
    counter++;
}

//Bonus
//17.Create new class ProductDetails with 3 properties: Id, Title and Price and map the existing product data to a collection of ProductDetails objects.
List<ProductDetails> productDetailsList =
    products
        .Select(p => new ProductDetails(p.Id, p.Title, p.Price))
        .ToList();

Console.WriteLine("Bonus\r\n17.Create new class ProductDetails with 3 properties: Id, Title and Price and map the existing product data to a collection of ProductDetails objects.");
Console.WriteLine("Printing all of the items");
foreach (var pd in productDetailsList)
{
    Console.WriteLine($"{pd.Id} - {pd.Title} - {pd.Price}");
}
Console.ReadLine();
//17.1
Console.WriteLine("Combining the ProductDetails and ProductCategories, print details for laptops category");
List<ProductDetails> laptopDetails =
    products
        .Where(p => p.Category == ProductCategory.Laptops)
        .Select(p => new ProductDetails(p.Id, p.Title, p.Price))
        .ToList();

foreach (var pd in laptopDetails)
{
    Console.WriteLine($"{pd.Id} - {pd.Title} - {pd.Price}");
}
Console.ReadLine();
Console.WriteLine("The end, Thank you for your effort");
#endregion


