using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace route
{
     public class Node
    {
        public int id;
        public float latitude;
        public float longitude;
        public Node(int id, float latitude, float longitude)
        {
            this.id = id;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public float getLatitude()
        {
            return latitude;
        }
        public float getLongitude()
        {
            return longitude;
        }
        //using to text
        public string asString()
        {
            return "(" + id + "|" + latitude + "|" + longitude + ")";
        }
    }
}
