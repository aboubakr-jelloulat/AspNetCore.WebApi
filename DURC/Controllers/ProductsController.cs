using DURC.Data;
using Microsoft.AspNetCore.Mvc;

namespace DURC.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    /*
        readonly means:
            This field can be assigned ONLY: at declaration OR inside the constructor
     */

    public ProductsController(ApplicationDbContext dbContext)
    {
        _db = dbContext;
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<int>> CreateProduct(Product product)
    {
        product.Id = 0;

        _db.Products.Add(product);
        await _db.SaveChangesAsync();

        return Ok(product.Id);
    }

    [HttpGet]
    [Route("")]
    public  ActionResult<IEnumerable<Product>> Get()
    {
        var records = _db.Products.ToList();
        if (!records.Any())
            return NotFound();

        return Ok(records);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var record = _db.Products.Find(id);
        if (record is null)
            return NotFound();

        return Ok(record);
    }




    [HttpPut]
    [Route("")]
    public async Task<ActionResult> UpdateProduct(Product product)
    {
        var productFromdb = _db.Products.Find(product.Id);

        if (productFromdb is not null)
        {
            productFromdb.Name = product.Name;
            productFromdb.sku = product.sku;

            _db.Products.Update(productFromdb);

            await _db.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var productFromdb = _db.Products.Find(id);

        if (productFromdb is not null)
        {
            _db.Products.Remove(productFromdb);

            await _db.SaveChangesAsync();
        }

        return Ok();
    }



}

