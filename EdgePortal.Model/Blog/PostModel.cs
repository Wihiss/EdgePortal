using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgePortal.Model.Blog
{
    public class PostModel : BaseCommentedDocumentModel
    {
        public string Text { get; set; }
    }
}
