using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;

namespace Orneholm.Session.ApplicationInsights.Web.Controllers
{
    [RoutePrefix("api")]
    public class ProductsController : ApiController
    {
        private readonly List<Product> _products;

        public ProductsController()
        {
            _products = new List<Product>()
            {
                new Product() {id = 1, category = "Tech", name = "Computer"},
                new Product() {id = 2, category = "Tech", name = "Phone"},
                new Product() {id = 3, category = "Tech", name = "TV"},

                new Product() {id = 4, category = "Food", name = "Potatoes"},
                new Product() {id = 5, category = "Food", name = "Hamburger"},
                new Product() {id = 6, category = "Food", name = "Pizza"},

                new Product() {id = 7, category = "Sport", name = "Basketball"},
                new Product() {id = 8, category = "Sport", name = "Football"},
                new Product() {id = 9, category = "Sport", name = "Baseball"}
            };
        }

        [Route("products")]
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        [Route("products/{category}")]
        public IEnumerable<Product> GetProducts(string category)
        {
            if (category.Equals("food", StringComparison.InvariantCultureIgnoreCase))
            {
                Thread.Sleep(3000);
            }

            if (!_products.Any(x => x.category.Equals(category, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return _products.Where(x => x.category.Equals(category, StringComparison.InvariantCultureIgnoreCase));
        }

        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public string category { get; set; }
        }
    }
}
