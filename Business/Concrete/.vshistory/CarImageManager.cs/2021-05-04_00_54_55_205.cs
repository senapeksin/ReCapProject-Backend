using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        public IResult Add(IFormFile file, CarImages carImage)
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

        public IResult Delete(CarImages carImage)
        {
            
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            
        }

        public IDataResult<CarImages> GetById(int id)
        {
            
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
           
        }
    }
}
