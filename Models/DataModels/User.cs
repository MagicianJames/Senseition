using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class Users
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
        [NotMapped]
        public string user_full_name
        {
            get
            {
                return $"{ first_name } { last_name }";
            }
        }

    }

}
