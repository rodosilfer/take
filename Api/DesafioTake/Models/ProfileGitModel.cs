using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace DesafioTake.Models
{

    public class Owner
    {
        public string Avatar_url { get; set; }
    }
    public class ProfileGitModel
    {
        public string Language { get; set; }
        public DateTime Created_at { get; set; }
        public string Description { get; set; }
        public string Full_name { get; set; }
        public Owner Owner  { get; set; }


}
}
