using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(p=>p.ProductName).NotEmpty();
            RuleFor(p=>p.ProductName).MinimumLength(2).WithMessage("product name must be at least two characters");
            RuleFor(p=>p.UnitPrice).GreaterThan(0);
            RuleFor(P=>P.UnitPrice).GreaterThanOrEqualTo(10).When(p=>p.ProductId == 1);//productid should be category in here 
                                                                                       //but there is no configuwration in entities concrete product so fix this
        }
    }
}
