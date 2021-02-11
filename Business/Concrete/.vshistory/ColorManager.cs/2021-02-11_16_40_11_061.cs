using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAllByColorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
