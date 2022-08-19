using Automarket.DAL.Interfaces;
using Automarket.Service.Interfaces;
using AutomarketDomaun.Entity;
using AutomarketDomaun.Enum;
using AutomarketDomaun.Response;
using AutomarketDomaun.ViewModel.Car;
using System.Data.Entity;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
        {
            var baseResponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<CarViewModel>()
                    {
                        Descriprion = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }

                var data = new CarViewModel()
                {
                    DataCreate = car.DataCreate,
                    Description = car.Description,
                    TypeCar = car.TypeCar.ToString(),
                    Speed = car.Speed,
                    Model = car.Model
                };

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Descriprion = $"[GetCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
        {
            var baseResponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = new Car()
                {
                    Description = carViewModel.Description,
                    DataCreate = DateTime.Now,
                    Speed = carViewModel.Speed,
                    Model = carViewModel.Model,
                    Price = carViewModel.Price,
                    Name = carViewModel.Name,
                    TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
                };

                await _carRepository.Create(car);
            }
            catch (Exception ex)
            {
                return new BaseResponse<CarViewModel>()
                {
                    Descriprion = $"[CreateCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteCar(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Descriprion = "User not found",
                        StatusCode = StatusCode.UserNotFound,
                        Data = false
                    };
                }

                await _carRepository.Delete(car);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Descriprion = $"[DeleteCar] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> GetCarByName(string name)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.GetByName(name);
                if (car == null)
                {
                    baseResponse.Descriprion = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }

                baseResponse.Data = car;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Descriprion = $"[GetCarByName] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Car>> Edit(int id, CarViewModel model)
        {
            var baseResponse = new BaseResponse<Car>();
            try
            {
                var car = await _carRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (car == null)
                {
                    return new BaseResponse<Car>()
                    {
                        Descriprion = "Car not found",
                        StatusCode = StatusCode.CarNotFound
                    };
                }

                car.Description = model.Description;
                car.Model = model.Model;
                car.Price = model.Price;
                car.Speed = model.Speed;
                car.DataCreate = model.DataCreate;
                car.Name = model.Name;

                await _carRepository.Update(car);


                return baseResponse;
                // TypeCar

            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Descriprion = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public IBaseResponse<List<Car>> GetCars()
        {
            try
            {
                var cars = _carRepository.GetAll().ToList();
                if (!cars.Any())
                {
                    return new BaseResponse<List<Car>>()
                    {
                        Descriprion = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Car>>()
                {
                    Data = cars,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Car>>()
                {
                    Descriprion = $"[GetCars] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}