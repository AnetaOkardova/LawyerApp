using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaywerApp.ViewModels
{
    public class OverviewModel
    {
        public List<ArticleCardModel> Articles { get; set; }
        public List<CollaboratorCardModel> Collaborators { get; set; }
        public List<LawServiceCardModel> LawServices { get; set; }
    }
}
