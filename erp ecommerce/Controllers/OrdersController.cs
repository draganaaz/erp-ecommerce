﻿using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository orderRepository { get; }

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllOrders()
        {
            return Ok(orderRepository.GetAllOrders());
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrderById(int orderId)
        {
            Orders order = orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(Orders order)
        {
            orderRepository.AddOrder(order);

            try
            {
                if (!orderRepository.SaveChanges())
                {
                    throw new Exception("Error has occured during the creation of Order.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Order has been created.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateOrder(OrderDto orderDto)
        {
            // Retrieving Order entity from the database based on the passed orderId
            Orders order = orderRepository.GetOrderById(orderDto.OrderId);

            // If the entity doesn't exist, we're returning a 404 error
            if (order == null)
            {
                return NotFound();
            }

            orderRepository.UpdateOrder(order, orderDto);

            try
            {
                if (!orderRepository.SaveChanges())
                {
                    throw new Exception("Order hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Order has been updated.");
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteOrder(int orderId)
        {
            try
            {
                Orders order = orderRepository.GetOrderById(orderId);

                if (order == null)
                {
                    return NotFound();
                }

                orderRepository.DeleteOrder(order);

                if (!orderRepository.SaveChanges())
                {
                    throw new Exception("Order hasn't been deleted successfully.");
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }
        }
    }
}
