﻿using Sct.JSKDAL.Context;
using Sct.JSKDAL.Repository.Absttraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net.Mail;
using Sct.JSKDAL.Entities;

namespace Sct.JSKDAL.Repository.Implementation
{
    public class OrderRepository : IOrderRepository<Order>
    {

        private DBContext ctx;

        public OrderRepository(DBContext context)
        {
            ctx = context;
        }

        public Order Add(Order order)
        {
            ctx.Users.Attach(order.User);
            Order newOrder = ctx.Orders.Add(order);
            ctx.SaveChanges();            
            return newOrder;
        }

        public Order Delete(int userid, Order o)
        {
            var order = ctx.Orders.FirstOrDefault(x => x.Id == o.Id && x.UserId == userid);
            ctx.Orders.Remove(order);
            ctx.SaveChanges();
            return order;
        }

        public Order Read(int id)
        {
            var product = ctx.Orders.Include("OrderDetails").Where(c => c.Id == id).FirstOrDefault();
            return product;
        }

        public IEnumerable<Order> ReadAll()
        {
            //return ctx.Users.Include("Adress").Include("Roles").Include(x => x.Roles.Select(z =>z.Role)).ToList();
            return ctx.Orders.Include("OrderDetails").ToList();
        }

        public IEnumerable<User> GetAllOrderedCustomers(string orderdate)
        {
            DateTime convertedDate = Convert.ToDateTime(orderdate);
            //return ctx.Users.Include("Adress").Include("Roles").Include(x => x.Roles.Select(z =>z.Role)).ToList();
            return ctx.Users.Include("Order")
                .Include(o => o.Order.Select(od => od.OrderDetails.Select(p => p.Product)))
                .Where(or => or.Order.Any(ord => ord.OrderDate == convertedDate)).ToList();
        }

        //----------------------------------Sprint 2
        public IEnumerable<Order> GetOrderedProductsByOrder(string orderdate)
        {
            DateTime convertedDate = Convert.ToDateTime(orderdate);
            return ctx.Orders.Include("OrderDetails").Include(p => p.OrderDetails.Select(od => od.Product))
                .Where(or => or.OrderDate == convertedDate).ToList();
        }

        public Order GetAllOrderedCustomerDetail(string orderdate, int id)
        {
            DateTime convertedDate = Convert.ToDateTime(orderdate);
            return ctx.Orders.Include("OrderDetails").Include(p => p.OrderDetails.Select(od => od.Product)).Include("User")
               .Where(or => or.OrderDate == convertedDate && or.UserId == id).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrderedProductsByDates(string startDate, string endDate)
        {
            DateTime convertedStartDate = Convert.ToDateTime(startDate);
            DateTime convertedEndDate = Convert.ToDateTime(endDate);

            return ctx.Orders.Include("OrderDetails").Include(p => p.OrderDetails.Select(od => od.Product))
                .Where(entry => entry.OrderDate >= convertedStartDate && entry.OrderDate <= convertedEndDate).ToList();
        }
    }
}
