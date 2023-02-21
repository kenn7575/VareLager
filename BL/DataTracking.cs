using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class DataTracking
    {

        //properties
        public bool IsNeW { get; private set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate();
        public abstract bool Validate();

    }
}
