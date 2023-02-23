﻿using BL;

namespace UI.Models
{
    public class ItemModel
    {
        public string ProductID { get; set; }
        public string Title { get; set; }
        public ItemType Type { get; set; }
        public int Amount { get; set; }
    }
}
