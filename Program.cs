using AssetSql;
using Type = AssetSql.Type;

using (var context = new MyDbContext()) {

    Assets Computers1 = new Assets();
    Computers1.ModelName = "MacBook ";
    DateTime dt1 = new DateTime(2015, 12, 31);
    Computers1.PurchaseDate = dt1;
    Computers1.Price = 2000;
    Computers1.Office = "Sweden";
    Computers1.Type = Type.Laptop;


    Assets Computers2 = new Assets();
    Computers2.ModelName = "Asus ";
    DateTime dt2 = new DateTime(2021, 09, 25);
    Computers1.PurchaseDate = dt2;
    Computers2.Price = 3000;
    Computers2.Office = "France";
    Computers2.Type = Type.Laptop;

    Assets Computers3 = new Assets();
    Computers3.ModelName = "Lenovo ";
    DateTime dt3 = new DateTime(2017, 10, 15);
    Computers1.PurchaseDate = dt3;
    Computers3.Price = 5000;
    Computers3.Office = "Sweden";
    Computers3.Type = Type.Laptop;

    Assets Phones1 = new Assets();
    Phones1.ModelName = "Iphone";
    DateTime dt4 = new DateTime(2016, 10, 15);
    Phones1.PurchaseDate = dt4;
    Phones1.Price = 10000;
    Phones1.Office = "France";
    Phones1.Type = Type.Phone;

    Assets Phones2 = new Assets();
    Phones2.ModelName = "Samsung";
    DateTime dt5 = new DateTime(2017, 10, 15);
    Phones2.PurchaseDate = dt5;
    Phones2.Price = 10000;
    Phones2.Office = "France";
    Phones2.Type = Type.Phone;

    Assets Phones3 = new Assets();
    Phones3.ModelName = "Nokia";
    DateTime dt6 = new DateTime(2022, 10, 11);
    Phones3.PurchaseDate = dt6;
    Phones3.Price = 8000;
    Phones3.Office = "Sweden";
    Phones3.Type = Type.Phone;

    context.Add(Computers1);
    context.Add(Computers2);
    context.Add(Computers3);
    context.Add(Phones1);
    context.Add(Phones2);
    context.Add(Phones3);
    var assets = (from computer in context.assets
                  orderby computer.PurchaseDate
                  select computer).ToList<Assets>();


    foreach (Assets asset in assets) {
        String status = "Warrenty";

        DateTime expiry = asset.PurchaseDate.AddYears(3);

        TimeSpan timeLeft = expiry - DateTime.Today;

        if ((timeLeft.Days <= 90) && (timeLeft.Days >= 0)) {
            Console.ForegroundColor = ConsoleColor.Red;
            status = "Soon Expiry";
        } else if ((timeLeft.Days <= 180) && (timeLeft.Days >= 0)) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            status = "Near Expiry";
        } else if (timeLeft.Days <= 0) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            status = "Expired";
        }

        Console.WriteLine(asset.Type.ToString().PadRight(15) + asset.Office.PadRight(15)
             + asset.PurchaseDate.ToString("dd/MM/yyyy").PadRight(15) + asset.ModelName.PadRight(15) + asset.Price.ToString().PadRight(15)
             + asset.Office.PadRight(15) + status.PadRight(15));
        Console.ForegroundColor = ConsoleColor.White;
    }

}