using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class DataTracking
    {
        public DataTracking()
        {
            IsNeW = false;
            HasChanges= false;
        }
        //properties
        public bool IsNeW { get; set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate();
        public abstract bool Validate();

    }
}
