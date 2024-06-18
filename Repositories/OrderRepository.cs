using FoodOrderingApp.Data;
using FoodOrderingApp.DTOs.Order;
using FoodOrderingApp.Interfaces;
using FoodOrderingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderingApp.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
           _context = context;
        }


        // ZAMÓWIENIA
        public async Task<List<OrderDto>> GetAllAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderAddons)
                .ThenInclude(orderAddon => orderAddon.Addon)
                .ToListAsync();

            return orders.Select(o => o.ToOrderDto()).ToList();
        }

        public async Task<List<OrderDto>> GetAllFromRestaurantAsync(int id)
        {
            var orders = await _context.Orders
                .Where(o => o.RestaurantId == id)
                .Include(o => o.OrderAddons)
                .ThenInclude(orderAddon => orderAddon.Addon)
                .ToListAsync();

            return orders.Select(o => o.ToOrderDto()).ToList();
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var selectedOrder = await _context.Orders
                .FirstOrDefaultAsync(o => o.Id == id);

            return selectedOrder?.ToOrderDto();
        }

        public async Task<Order> AddOrderAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<OrderDto?> DeleteOrderAsync(int id)
        {
            var orderToDrop = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id);

            if (orderToDrop is null)
            {
                return null;
            }

            _context.Orders.Remove(orderToDrop);
            await _context.SaveChangesAsync();

            return orderToDrop.ToOrderDto();
        }

        // KOMENTARZE DO ZAMÓWIEŃ
        public async Task UpdateCommentAsync(int id, string newComment)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(d => d.Id == id);
            if (order != null)
            {
                order.Comment = newComment;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(d => d.Id == id);

            if (order != null)
            {
                order.Comment = null;
                await _context.SaveChangesAsync();
            }
        }
    }
}
