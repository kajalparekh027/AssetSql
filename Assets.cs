namespace AssetSql {

    enum Type {
        Laptop, //0
        Phone   //1
    }

    internal class Assets {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public string Office { get; set; }
        public Type Type { get; set; }

    }
}
