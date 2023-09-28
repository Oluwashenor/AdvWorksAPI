using AdvWorksAPI.EntityLayer;

namespace AdvWorksAPI.RepositoryLayer
{
    public class ProductRepository
    {
        public List<Product> Get()
        {
            return new List<Product>
            {
            new Product
                {
                    Id = 1,
                    Name = "Product A",
                    Description = "Description for Product A",
                    Category = "Category 1"
                } ,
            new Product
                {
                    Id = 2,
                    Name = "Product B",
                    Description = "Description for Product B",
                    Category = "Category 2"
                },
            new Product
                {
                    Id = 3,
                    Name = "Product C",
                    Description = "Description for Product C",
                    Category = "Category 1"
                },
            new Product
                {
                    Id = 4,
                    Name = "Product D",
                    Description = "Description for Product D",
                    Category = "Category 3"
                }
            };
        }

        public Product? Get(int id)
        {
            return Get().FirstOrDefault(x=>x.Id == id); 
        }
    }
    }
