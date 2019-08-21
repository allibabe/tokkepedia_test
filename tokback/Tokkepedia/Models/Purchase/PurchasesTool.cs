using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tokkepedia.Models
{
    public static class PurchasesTool
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
                AddressLine1 = "N/a",
                AddressLine2 = "N/a",
                AdminArea2 = "N/a",
                AdminArea1 = "N/a",
                PostalCode = "0",
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


        private static List<PurchaseModel> _products = new List<PurchaseModel>() {
            #region List of products
            //Subscriptions
            new PurchaseModel(){ Id="subscription_1", Name="Basic", Type="subscription", PriceUSD = 0.99, Quantity=1, PurchaseType = PurchaseType.Subscription, ProductType = ProductType.Coins },
            new PurchaseModel(){ Id="subscription_2", Name="Mid", Type="subscription", PriceUSD = 1.99, Quantity=1, PurchaseType = PurchaseType.Subscription, ProductType = ProductType.Coins },
            new PurchaseModel(){ Id="subscription_3", Name="Premier", Type="subscription", PriceUSD = 2.99, Quantity=1, PurchaseType = PurchaseType.Subscription, ProductType = ProductType.NoAds },
            //Avatars
            new PurchaseModel(){ Id="avatar_1", Name="Lani Jaramillo", Type="nonconsumable", PriceUSD = 0.00, PriceCoins = 0, Image="https://tokketcontent.blob.core.windows.net/images/Avatar1_2048x2048.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Avatars },
            new PurchaseModel(){ Id="avatar_2", Name="Joleen Hackett", Type="nonconsumable", PriceUSD = 1.99,  PriceCoins = 90, Image="https://tokketcontent.blob.core.windows.net/images/Avatar2_2048x2048.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Avatars },
            new PurchaseModel(){ Id="avatar_3", Name="Eloisa Tobin", Type="nonconsumable", PriceUSD = 1.99, PriceCoins = 90, Image="https://tokketcontent.blob.core.windows.net/images/Avatar3_2048x2048.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Avatars },
            new PurchaseModel(){ Id="avatar_4", Name="Arron	Crider", Type="nonconsumable", PriceUSD = 3.99, PriceCoins = 180, Image="https://tokketcontent.blob.core.windows.net/images/Avatar4_2048x2048.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Avatars },
            new PurchaseModel(){ Id="avatar_5", Name="Russ Yost", Type="nonconsumable", PriceUSD = 3.99, PriceCoins = 180, Image="https://tokketcontent.blob.core.windows.net/images/Avatar5_2048x2048.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Avatars },
            //Tokmoji
            new PurchaseModel(){ Id="tokmoji_1", Name="Cool", Type="nonconsumable", PriceUSD = 0.00, PriceCoins = 0, Image="https://tokketcontent.blob.core.windows.net/images/TOKMOJI_Cool.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Tokmoji },
            new PurchaseModel(){ Id="tokmoji_2", Name="Thanks for posting this", Type="nonconsumable", PriceUSD = 0.99,  PriceCoins = 45, Image="https://tokketcontent.blob.core.windows.net/images/TOKMOJI_Thanks-for-posting-this.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Tokmoji },
            new PurchaseModel(){ Id="tokmoji_3", Name="That's incorrect", Type="nonconsumable", PriceUSD = 0.99, PriceCoins = 45, Image="https://tokketcontent.blob.core.windows.net/images/TOKMOJI_That_s-incorrect.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Tokmoji },
            new PurchaseModel(){ Id="tokmoji_4", Name="That's incorrect (Style 2)", Type="nonconsumable", PriceUSD = 0.99, PriceCoins = 45, Image="https://tokketcontent.blob.core.windows.net/images/TOKMOJI_That_s-incorrect2.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Tokmoji },
            new PurchaseModel(){ Id="tokmoji_5", Name="That's interesting", Type="nonconsumable", PriceUSD = 0.99, PriceCoins = 45, Image="https://tokketcontent.blob.core.windows.net/images/TOKMOJI_That_s-Intresting.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Tokmoji },
            new PurchaseModel(){ Id="tokmoji_6", Name="Wow", Type="nonconsumable", PriceUSD = 0.99, PriceCoins = 45, Image="https://tokketcontent.blob.core.windows.net/images/TOKMOJI_wow.png", Quantity=1, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Tokmoji },
            //Tok Blitz
            new PurchaseModel(){ Id="tokblitz_strikes1", Name="72 Strikes", Type="consumable", PriceUSD = 1.99, Quantity=72, PurchaseType = PurchaseType.Consumable, ProductType = ProductType.Strikes },
            new PurchaseModel(){ Id="tokblitz_strikes2", Name="144 Strikes", Type="consumable", PriceUSD = 2.99, Quantity=144, PurchaseType = PurchaseType.Consumable, ProductType = ProductType.Strikes },
            new PurchaseModel(){ Id="tokblitz_strikes3", Name="288 Strikes", Type="consumable", PriceUSD = 4.99, Quantity=288, PurchaseType = PurchaseType.Consumable, ProductType = ProductType.Strikes },
            new PurchaseModel(){ Id="tokblitz_strikes4", Name="624 Strikes", Type="consumable", PriceUSD = 9.99, Quantity=624, PurchaseType = PurchaseType.Consumable, ProductType = ProductType.Strikes },
            new PurchaseModel(){ Id="tokblitz_strikes5", Name="1800 Strikes", Type="consumable", PriceUSD = 19.99, Quantity=1800, PurchaseType = PurchaseType.Consumable, ProductType = ProductType.Strikes },
            new PurchaseModel(){ Id="tokblitz_noads", Name="No Ads (Tok Blitz)", Type="nonconsumable", PriceUSD = 2.99, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.NoAds },
            new PurchaseModel(){ Id="tokblitz_saved1", Name="10 Saved Games", Type="nonconsumable", PriceUSD = 1.99, Quantity=10, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Saved },
            new PurchaseModel(){ Id="tokblitz_saved2", Name="25 Saved Games", Type="nonconsumable", PriceUSD = 3.99, Quantity=25, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Saved },
            new PurchaseModel(){ Id="tokblitz_saved3", Name="50 Saved Games", Type="nonconsumable", PriceUSD = 5.99, Quantity=50, PurchaseType = PurchaseType.NonConsumable, ProductType = ProductType.Saved }
            #endregion
        };

        public static PurchaseModel GetProduct(string id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public static List<PurchaseModel> GetProducts()
        {
            return _products;
        }

        public static OrderRequest GetOrderRequest(this PurchaseModel purchase, string userId)
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                Intent = "CAPTURE",

                ApplicationContext = _defaultApplicationContext,
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                  new PurchaseUnitRequest{
                    ReferenceId =  purchase.Id,
                    Description = purchase.Name,
                    CustomId = purchase.Id,
                    SoftDescriptor = "",
                    Amount = new AmountWithBreakdown
                    {
                      CurrencyCode = "USD",
                      Value = (purchase.PriceUSD).ToString(),
                      Breakdown = new AmountBreakdown
                      {
                        ItemTotal = new Money
                        {
                          CurrencyCode = "USD",
                          Value = (purchase.PriceUSD).ToString()
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
                        Name = purchase.Id,
                        Description = purchase.Name,
                        Sku = purchase.Id,
                        UnitAmount = new Money
                        {
                          CurrencyCode = "USD",
                          Value = (purchase.PriceUSD).ToString()
                        },
                        Quantity = "1", // Temporary to fix the issue - purchase.Quantity.ToString(),
                        Category = "DIGITAL_GOODS"
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
