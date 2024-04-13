using MarketManagement.Core;
using MarketManagement.Core.Entities.ViewModels;
using MarketManagement.Core.Interfaces;
using MarketManagement.Data.Repositories;
using System.ComponentModel.DataAnnotations;

namespace MarketManagement.Web.Validations
{
    //public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
    //{
    //    protected  override ValidationResult IsValid(object? value, ValidationContext validationContext)
    //    {
    //        var salesViewModel =  validationContext.ObjectInstance as SalesViewModel;

    //        if (salesViewModel != null)
    //        {
    //            if (salesViewModel.QuantityToSell <= 0)
    //            {
    //                return new ValidationResult("The quantity to sell has to be greater than zero.");
    //            }
    //            else
    //            {
    //                var productRepository = validationContext.ObjectInstance as ProductRepository;
    //              if (productRepository != null) {
    //                    var product = productRepository.GetProductById(salesViewModel.SelectedProductId);
    //                if (product != null)
    //                    {
    //                        if (product.Quantity <= salesViewModel.QuantityToSell)
    //                            return new ValidationResult($"{product.Name} only has {product.Quantity} left. It is not enough.");
    //                    }
    //                    else
    //                    {
    //                        return new ValidationResult("The selected product doesn't exist.");
    //                    }
    //                }                    
    //            }
    //       }

    //        return  ValidationResult.Success;
    //    }
    //}
}
