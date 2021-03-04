using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
   public class ValidationTool
    {
        var context = new ValidationContext<Car>(car);
        CarValidator carValidator = new CarValidator();
        var result = carValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
    }
}
}
