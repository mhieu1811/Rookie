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
            CreateMap<AddressDto, Address>();
            CreateMap<CityDto, City>();
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<OrderDto, Order>();
            CreateMap<ProductDetailsDto, ProductDetails>();
            CreateMap<RatingDto, Rating>();
            CreateMap<RoleDto, Role>();
            CreateMap<UserDetailsDto, UserDetails>();
            CreateMap<UserDto, User>();
            CreateMap<ProductPictureDto, ProductPicture>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDetails, ProductDetailsDto>();
            CreateMap<ProductPicture, ProductPictureDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<City, CityDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Rating, RatingDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<UserDetails, UserDetailsDto>();
            CreateMap<User, UserDto>();
        }
    }
}
