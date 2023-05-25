using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EmployeeManagement.API.Model;
using EmployeeManagement.API.Service.Common;
using EmployeeManagement.API.Service.Interfaces;
using EmployeeManagementLookup.API.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System;

namespace EmployeeManagement.API.Test
{
    [TestClass]
    public class EmployeeManagementControllerTests
    {
        private readonly Mock<IEmployeeManagementService> _mockService;
        private readonly EmployeeManagementController _controller;
        private readonly Mock<ILogger> _iLogger; 
        private readonly Mock<RequestDelegate> _next; 

        public EmployeeManagementControllerTests()
        {
            _mockService = new Mock<IEmployeeManagementService>();
            _iLogger = new Mock<ILogger>(); 
            _next = new Mock<RequestDelegate>();
            _controller = new EmployeeManagementController(_iLogger.Object, _mockService.Object);            
        }

       


        [TestMethod]
        public async Task LookupEmployeeManagementAsync_InvalidManagerId_ThrowsException()
        {
            // Arrange
            int invalidManagerId = -1;

            // Act
            var exception = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await _controller.LookupEmployeeManagementAsync(invalidManagerId);
            });

            // Assert
            Assert.AreEqual("Manager is missing or empty!", exception.Message);
        }
        [TestMethod]
        public async Task LookupEmployeeManagementAsync_InvalidId_ThrowsException()
        {
            // Arrange
            int invalidManagerId = 0;

            // Act
            var exception = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await _controller.LookupEmployeeManagementAsync(invalidManagerId);
            });

            // Assert
            Assert.AreEqual("Manager is missing or empty!", exception.Message);
        }




    }

}
