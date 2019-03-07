using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using GoodToyes.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToyes.Models
{
    public class Payment
    {
        private IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICart _cart;



        public Payment(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICart cart)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _cart = cart;
        }

        public Payment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// gets address and amount to charge and runs through the trasaction process
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="User"></param>
        /// <param name="cart"></param>
        /// <returns>String</returns>
        public string Run(string cardNumber, ApplicationUser user, Cart cart)
        {
            //sets the enviornment to sanbox
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            //Gets access requirment from user secrets
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AuthNetAPILogin"],

                ItemElementName = ItemChoiceType.transactionKey,

                Item = _configuration["AuthNetTransactionKey"]

            };

            //gets credit card info
            var creditCard = new creditCardType
            {
                cardNumber = cardNumber,

                expirationDate = "1022"
            };

            //gets the address
            customerAddressType billingAddress = GetAddress(user);

            //sets the payment type to credit card
            var paymentType = new paymentType { Item = creditCard };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = cart.GrandTotal,
                payment = paymentType,
                billTo = billingAddress,

            };

            //creates the request for the transaction
            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };

            //creates the transaction controller
            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if(response != null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    if(response.transactionResponse.messages != null)
                    {
                        return "Okay";
                    }
                }
                else
                {
                    return "Something Went Wrong";
                }
            }

            return "Something Went Wrong";
        }

        /// <summary>
        /// Gets users name and address
        /// </summary>
        /// <param name="User"></param>
        /// <returns>the address</returns>
        private customerAddressType GetAddress(ApplicationUser User)
        {
            customerAddressType address = new customerAddressType()
            {
                firstName = User.FirstName,
                lastName = User.LastName,
                address = User.StreetAddress,
                city = User.City,
                zip = User.Zip
                
            };
            return address;
        }
    }
}
