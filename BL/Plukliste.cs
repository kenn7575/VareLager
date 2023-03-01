namespace BL
{
    public class Pluklist : DataTracking
    {
        //constructor
        public Pluklist() 
        {   
            Lines = new List<Item>();
        }

        //properties
        public string? Name { get; set; }
        public string? Forsendelse { get; set; }
        public string? Adresse { get; set; }
        public List<Item>? Lines { get; set; }
        public bool IsValid => Validate();
        
        //methods
        public override bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            if (string.IsNullOrWhiteSpace(Forsendelse)) return false;
            if (string.IsNullOrWhiteSpace(Adresse)) return false;
            if (Lines == null) return false;
            return true;
        }
    }
}







