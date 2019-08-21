using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BraintreeHttp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayPalCheckoutSdk.Orders;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;
using TokHelper = Tokkepedia.Tools.Helpers;

namespace Tokkepedia.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaypalService _paypalService;
        private readonly IPaymentService _paymentService;
        private readonly IStickerService _stickerService;

        public PaymentController(IPaypalService paypalService, IPaymentService paymentService, IStickerService stickerService)
        {
            _paypalService = paypalService;
            _paymentService = paymentService;
            _stickerService = stickerService;
        }

        [HttpGet]
        public async Task<IActionResult> Paypal(string productId)
        {
            //var response = await _paypalService.GenerateRequest(packageId);
            //var result = response.Result<Order>();
            var userId = User.GetUserId();
            var result = await _paypalService.OrderProduct(productId, userId);

            if (result != null)
            {
                Console.WriteLine("Status: {0}", result.Status);
                Console.WriteLine("Order Id: {0}", result.Id);
                Console.WriteLine("Intent: {0}", result.Intent);
                Console.WriteLine("Links:");
                foreach (LinkDescription link in result.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
                AmountWithBreakdown amount = result.PurchaseUnits[0].Amount;
                Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);
            }

            return Json(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Complete([FromBody] Order myOrder)
        {
            //var myOrder = JsonConvert.DeserializeObject<Order>(order);

            using (var Reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                var g = await Reader.ReadToEndAsync();
                var b = g;
            }
            TransactionViewModel trans = new TransactionViewModel() { UserId = User.GetUserId() };
            trans.TransactionDetails = myOrder;
            var res = await _paymentService.CompletePayment(trans);
            // Update some statuses here or after completing the payment

            return Json(res);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BuyAvatar(string avatarId, TokHelper.ValueType type = TokHelper.ValueType.Coins)
        {
            // Avatar Purchase Logic here...
            return Json(null);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BuySticker(string stickerId, TokHelper.ValueType type = TokHelper.ValueType.Coins)
        {
            return Json(await _stickerService.PurchaseStickerAsync(stickerId));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BuyAndSelectSticker(string stickerId, string tokId, TokHelper.ValueType type = TokHelper.ValueType.Coins)
        {
            var success = await _stickerService.PurchaseStickerAsync(stickerId);
            if (success)
                return Json(await _stickerService.AddStickerToTokAsync(tokId, stickerId));
            else
                return Json(false);
        }
    }
}