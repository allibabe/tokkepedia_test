using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tokkepedia.Tools.Helpers
{
    public static class PackageHelper
    {
        #region Default Members
        private static ShippingDetails _defaultShippingDetails = new ShippingDetails
        {
            Name = new Name
            {
                FullName = "Tokket Inc."
            },
            AddressPortable = new AddressPortable
            {
                AddressLine1 = "123 Townsend St",
                AddressLine2 = "Floor 6",
                AdminArea2 = "San Francisco",
                AdminArea1 = "CA",
                PostalCode = "94107",
                CountryCode = "US"
            }
        };
        private static ApplicationContext _defaultApplicationContext = new ApplicationContext
        {
            BrandName = "TOKKET INC",
            LandingPage = "BILLING",
            UserAction = "CONTINUE",
            ShippingPreference = "SET_PROVIDED_ADDRESS"
        };
        #endregion

        public static OrderRequest BasicPackage()
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                Intent = "CAPTURE",
                
                ApplicationContext = _defaultApplicationContext,
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                  new PurchaseUnitRequest{
                    ReferenceId =  "PUHF",
                    Description = "Basic Package",
                    CustomId = "CUST-BasicPackage",
                    SoftDescriptor = "",
                    Amount = new AmountWithBreakdown
                    {
                      CurrencyCode = "USD",
                      Value = "0.99",
                      Breakdown = new AmountBreakdown
                      {
                        ItemTotal = new Money
                        {
                          CurrencyCode = "USD",
                          Value = "0.99"
                        },
                        TaxTotal = new Money
                        {
                          CurrencyCode = "USD",
                          Value = "0.00"
                        }
                      }
                    },
                    Items = new List<Item>
                    {
                      new Item
                      {
                        Name = "Basic Package",
                        Description = "Basic Package",
                        Sku = "sku01",
                        UnitAmount = new Money
                        {
                          CurrencyCode = "USD",
                          Value = "0.99"
                        },
                        Quantity = "1",
                        Category = "PHYSICAL_GOODS"
                      },
                    },
                    Shipping = _defaultShippingDetails
                  }
                }
            };

            return orderRequest;
        }
    }
}
