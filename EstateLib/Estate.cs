namespace EstateLib
{
    public class Estate
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public double Size { get; set; }

        public double Price { get; set; }

        public Estate(string type, double size, double price)
        {
            Type = type;
            Size = size;
            Price = price;
        }

        public Estate() { }

        public override string ToString()
        {
            return $"Id: {Id}, Type: {Type}, Size: {Size}, Price: ${Price}";
        }
    }
}
