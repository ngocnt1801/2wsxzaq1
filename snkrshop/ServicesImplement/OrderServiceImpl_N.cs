using snkrshop.Models;
using snkrshop.Repositories;
using snkrshop.RepositoriesImplement;
using snkrshop.Services;
using snkrshop.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace snkrshop.ServicesImplement
{
    public partial class OrderServiceImpl : OrderService
    {
        const string FAIL = "fail";
        const string SUCCESS = "success";

        

        OrderRepository orderRepository;
        OrderProductRepository orderProductRepository;
        OrderVoucherRepository orderVoucherRepository;
        ImageRepository imageRepository;

        public OrderServiceImpl()
        {
            this.orderRepository = new OrderRepositoryImpl();
            this.orderProductRepository = new OrderProductRepositoryImpl();
            this.orderVoucherRepository = new OrderVoucherRepositoryImpl();
            this.imageRepository = new ImageRepositoryImpl();
        }

        public string ApproveOrder(int orderId)
        {
            string result = FAIL;
            try
            {
                if (orderRepository.UpdateOrderStatus(orderId, OrderStatus.STATUS_APPROVED))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        public string CancelOrder(int orderId)
        {
            string result = FAIL;
            try
            {
                if (orderRepository.UpdateOrderStatus(orderId,OrderStatus.STATUS_CANCEL))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        public string Checkout(string userId, float totalPrice, ProductQuantity[] products, string voucher)
        {
            string result = FAIL;
            try
            {
                int orderId = orderRepository.AddOrder(userId, totalPrice);
                if (orderVoucherRepository.AddOrderVoucher(orderId, voucher))
                {
                    
                        foreach (ProductQuantity product in products)
                        {
                            orderProductRepository.AddProductOrder(orderId, product.ProductId, product.Quantity);
                            result = SUCCESS;
                        }

                    
                }
                
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                result = FAIL;
                throw new Exception(ex.Message);
            }
            return result;
        }

        public string DeleteOrder(int orderId)
        {
            string result = FAIL;
            try
            {
                if (orderRepository.DeleteOrder(orderId))
                {
                    result = SUCCESS;
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return result;
        }

        public User_Order GetDetailOfOrder(int orderId, string username)
        {
            User_Order userOrder = null;

            try
            {
                userOrder = orderRepository.GetOrder(orderId, username);
                userOrder.Products = orderProductRepository.GetListProductOfOrder(orderId);
                foreach (User_ProductOrder product in userOrder.Products)
                {
                    product.ImageUrl = imageRepository.GetFirstImageOfProduct(product.ProductId);
                }
            }
            catch (Exception ex)
            {
                ex.LogExceptionToFile();
                throw new Exception(ex.Message);
            }
            return userOrder;
        }
    }
}