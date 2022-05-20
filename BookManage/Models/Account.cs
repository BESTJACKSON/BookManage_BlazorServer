using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookManage.Models
{
    public partial class Account
    {
        public int id { get; set; }
        public string user { get; set; }
        public string Password { get; set; }
    }
}