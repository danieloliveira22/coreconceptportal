using coreconceptportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coreconceptportal.ViewModels
{
    public class userAssociatedViewModel
    {
        public List<User> usersAssociated { get; set; }
        public  List<User> usersNonAssociated { get; set; }
        public IEnumerable<coreconceptportal.Models.Project> Projects { get; set; }

    }
}