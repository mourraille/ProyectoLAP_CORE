using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace BL
{
   public class OrderState
    {

        public string NAME { get; set; }

        public DateTime TIMEASIGNED { get; set; }

        public int orderStateID { get; set; }

        public OrderState() { }

        public OrderState(string NAME, DateTime TIMEASIGNED, int orderStateID) {

            this.NAME = NAME;
            this.TIMEASIGNED = TIMEASIGNED;
            this.orderStateID = orderStateID;


        }

        public List<OrderState> getOrderStates() {
            List<TOorderState> list = new DAOorderState().getOrderStates();
            List<OrderState> states = new List<OrderState>();
            foreach (TOorderState item in list)
            {
                states.Add(new OrderState(item.NAME, item.TIMEASIGNED, item.orderStateID));
            }
            return states;

        }

        public Boolean setTime(int id, DateTime time) {
            return new DAOorderState().setOrderTime(id, time);
        }
    }
}
