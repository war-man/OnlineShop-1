using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnline.Application.Page;
using ShopOnline.Data;
using ShopOnline.Data.Entity;
using ShopOnline.Model.CartModel;
using ShopOnline.Model.ProductModel;
using ShopOnline.Web.ConnectAPI.InterfaceConnectAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Web.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IUserConnectAPI _userConnectAPI;
        private readonly IProductConnectAPI _productConnectAPI;
        public CartController(IProductConnectAPI productConnectAPI, ApplicationDbContext context, IUserConnectAPI userConnectAPI)
        {
            _userConnectAPI = userConnectAPI;
            _context = context;
            _productConnectAPI = productConnectAPI;
        }
        public IActionResult AddCartUpdate(string Value)
        {
            var request = Value.Split(',');
            var getall = HttpContext.Session.GetString("CartRequest");
            var list = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            foreach(var cart in list)
            {
                if(cart.ProductViewModel.Id== int.Parse(request[1].ToString()) && cart.ColorId== int.Parse(request[2].ToString()) && cart.SizeId== int.Parse(request[3].ToString()))
                {
                    cart.Quantity = cart.Quantity + 1;
                }    
            }
            HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(list));
            return Json(new
            {
                status = true
            });
            
        }
        public IActionResult RemoveCartUpdate(string Value)
        {
            var request = Value.Split(',');
            var getall = HttpContext.Session.GetString("CartRequest");
            var list = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            foreach (var cart in list)
            {
                if (cart.ProductViewModel.Id == int.Parse(request[1].ToString()) && cart.ColorId == int.Parse(request[2].ToString()) && cart.SizeId == int.Parse(request[3].ToString()))
                {
                    cart.Quantity = cart.Quantity - 1;
                }
            }
            HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(list));
            return Json(new
            {
                status = true
            });

        }
        public async Task<IActionResult> AddOrder(PaymentCart request)
        {
            string adress = request.Adress;
            string payment = request.Payment;
            var username = await _userConnectAPI.FindUserByName(User.Identity.Name);
            var getall = HttpContext.Session.GetString("CartRequest");
            var listproduct = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            var order = new Order();
            order.CustomAdress = adress;
            order.CustomName = User.Identity.Name;
            order.CustoPhone = username.PhoneNumber;
            order.PaymentName = payment;
            order.DateCreated = DateTime.Now;
            order.UserName = User.Identity.Name;
            
            var listOrderDetail = new List<OrderDetail>();
            foreach (var product in listproduct)
            {
                var productcolor = await _productConnectAPI.FindColorById(product.ColorId);
                var productSize = await _productConnectAPI.FindProductSizeById(product.SizeId);

                var orderDetail = new OrderDetail()
                {
                    ProductId = product.ProductViewModel.Id,
                    ProductName = product.ProductViewModel.Name,
                    ProductLastPrice = product.ProductViewModel.LastPrice,
                    ProductPrice = product.ProductViewModel.Price,
                    SizeId = product.SizeId,
                    ColorId=product.ColorId,
                    ColorName=productcolor.Name,
                    SizeName=productSize.Name,
                    ProductQuantity = product.Quantity,
                };
                listOrderDetail.Add(orderDetail);
            }
            order.OrderDetails = listOrderDetail;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("BuySuccess","Cart");
        }
        public  IActionResult Checked()
        {
            return View();
        }
        public IActionResult DeleteCart(string Value)
        {
            var listcart = JsonConvert.DeserializeObject<List<RemoveCart>>(Value);
            var getall = HttpContext.Session.GetString("CartRequest");
            var listcartItem = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            foreach(var cart in listcart)
            {
                var cartitem = listcartItem.SingleOrDefault(x => x.ProductViewModel.Id == cart.ProductId && x.SizeId == cart.SizeId && x.ColorId==cart.ColorId);
                listcartItem.Remove(cartitem);
            }
            HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(listcartItem));
            return Json(new
            {
                status = true
            });
        }

        public IActionResult UpdateCart(string Value)
        {
            var listproduct = JsonConvert.DeserializeObject<List<UpdateCart>>(Value);

            var getall = HttpContext.Session.GetString("CartRequest");
            var listCartItemUpdate = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            foreach(var cart in listproduct)
            {
                var product = listCartItemUpdate.SingleOrDefault(x => x.ProductViewModel.Id == cart.ProductId && x.ColorId == cart.LastColorId && x.SizeId == cart.LastSizeId);
                product.ProductViewModel.Id = cart.ProductId;
                product.ColorId = cart.ColorId;
                product.SizeId = cart.SizeId;
                HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(listCartItemUpdate));
            }
            return Json(new
            {
                status = true
            });
        }
        
        public IActionResult GetAllCart(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var getall = HttpContext.Session.GetString("CartRequest");
            if (getall == null)
            {
                return RedirectToAction("DonFindCart", "Cart");

            }
            var listcart = JsonConvert.DeserializeObject<List<CartItem>>(getall);
            var request = new PageRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var product = from p in listcart
                          select new { p };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                product = product.Where(x => x.p.ProductViewModel.Name.Contains(request.Keyword));
            }
            var total = product.Count();
            var vt = product.Skip((request.PageIndex - 1) * (request.PageSize)).Take(request.PageSize)
                .Select(x => new CartItem()
                {
                    ProductViewModel = x.p.ProductViewModel,
                    ColorId = x.p.ColorId,
                    SizeId = x.p.SizeId,
                    Quantity = x.p.Quantity
                }).ToList();
            var page = new PagedResult<CartItem>()
            {
                Items = vt,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalRecords = total,
            };
            return Json(new
            {
                status = true,
                data = page
            });
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddCart(int productId,int colorId,int sizeId,int quantity)
        {
            if (colorId == 0)
            {
                colorId = 1;
            }
            if (sizeId == 0)
            {
                sizeId = 1;
            }
            var productViewModel = await _productConnectAPI.FindProductById(productId);
            var getall = HttpContext.Session.GetString("CartRequest");
            if (getall != null)
            {
                var listCartItemAdd = JsonConvert.DeserializeObject<List<CartItem>>(getall);
                if (listCartItemAdd.Exists(x => x.ProductViewModel.Id == productId))
                {
                    foreach(var cartadd in listCartItemAdd)
                    {
                        if (cartadd.ProductViewModel.Id == productId)
                        {
                            if (cartadd.ColorId == colorId && cartadd.SizeId == sizeId)
                            {
                                cartadd.Quantity = cartadd.Quantity + 1;
                            }
                            else
                            {
                                var cartItem1 = new CartItem()
                                {
                                    ProductViewModel = productViewModel,
                                    ColorId = colorId,
                                    Quantity = quantity,
                                    SizeId = sizeId
                                };
                                listCartItemAdd.Add(cartItem1);
                            }
                        }
                    }
                }
                else
                {
                    var cartItem2 = new CartItem()
                    {
                        ProductViewModel = productViewModel,
                        ColorId = colorId,
                        Quantity = quantity,
                        SizeId = sizeId
                    };
                    listCartItemAdd.Add(cartItem2);

                }
                HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(listCartItemAdd));

            }
            else
            {
                var listcartItem = new List<CartItem>();
                var cartitem = new CartItem()
                {
                    ProductViewModel = productViewModel,
                    ColorId = colorId,
                    SizeId = sizeId,
                    Quantity = quantity
                };
                listcartItem.Add(cartitem);
                HttpContext.Session.SetString("CartRequest", JsonConvert.SerializeObject(listcartItem));
            }
            return Json(new
            {
                status = true
            });
        }
        public IActionResult DonFindCart()
        {
            return View();
        }
        public IActionResult BuySuccess()
        {
            return View();
        }    
    }
}
