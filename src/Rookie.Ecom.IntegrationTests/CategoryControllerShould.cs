using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Admin.Controllers;
using Rookie.Ecom.Business;
using Rookie.Ecom.Business.Services;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.DataAccessor;
using Rookie.Ecom.DataAccessor.Entities;
using Rookie.Ecom.DataAccessor.Interfaces;
using Rookie.Ecom.IntegrationTests.Common;
using Rookie.Ecom.Tests;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.Ecom.IntegrationTests
{
    public class CategoryControllerShould : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;
        private readonly IBaseRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryControllerShould(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
            _categoryRepository = new BaseRepository<Category>(_fixture.Context);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task Add_New_Category_Success()
        {
            // Arrange
            var categoryService = new CategoryService(_categoryRepository, _mapper);
/*            var categoryController = new CategoryController(categoryService);
*/
            var newCategory = new CategoryDto { CategoryName = "Test Category" };

            // Act
            var result = await categoryController.CreateAsync(newCategory);

            // Assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status201Created);
            result.Should().NotBeNull();

            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<CategoryDto>(createdResult.Value);

            Assert.Equal(newCategory.CategoryName, returnValue.CategoryName);

          
            returnValue.Id.Should().NotBe(Guid.Empty);
        }

        [Fact]
        public async Task Add_Exist_Category_ExistedName()
        {
            // Arrange
            var existCategory = new Category { Id = Guid.NewGuid(), CategoryName = "Laptop" };
            await _categoryRepository.AddAsync(existCategory);

            var categoryService = new CategoryService(_categoryRepository, _mapper);
            var categoryController = new CategoryController(categoryService);

            var newCategory = new CategoryDto { CategoryName = "Laptop 2"};

            // Act
            var result = await categoryController.CreateAsync(newCategory);

            // Assert
            result.Result.Should().HaveStatusCode(StatusCodes.Status201Created);
            result.Should().NotBeNull();

            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<CategoryDto>(createdResult.Value);

            Assert.Equal(newCategory.CategoryName, returnValue.CategoryName);

            returnValue.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_All_Categories()
        {
            //Arrange
            var category1 = new Category { CategoryName = "Cate 1"};
            var category2 = new Category { CategoryName = "Cate 2"};
            var category3 = new Category { CategoryName = "Cate 3" };
            var category4 = new Category { CategoryName = "Cate 4" };
            await _categoryRepository.AddAsync(category1);
            await _categoryRepository.AddAsync(category2);
            await _categoryRepository.AddAsync(category3);
            await _categoryRepository.AddAsync(category4);

            var categoryService = new CategoryService(_categoryRepository, _mapper);
/*            var categoryController = new CategoryController(categoryService);
*/
            // Act
            var result = await categoryController.GetAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(4);
        }
    }
}