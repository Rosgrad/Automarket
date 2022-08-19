using AutomarketDomaun.Entity;
using AutomarketDomaun.Response;
using AutomarketDomaun.ViewModel.Car;

namespace Automarket.Service.Interfaces
{
    public interface ICarService
    {
        IBaseResponse<List<Car>> GetCars();

        Task<IBaseResponse<CarViewModel>> GetCar(int id);

        Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel);

        Task<IBaseResponse<bool>> DeleteCar(int id);

        Task<IBaseResponse<Car>> GetCarByName(string name);

        Task<IBaseResponse<Car>> Edit(int id, CarViewModel model);
    }
}