using FluentValidation;
using Northwind.Business.ValidationRules.FluentValidation;
using Northwind.Entities.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, IEntity entity)
        {
            // ValidationContext nesnesi oluşturularak entity nesnesi sarmalanıyor.
            var context = new ValidationContext<object>(entity);

            // Validator'ün Validate metoduna artık doğru türde bir nesne geçiriliyor.
            var result = validator.Validate(context); // Bu satır kritik değişiklik

            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
