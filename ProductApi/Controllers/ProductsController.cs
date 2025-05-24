using Microsoft.AspNetCore.Mvc;
using ProductApi.Entities;
using ProductApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductApi.Controllers;

/// <summary>
///     Contrôleur pour gérer les produits
/// </summary>
[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductService _productService;

    /// <summary>
    ///     Constructeur de la classe ProductController
    /// </summary>
    /// <param name="productService"></param>
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    ///     Récupère tous les produits
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Récupère tous les produits",
        Description = "Cette opération retourne la liste complète des produits disponibles."
    )]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }
}
