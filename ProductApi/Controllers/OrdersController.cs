using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Entities;
using ProductApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
// TODO: Add [ApiKeyAuth] attribute once Exercise 3 (security) is done
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Liste toutes les commandes")]
    [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Récupère les détails d'une commande par son ID")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Crée une nouvelle commande")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderCreateDto)
    {
        var (order, errorMessage) = await _orderService.CreateOrderAsync(orderCreateDto);
        if (errorMessage != null)
        {
            return BadRequest(errorMessage);
        }
        return CreatedAtAction(nameof(GetOrderById), new { id = order!.Id }, order);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Met à jour le statut d'une commande")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] OrderUpdateDto orderUpdateDto)
    {
        var (order, errorMessage) = await _orderService.UpdateOrderStatusAsync(id, orderUpdateDto.Status);
        if (errorMessage != null)
        {
            // Distinguish between NotFound and BadRequest based on error message or a more structured error from service
            if (errorMessage.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(errorMessage);
            return BadRequest(errorMessage);
        }
        return Ok(order);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Annule (supprime) une commande sous conditions")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var (success, errorMessage) = await _orderService.DeleteOrderAsync(id);
        if (!success)
        {
            if (errorMessage != null && errorMessage.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(errorMessage);
            return BadRequest(errorMessage ?? "Failed to cancel order.");
        }
        return NoContent();
    }

    [HttpGet("status/{status}")]
    [SwaggerOperation(Summary = "Récupère les commandes par statut")]
    [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetOrdersByStatus(OrderStatus status)
    {
        var orders = await _orderService.GetOrdersByStatusAsync(status);
        return Ok(orders);
    }

    [HttpGet("report/delivered")]
    [SwaggerOperation(Summary = "Rapport des commandes livrées sur une période donnée")]
    [ProducesResponseType(typeof(List<OrderDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDeliveredOrdersReport([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        if (from == default || to == default || from > to)
        {
            return BadRequest("Valid 'from' and 'to' date parameters are required, and 'from' must not be after 'to'.");
        }
        var orders = await _orderService.GetDeliveredOrdersReportAsync(from, to);
        return Ok(orders);
    }
}