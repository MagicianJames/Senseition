using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class User
    {
        public long id { get; set; }
        [StringLength (100)]
        public string first_name { get; set; }
        [StringLength (100)]
        public string last_name { get; set; }
        [StringLength (100), Required]
        public string username { get; set; }
        [StringLength (100), Required]
        public string password { get; set; }
        [StringLength (100)]
        public string email { get; set; }
        public string user_picture_url { get; set; }

    }

}
