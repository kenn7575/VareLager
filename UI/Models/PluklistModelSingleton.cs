using BL;

namespace UI.Models
{
    public class PluklistModelSingleton
    {
        public PluklistModelSingleton() {
            Items = new List<ItemModel>();
        }

       
        private static PluklistModelSingleton _instance;

       
        public static PluklistModelSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PluklistModelSingleton();
            }
            return _instance;
        }

       public static void Reset()
        {
            _instance = null;
        }
        public int? PluklistId { get; set; }
        public string? Name { get; set; }
        public string? Shipping { get; set; }
        public string? Address { get; set; }
        public string? PluklistStatus { get; set; }
        public string? DateCreated { get; set; }
        public string? DateFinished { get; set; }
        public List<ItemModel>? Items { get; set; }

        public void AddItem(ItemModel item)
        {
            Items.Add(item);
        }
        public bool Validate() { 
            if (string.IsNullOrWhiteSpace(Name))return false;
            if (string.IsNullOrWhiteSpace(Address)) return false;
            if (string.IsNullOrWhiteSpace(Shipping)) return false;
            return true;
        }
    }
}
