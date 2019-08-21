using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Tokkepedia.Models
{
    public enum PurchaseType { Consumable, NonConsumable, Subscription };
    public enum ProductType { NoAds, Strikes, Saved, Coins, Avatars, Tokmoji };

    public class PurchaseModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public string Image { get; set; }
        public double PriceUSD { get; set; }
        public int PriceCoins { get; set; }

        public int Quantity { get; set; } = 0;

        public PurchaseType PurchaseType { get; set; }
        public ProductType ProductType { get; set; }
    }
}
