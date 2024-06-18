using FoodOrderingApp.DTOs.Addon;
using FoodOrderingApp.DTOs.Order;
using FoodOrderingApp.DTOs.OrderAddon;
using FoodOrderingApp.Models;

public static class OrderMappers
{
    public static OrderDto ToOrderDto(this Order orderModel)
    {
        return new OrderDto
        {
            Id = orderModel.Id,
            UserName = orderModel.UserName,
            DishName = orderModel.DishName,
            RestaurantId = orderModel.RestaurantId,
            RestaurantName = orderModel.RestaurantName,
            Price = orderModel.Price,
            Comment = orderModel.Comment,
            MessageContent = orderModel.MessageContent,
            OrderAddons = orderModel.OrderAddons.Select(oa => new OrderAddonDto
            {
                OrderId = oa.OrderId,
                AddonId = oa.AddonId,
                Quantity = oa.Quantity,
                Addon = new AddonDto
                {
                    Id = oa.Addon.Id,
                    Name = oa.Addon.Name,
                    Price = oa.Addon.Price,
                    RestaurantId = oa.Addon.RestaurantId
                }
            }).ToList()
        };
    }

    public static Order ToOrderFromConfirmDto(this OrderDto orderDto)
    {
        return new Order
        {
            UserName = orderDto.UserName,
            DishId = orderDto.DishId,
            DishName = orderDto.DishName,
            RestaurantId = orderDto.RestaurantId,
            RestaurantName = orderDto.RestaurantName,
            Price = orderDto.Price,
            Comment = orderDto.Comment,
            MessageContent = orderDto.MessageContent,
            OrderAddons = orderDto.OrderAddons.Select(oa => new OrderAddon
            {
                OrderId = orderDto.Id,
                AddonId = oa.AddonId,
                Quantity = oa.Quantity,
            }).ToList()
        };
    }
}
