using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;
using UsluzniObrt.Service.DTO;

namespace UsluzniObrt.Service
{
    public class OrderService : IOrderService
    {

        public IOrderRepository _orderRepository;

        public OrderService()
        {
               
        }

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Add(Order order)
        {
                _orderRepository.Insert(order);
                _orderRepository.Save();
            
            
        }

        public void Delete(int id)
        {
            _orderRepository.Delete(id);
            _orderRepository.Save();
        }

        public void edit(ModifyOrder item)
        {
            var oldOrder = _orderRepository.GetById(item.OrderId);
            if (oldOrder != null)
            {
                oldOrder.Status = item.status;
                _orderRepository.Update(oldOrder);
                _orderRepository.Save();
            }
            
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll().ToList();
        }

        public Order GetById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public bool CanPlaceOrder(int tableNumber)
        {
            return !_orderRepository.GetAll().Any(x => x.TableNumber == tableNumber && (x.Status == OrderStatus.InProgress || x.Status == OrderStatus.Pending));
        }
    }
}
