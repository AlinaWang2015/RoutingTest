using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace route
{
   public class Arc
    {
        //the id of the head node
        public int headNodeId;
        public  int cost;
        //create an arc with the given head and cost
        Arc(int headNodeId, int cost)
        {
            this.headNodeId = headNodeId;
            this.cost = cost;
        }
        public string asString()
        {
            string str ="";
            if (this.cost == 0)
            { str = "{" + headNodeId + "}"; }
            else
            { str = "{" + headNodeId + "|" + cost + "}"; }
            return str;
        }
    }
}
