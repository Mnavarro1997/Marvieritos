using MarvieritosApp.DataBase;
using MarvieritosApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvieritosApp.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly EcommerceDb _ecommerceDb;

        public OrderController(EcommerceDb ecommerceDb)
        {
            _ecommerceDb = ecommerceDb;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            if (_ecommerceDb.Order.Any())
                return Ok(_ecommerceDb.Order);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById(int id)
        {
            if (_ecommerceDb.Order.Any(x => x.id == id))
                return Ok(_ecommerceDb.Order.FirstOrDefault(x => x.id == id));
            else
                return NoContent();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Add([FromBody] Order order)
        {
            if (!_ecommerceDb.Order.Any(p => p.id == order.id))
            {
                _ecommerceDb.Order.Add(order);
                _ecommerceDb.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Exists a order with id{order.id}");
            }
        }

        // PUT api/<ProductsController>/productId
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Order order)
        {
            if (_ecommerceDb.Order.Any(p => p.id == id))
            {
                var OrderToUpdate = _ecommerceDb.Order.Single(p => p.id == id);
                _ecommerceDb.Order.Remove(OrderToUpdate);
                _ecommerceDb.Order.Add(order);
                _ecommerceDb.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a order with id {id}");
            }
        }

        // DELETE api/<ProductsController>/productId
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_ecommerceDb.Order.Any(p => p.id == id))
            {
                var OrderToDelete = _ecommerceDb.Order.Single(p => p.id == id);
                _ecommerceDb.Order.Remove(OrderToDelete);
                _ecommerceDb.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest($"Don't exist a order with id {id}");
            }
        }
    }
}