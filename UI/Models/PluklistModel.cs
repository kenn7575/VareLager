using BL;

namespace UI.Models
{
    public class PluklistModel
    {
        private PluklistModel() {
            Lines = new List<Item>();
        }

       
        private static PluklistModel _instance;

       
        public static PluklistModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PluklistModel();
            }
            return _instance;
        }

       public static void Reset()
        {
            _instance = null;
        }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public string Forsendelse { get; set; }
        public List<Item> Lines { get; set; }

        public void AddItem(Item item)
        {
            Lines.Add(item);
        }
        public bool Validate() { 
            if (string.IsNullOrWhiteSpace(Name))return false;
            if (string.IsNullOrWhiteSpace(Adresse)) return false;
            if (string.IsNullOrWhiteSpace(Forsendelse)) return false;
            return true;
        }
    }
}
