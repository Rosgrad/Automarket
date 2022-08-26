using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomarketDomaun.ViewModel.User
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "Роль")]
        public string Role { get; set; }

        [Display(Name = "Логин")]
        public string Name { get; set; }

        [Display(Name = "Возраст")]
        public short Age { get; set; }

        [Display(Name = "Адресс")]
        public string Address { get; set; }
    }
}
