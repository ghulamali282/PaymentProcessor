using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using PaymentProcessor.Application.Payments;
using PaymentProcessor.Application.Shared.Payments;
using PaymentProcessor.Application.Shared.Payments.Dto;
using PaymentProcessor.Domain.Payments;
using PaymentProcessor.Domain.Repository;
using PaymentProcessor.Infrastructer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.IntegrationTests.Payments
{
    [TestFixture]
    public class ProcessPaymentTest
    {
        [Fact]
        public async Task UseCase_Should_Not_Save()
        {
            //Arrange
            var paymentService = new Mock<IPaymentService>();
            var validatorMock = new Mock<IValidator<PaymentDto>>(MockBehavior.Strict);

            var request = new PaymentDto
            {
                Amount = 40,
                CardHolder = "Ghulam Ali",
                CreditCardNumber = "6",
                ExpirationDate = DateTime.Now.AddDays(1),
                SecurityCode = "345"
            };

            var result = new ValidationResult();
            result.Errors.Add(new ValidationFailure("CreditCardNumber", "Credit card number is not valid"));

            validatorMock
                .Setup(validator => validator.ValidateAsync(request, It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);

            var sut = new UseCase(uowMock.Object, repositoryMock, validatorMock.Object) as IUseCaseHandler<Request, Response>;

            //Act
            var act = paymentService.Setup(x => x.ProcessPayment(request));

            //Assert
            act.Throws()
            await act..Should().NotThrowAsync();
            Mock.Get(repositoryMock).Verify(repo => repo.SaveAsync(It.IsAny<object>()), Times.Never);
        }

        [Test]
        public void ShouldCreateTodoItem()
        {
            var payment = new PaymentDto
            {
                Amount = 40,
                CardHolder = "Ghulam Ali",
                CreditCardNumber = "6",
                ExpirationDate = DateTime.Now.AddDays(1),
                SecurityCode = "345"
            };

            var paymentService = new Mock<IPaymentService>();


           var result= paymentService.Setup(x => x.ProcessPayment(payment));

            Assert.IsNotNull(result);


          
        }
    }
}
