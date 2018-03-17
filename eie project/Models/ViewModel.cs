using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace eie_project.Models
{
    public class ViewModel
    {
        public ViewModel()
            {
                this.UserView = new UserAccount();
                this.AdminView = new AdminAccount();
                
            }
        public UserAccount UserView { get; set; }
        public AdminAccount AdminView { get; set; }
        
        public List<UserAccount> UserList { get; set; }
        public List<AdminAccount> AdminList { get; set; }
        
    }
}
