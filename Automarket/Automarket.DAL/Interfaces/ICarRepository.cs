using AutomarketDomaun.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automarket.DAL.Interfaces
{
    public interface ICarRepository : IBaseRepository<Car>
    {
        Task<Car> GetByName(string name);
    }
}
