using FluentValidation;
using ShopOnline.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Validate
{
    public class CreatProductValidator: AbstractValidator<CreatProduct>
    {
        public CreatProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Pleased input Name product");
        }
    }
}
