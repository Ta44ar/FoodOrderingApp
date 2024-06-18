using FoodOrderingApp.DTOs.Order;
using FoodOrderingApp.Models;
using Microsoft.Graph.Models;
using System.Collections.Concurrent;

namespace FoodOrderingApp.Interfaces
{
    public interface IOrderRepository
    {
        Task UpdateCommentAsync(int orderId, string newComment);
        Task DeleteCommentAsync(int orderId);
        Task<List<OrderDto>> GetAllFromRestaurantAsync(int restaurantId);
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task<Order> AddOrderAsync(Order orderModel);
        Task<OrderDto?> DeleteOrderAsync(int id);

    }
}
