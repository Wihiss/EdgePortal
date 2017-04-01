using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgePortal.Model
{
    public abstract class BaseDocumentModel
    {
        public string Id { get; set; }
        public string Author { get; set; }
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
    }
}
