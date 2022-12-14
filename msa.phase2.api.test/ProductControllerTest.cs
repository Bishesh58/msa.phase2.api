using System;
using Xunit;
using AutoFixture;
using FluentAssertions;
using Moq;
using msa.phase2.api.Models;
using msa.phase2.api.Services;
using msa.phase2.api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace msa.phase2.api.test
{
    public class ProductControllerTest
    {

        private readonly IFixture _fixture;
        private readonly Mock<IProductService> _productServiceMock; 
        private readonly ProductsController _sut;

        public ProductControllerTest()
        {
            _fixture = new Fixture();
            _productServiceMock = _fixture.Freeze<Mock<IProductService>>();
            _sut = new ProductsController(_productServiceMock.Object);
        }
        [Fact]
        public async Task GetProducts_ShouldReturn_ListOfProducts_WhenOkResult()
        {
            //arrange
            var productControllerMock = _fixture.Create<Task<IEnumerable<Product>>>();
            _productServiceMock.Setup(x => x.GetProducts()).Returns(productControllerMock);
           
            //act
            var result = await _sut.GetProducts().ConfigureAwait(false);

            //assert
            // Assert.NotNull(result);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProduct_ShouldReturn_SingleProduct_WhenOkResult()
        {
            //arrange
            var productControllerMock = _fixture.Create<Task<Product>>();
            var id = _fixture.Create<int>();
            _productServiceMock.Setup(x => x.GetProduct(id)).Returns(productControllerMock);

            //act
            var result = await _sut.GetProduct(id).ConfigureAwait(false);

            //assert
            // Assert.NotNull(result);
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task DeleteProduct_ShouldReturnNoContents_WhenDeletedRecord()
        {
            //arrange
            var productControllerMock = _fixture.Create<Task<Product>>();
            var id = _fixture.Create<int>();
            _productServiceMock.Setup(x => x.DeleteProduct(id)).Returns(productControllerMock);

            //act
            var result = await _sut.DeleteProduct(id).ConfigureAwait(false);

            //assert
            // Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<NoContentResult>();
        }

       
    }
}