﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plukliste
{
    public class Item
    {
        public string ProductID;
        public string Title;
        public ItemType Type;
        public int Amount;
        public string ToString()
        {
            return $"<tr><td>{Title}</td><td>{Amount}</td></tr>";
        }
    }
}
