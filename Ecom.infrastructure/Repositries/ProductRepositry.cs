using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.interfaces;
using Ecom.Core.Services;
using Ecom.Core.Sharing;
using Ecom.infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Ecom.infrastructure.Repositries
{
    public class ProductRepositry : GenericRepositry<Product>, IProductRepositry
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;


        public ProductRepositry(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParams productParams)
        {
            var query = context.Products
               .Include(m => m.Category)
               .Include(m => m.Photos)
               .AsNoTracking();
            //Filtering By CatergoryId
            if (productParams.CategoryId.HasValue)
                query = query.Where(m => m.CategoryId == productParams.CategoryId);

            //filtering by word
            if (!string.IsNullOrEmpty(productParams.Search))
            {
                var searchWords = productParams.Search.Split(' ');
                query = query.Where(m => searchWords.Any(word =>

                m.Name.ToLower().Contains(word.ToLower()) ||
                m.Description.ToLower().Contains(word.ToLower())

                ));
            }

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "PriceAsn":
                        query = query.OrderBy(m => m.NewPrice);
                        break;
                    case "PriceDes":
                        query = query.OrderByDescending(m => m.NewPrice);
                        break;
                    default:
                        query = query.OrderBy(m => m.Name);
                        break;
                }
            }

            query = query.Skip((productParams.pageSize) * (productParams.PageNumber - 1)).Take(productParams.pageSize);
            var result = mapper.Map<List<ProductDTO>>(query);
            return result;

        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;

            var product = mapper.Map<Product>(productDTO);

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var ImagePath = await imageManagementService.AddImageAsync(productDTO.Photo, productDTO.Name);

            var photo = ImagePath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id,
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO is null)
                return false;

            var product = await context.Products
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(p => p.Id == updateProductDTO.Id);

            if (product is null)
                return false;

            mapper.Map(updateProductDTO, product);

            foreach (var photo in product.Photos)
            {
                 imageManagementService.DeleteImageAsync(photo.ImageName);
            }

            context.Photos.RemoveRange(product.Photos);

            var imagePaths = await imageManagementService
                .AddImageAsync(updateProductDTO.Photo, updateProductDTO.Name);

            var photos = imagePaths.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id
            }).ToList();

            await context.Photos.AddRangeAsync(photos);

            await context.SaveChangesAsync();

            return true;
        }
        public async Task DeleteAsync(Product product)
        {
            var photo = await context.Photos.Where(m => m.ProductId == product.Id)
            .ToListAsync();
            foreach (var item in photo)
            {
                imageManagementService.DeleteImageAsync(item.ImageName);
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
