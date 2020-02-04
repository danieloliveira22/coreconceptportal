using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coreconceptportal.ViewModels
{
    public class UserProjectModel
    {
        public IEnumerable<coreconceptportal.Models.User> Users { get; set; }
        public IEnumerable<coreconceptportal.Models.Project> Projects { get; set; }
    }
}