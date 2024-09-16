using Internship_Netsol_ProductManagement_DotNetApi.DTO;
using Internship_Netsol_ProductManagement_DotNetApi.Models;

public static class CustomizeOrderMappers
{
    public static CustomizeOrderDTO FromModelToDto(this CustomizeOrder customizeOrder)
    {
        return new CustomizeOrderDTO
        {
            Id = customizeOrder.Id,
            Title = customizeOrder.Title,
            Description = customizeOrder.Description,
            PaymentStatus = customizeOrder.PaymentStatus,
            PaymentType = customizeOrder.PaymentType,
            FrontendPages = customizeOrder.FrontendPages,
            Note = customizeOrder.Note,
            DeliveryDate = customizeOrder.DeliveryDate,
            OrderDate = customizeOrder.OrderDate,
        };
    }

    public static CustomizeOrder FromDtoToModel(this CreateCustomizeOrderDTO orderDto)
    {
        return new CustomizeOrder
        {
            Title = orderDto.Title,
            Description = orderDto.Description,
            PaymentStatus = orderDto.PaymentStatus,
            PaymentType = orderDto.PaymentType,
            FrontendPages = orderDto.FrontendPages,
            Note = orderDto.Note,
            DeliveryDate = orderDto.DeliveryDate,
            OrderDate = orderDto.OrderDate,
        };
    }
}
