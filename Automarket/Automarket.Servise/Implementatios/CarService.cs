using Automarket.DAL.Interfaces;
using Automarket.Service.Interfaces;
using AutomarketDomaun.Entity;
using AutomarketDomaun.Enum;
using AutomarketDomaun.Enum.Extensions;
using AutomarketDomaun.Response;
using AutomarketDomaun.ViewModel.Car;
using System.Data.Entity;

namespace Automarket.Service.Implementations
{
    public class CarService : ICarService
    {
        private readonly IBaseRepository<Car> _carRepository;

        public CarService(IBaseRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public BaseResponse<Dictionary<int, string>> GetTypes()
        {
            try
            {
                var types = ((TypeCar[])Enum.GetValues(typeof(TypeCar)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = types,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    Descriprion = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<IBaseResponse<CarViewModel>> GetCar(int id)
        {
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
                    DataCreate = car.DataCreate.ToLongDateString(),
                    Description = car.Description,
                    Name = car.Name,
                    Price = car.Price,
                    TypeCar = car.TypeCar.GetDisplayName(),
                    Speed = car.Speed,
                    Model = car.Model,
                    Image = car.Avatar,
                };

                return new BaseResponse<CarViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
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


        public async Task<IBaseResponse<Car>> CreateCar(CarViewModel model, byte[] imageData)
        {
            var baseResponse = new BaseResponse<CarViewModel>();
            try
            {
                var car = new Car()
                {
                    Name = model.Name,
                    Model = model.Model,
                    Description = model.Description,
                    DataCreate = DateTime.Now,
                    Speed = model.Speed,
                    TypeCar = (TypeCar)Convert.ToInt32(model.TypeCar),
                    Price = model.Price,
                    Avatar = imageData
                };

                await _carRepository.Create(car);
                return new BaseResponse<Car>()
                {
                    StatusCode = StatusCode.OK,
                    Data = car
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Car>()
                {
                    Descriprion = $"[Create] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
           
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

        //public async Task<IBaseResponse<Car>> GetCarByName(string name)
        //{
        //    var baseResponse = new BaseResponse<Car>();
        //    try
        //    {
        //        var car = await _carRepository.GetByName(name);
        //        if (car == null)
        //        {
        //            baseResponse.Descriprion = "User not found";
        //            baseResponse.StatusCode = StatusCode.UserNotFound;
        //            return baseResponse;
        //        }

        //        baseResponse.Data = car;
        //        return baseResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new BaseResponse<Car>()
        //        {
        //            Descriprion = $"[GetCarByName] : {ex.Message}",
        //            StatusCode = StatusCode.InternalServerError
        //        };
        //    }
        //}

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
                car.DataCreate = DateTime.ParseExact(model.DataCreate, "yyyyMMdd HH:mm", null);
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