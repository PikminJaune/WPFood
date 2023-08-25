using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFood.Modeles
{
    public class Commentaire
    {
        public int Id { get; set; }
        public string NomClient { get; set; }
        public string CommentaireClient { get; set; }
        public string NomServeur { get; set; }
        public bool EstRecommende { get; set; }

        //[Column(TypeName ="date")]
        public DateTime DateCommentaire { get; set; }

    }
}
