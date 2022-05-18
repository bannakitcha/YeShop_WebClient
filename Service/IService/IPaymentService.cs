using Y_eShop_Models;
using Y_eShopWeb_Client.ViewModels;

namespace Y_eShopWeb_Client.Service.IService
{
    public interface IPaymentService
    {
        public Task<SuccessModelDTO> Checkout(StripePaymentDTO model);

    }
}
