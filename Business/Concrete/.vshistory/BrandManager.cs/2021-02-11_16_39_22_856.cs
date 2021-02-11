using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetByBrandId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
