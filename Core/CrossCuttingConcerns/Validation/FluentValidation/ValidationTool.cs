using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation //Cross Cutting Concerns : Bütün katmanları dikine kesen yani heryerde kullanılan işlemler.Örneğin : Log , Cache
{
    public static class ValidationTool //Bu tip araçlar genellikle static yapılır.Tek bir instance oluşturulur ve newlemekle uğraşılmaz her yerde.
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);  //Validation context<object> ı context içine attık
            var result = validator.Validate(context);         //Her Property kuralları için contextimizi validate et dedik.
            if (!result.IsValid)   //sonuç geçerli değilse 
            {
                throw new ValidationException(result.Errors);  //hata fırlat
            }
        }
    }
}
