using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgePortal.Model
{
    public class BaseCommentedDocumentModel : BaseDocumentModel
    {
        public CommentModel[] Comments { get; set; }
    }
}
