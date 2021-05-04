using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDAL _iCarImageDal;
        public CarImageManager(ICarImageDAL iCarImageDAL)
        {
            _iCarImageDal = iCarImageDAL;
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImages image)
        {

            IResult result = BusinessRules.Run(CheckIfCarImageCountCorrect(image.CarId));



            if (result != null)
            {
                return new ErrorResult("One car must have 5 or less images");
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            image.ImagePath = imageResult.Message;
            _iCarImageDal.Add(image);
            return new SuccessResult("Car image added");
        }

        private IResult CheckIfCarImageCountCorrect(int carId)
        {
            var result = _iCarImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult("Messages.ImageLimitExceeded");
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImages carImage)
        {
           
          
                var result = _iCarImageDal.Get(c => c.ImageId == carImage.ImageId);
                if (result == null)
                {
                    return new ErrorResult("Messages.ImageNotFound");
                }

                FileHelper.Delete(result.ImagePath);
                _iCarImageDal.Delete(result);
                return new SuccessResult("Messages.ImageDeleted");
            }
        

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_iCarImageDal.GetAll(), "Messages.ImagesListed");
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_iCarImageDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result == null)
            {
                return new ErrorDataResult<List<CarImages>>(result.Message);
            }
            return new SuccessDataResult<List<CarImages>>(CheckIfCarImageNull(carId).Data, "Messages.ImagesListed");
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
           
        }




        private IDataResult<List<CarImages>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _iCarImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    List<CarImages> image = new List<CarImages>();
                    image.Add(new CarImages { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImages>>(image);
                }
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CarImages>>(exception.Message);
            }
            return new SuccessDataResult<List<NCarImage>>(_iCarImageDal.GetAll(p => p.CarId == carId).ToList());
        }
    }
}
