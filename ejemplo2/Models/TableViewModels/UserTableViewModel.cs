using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo2.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
    }
}