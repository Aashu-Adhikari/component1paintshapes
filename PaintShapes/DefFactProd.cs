using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    public class DefFactProd
    {
        //bool method to check whether the type is shape
        
        public bool isShape(string type)
        {
            if (type == "shape")
            {
                return true;
            }
            return false;
        }
    }
}
