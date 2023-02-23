namespace BL
{
    public class Pluklist
    {
        public string? Name { get; set; }
        public string? Forsendelse { get; set; }
        public string? Adresse { get; set; }
        public bool IsValid => Validate();
        public List<Item> Lines = new List<Item>();
        public void AddItem(Item item) { Lines.Add(item); }
        public bool Validate()
        {
            bool valid = true;

            if (this.Lines == null || this.Lines.Count == 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}







