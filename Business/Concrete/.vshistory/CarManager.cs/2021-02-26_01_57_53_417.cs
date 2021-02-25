using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result();
        }
        public IResult Update(Car car)
        {
            //?
            _carDal.Update(car);
            return new Result();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorResult();
            }
            return new DataResult<List<Car>>(_carDal.GetAll(),true, "Araba Listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true,"Araba Detayı Getirildi");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == BrandId));
            //return _carDal.GetAll(p => p.BrandId == id);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId));
        }

       
    }
}
