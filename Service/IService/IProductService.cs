using Y_eShop_Models;

namespace Y_eShopWeb_Client.Service.IService
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> Get(int productId);

    }
}
