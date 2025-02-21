using ECommerceFactory.Factories;
using ECommerceFactory.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceFactory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFactory _productFactory;

        public ProductController(IProductRepository productRepository, IProductFactory productFactory)
        {
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string description, decimal price)
        {
            var product = _productFactory.CreateProduct(name, description, price);
            _productRepository.Add(product);
            _productRepository.Save();
            return RedirectToAction("Index");
        }
    }

}
