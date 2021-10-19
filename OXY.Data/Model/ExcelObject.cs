using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OXU.Data.Model
{
    public class ExcelObject : Dictionary<string, string>
    {
        public bool IsEmpty => this.Values.All(v => string.IsNullOrEmpty(v));
    }
}
