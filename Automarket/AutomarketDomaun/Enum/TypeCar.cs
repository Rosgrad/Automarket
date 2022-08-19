using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomarketDomaun.Enum
{
    public enum TypeCar
    {
        [Display(Name = "Лекговой Автомобиль")]
        PassengerCar = 0,
        [Display(Name = "Седан")]
        Sedan = 0,
        [Display(Name = "Хэтчбек")]
        HatchBack = 0,
        [Display(Name = "Минивэн")]
        Minivan = 0,
        [Display(Name = "Спортивная машина")]
        SportCar = 0,
        [Display(Name = "Внедорожник")]
        Suv = 0,
    }
}
