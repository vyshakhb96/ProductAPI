using Moq;
using ProductsAPI.Bussiness;
using ProductsAPI.Controllers;
using ProductsAPI.DataManager;
using ProductsAPI.Model;

namespace TestProductAPI
{
    public class UnitTest1
    {
        [Fact]
        public void PostShouldReturnBadRequest()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails();
            storageMock.Setup(x => x.Add(It.IsAny<ProductDetails>())).Returns(false);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.AddProduct(productDetails);
            Assert.NotNull(result);
            Assert.Equal(false, result.Response);
        }

        [Fact]
        public void PostShouldReturnOK()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails { Name = "MI", Category = "phone" ,Description="Android",Rate="20000"};
            storageMock.Setup(x => x.Add(It.IsAny<ProductDetails>())).Returns(true);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.AddProduct(productDetails);
            Assert.NotNull(result);
            Assert.Equal(true, result.Response);
        }


        [Fact]
        public void GetAllShouldReturnProducts()
        {
            var storageMock = new Mock<IProductStorageManager>();
            List<ProductListItem> businessResponse = new List<ProductListItem>();
            var item = new ProductListItem();
            item.Id = "1";
            item.Name = "MI";
            businessResponse.Add(item);
            storageMock.Setup(x => x.GetAll()).Returns(businessResponse);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.GetAllProducts();
            Assert.NotNull(result);
            Assert.Equal(1, result.Response.Count);
        }


        [Fact]
        public void GetAllShouldReturnNotFound()
        {
            var storageMock = new Mock<IProductStorageManager>();
            List<ProductListItem> businessResponse = new List<ProductListItem>();
            storageMock.Setup(x => x.GetAll()).Returns(businessResponse);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            var result = productBusiness.GetAllProducts();
            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
        [Fact]
        public void GetShouldReturnProduct()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails { Name = "MI", Category = "phone", Description = "Android", Rate = "20000" };
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string IdTest = "1";
            var result = productBusiness.GetProductDetails(IdTest);

            Assert.NotNull(result);
            Assert.Equal("MI", result.Response.Name);
        }

        [Fact]
        public void GetShouldReturnBadRequest()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails();
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string IdTest = "";
            var result = productBusiness.GetProductDetails(IdTest);

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void GetShouldReturnNotFound()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = null; 
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string IdTest = "28";
            var result = productBusiness.GetProductDetails(IdTest);

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void DeleteShouldReturnSuccess()
        {
            var storageMock = new Mock<IProductStorageManager>();
            storageMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(true);
            ProductDetails productDetails = new ProductDetails { Name = "MI", Category = "phone", Description = "Android", Rate = "20000" };
            storageMock.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(productDetails);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string IdTest = "1";
            var result = productBusiness.DeleteProduct(IdTest);

            Assert.NotNull(result);
            Assert.Equal(true, result.Response);
        }

        [Fact]
        public void DeleteShouldReturnBadRequest()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails();
            storageMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(false);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string IdTest = "";
            var result = productBusiness.DeleteProduct(IdTest);

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void DeleteShouldReturnNotFound()
        {
            var storageMock = new Mock<IProductStorageManager>();
            ProductDetails productDetails = new ProductDetails();
            storageMock.Setup(x => x.Delete(It.IsAny<string>())).Returns(true);

            ProductBusiness productBusiness = new ProductBusiness(storageMock.Object);
            string IdTest = "28";
            var result = productBusiness.DeleteProduct(IdTest);

            Assert.NotNull(result);
            Assert.Equal(System.Net.HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}