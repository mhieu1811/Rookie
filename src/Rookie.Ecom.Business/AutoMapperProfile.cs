using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor.Entities;

namespace Rookie.Ecom.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<CategoryDto, Category>();
            CreateMap<ProductDto, Product>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderDto, Order>();
            CreateMap<ProductDetailsDto, ProductDetails>();
            CreateMap<RatingDto, Rating>();
            CreateMap<UserDto, User>();
            CreateMap<AddressDto, Address>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductDetailsUpdateDto, ProductDetails>();

            CreateMap<ProductPictureDto, ProductPicture>();
            CreateMap<CartDto, Cart>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDetails, ProductDetailsDto>();
            CreateMap<ProductPicture, ProductPictureDto>();
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<Product, ProductCreateDto>();
            CreateMap<ProductDetails, ProductDetailsUpdateDto>();

            CreateMap<Cart, CartDto>();
        }
    }
}
