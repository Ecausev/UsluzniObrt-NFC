using UsluzniObrt.Model;
using System.Collections.Generic;
using UsluzniObrt.Service.DTO;

namespace UsluzniObrt.Service
{
    public interface IOrderService
    {
        List<Order> GetAll();
        void Add(Order order);
        void Delete(int id);
        void edit(ModifyOrder item);
        Order GetById(int id);
        bool CanPlaceOrder(int id);
    }
}