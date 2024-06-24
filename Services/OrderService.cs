using FoodOrderingApp.DTOs.Order;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Models;

namespace FoodOrderingApp.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<List<OrderDto>> GetAllOrdersFromRestaurant(int restaurantId)
        {

            var orders = await _orderRepo.GetAllFromRestaurantAsync(restaurantId);

            if (orders == null)
            {
                Console.WriteLine("Order repository returned null getting all orders from specified restaurant.");
                return null;
            }
            else
            {
                return orders;
            }
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepo.GetAllAsync();

            if (orders == null)
            {
                Console.WriteLine("Order repository returned null getting all orders.");
                return null;
            }
            else
            {
                return orders;
            }
        }

        public async Task<Order> NewOrder(OrderDto orderDto)
        {
            var orderModel = orderDto.ToOrderFromConfirmDto();

            await _orderRepo.AddOrderAsync(orderModel);

            return orderModel;
        }

        public async Task CancelOrder(int id)
        {   
            await _orderRepo.DeleteOrderAsync(id);
        }

        public async Task UpdateComment(int orderId, string comment)
        {
            await _orderRepo.UpdateCommentAsync(orderId, comment);
        }

        public async Task DeleteComment(int orderId)
        {
            await _orderRepo.DeleteCommentAsync(orderId);
        }
    }
}
