using Newtonsoft.Json;
using Y_eShop_Models;
using Y_eShopWeb_Client.Service.IService;

namespace Y_eShopWeb_Client.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }
        public async Task<ProductDTO> Get(int productId)
        {
            var respond = await _httpClient.GetAsync($"/api/product/{productId}");
            var content = await respond.Content.ReadAsStringAsync();
            if (respond.IsSuccessStatusCode)
            {
                
                var product = JsonConvert.DeserializeObject<ProductDTO>(content);
                product.ImageUrl = BaseServerUrl + product.ImageUrl;
                return product;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
            //return new ProductDTO();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var respond = await _httpClient.GetAsync("/api/product");
            if(respond.IsSuccessStatusCode)
            {
                var content = await respond.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(content);
                foreach(var prod in products)
                {
                    prod.ImageUrl = BaseServerUrl + prod.ImageUrl;
                }
                return products;
            }
            return new List<ProductDTO>();
        }
    }
}
