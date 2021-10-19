using System.Collections.Generic;
using System.Linq;

namespace OXU.Data.Model
{
    public class ExcelObject : Dictionary<string, string>
    {
        public bool IsEmpty => this.Values.All(v => string.IsNullOrEmpty(v));
    }
}
