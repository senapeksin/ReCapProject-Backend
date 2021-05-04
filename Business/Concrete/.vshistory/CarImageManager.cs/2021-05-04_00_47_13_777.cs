using Business.Abstract;
using Core.Utilities.Results;
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
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImages> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImages>> GetImagesByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImages carImage)
        {
            throw new NotImplementedException();
        }
    }
}
