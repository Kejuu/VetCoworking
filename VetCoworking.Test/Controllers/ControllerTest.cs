using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetCoworking.Domain.Abstractions;
using Xunit;
using VetCoworking.Domain.Models;
using VetCoworking.Repositories;
using VetCoworking.Persistence;
using VetCoworking.App.Model;

namespace VetCoworking.Test.Controllers
{
    public class ControllerTest
    {
        private readonly IBookingsRepository BookingsRepository = new BookingsRepository(new VetCoworkingContext("Host=\tisilo.db.elephantsql.com;Database=qdfhdddg;Username=qdfhdddg;Password=wv2Gzeft26a9fAEbZ_lHEqKZfcY2vud3"));


        [Test]
        public async Task GetAll_ShouldReturn_HttpStatus_Accepted()
        {
            var controller = new App.Controllers.BookingsController(BookingsRepository);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //ACT
            var response = await controller.GetAll(default);
            //ASSERT
            response.StatusCode.Should().Be(202);
        }
        [Test]
        public async Task GetById_ShouldReturn_HttpStatus_Accepted()
        {
            var controller = new App.Controllers.BookingsController(BookingsRepository);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //ACT
            var response = await controller.GetById(Guid.Parse("8429de76-c326-4c7e-bdc6-c4711fb22917"),default);
            //ASSERT
            response.StatusCode.Should().Be(202);
        }
        [Test]
        public async Task GetById_ShouldReturn_HttpStatus_NotFound()
        {
            var controller = new App.Controllers.BookingsController(BookingsRepository);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //ACT
            var response = await controller.GetById(Guid.Parse("8429de76-c123-4c7e-bdc6-c4711fb22917"), default);
            //ASSERT
            response.StatusCode.Should().Be(300);
        }


    }
}
