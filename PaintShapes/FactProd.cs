﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{/// created private class FactoryProducer
 /// </summary>
    class FactProd
    {
        
        public static FactoryAbstract getFactory(String choice)
        {
            //if condition to check if choice is shape or color
            if (choice.Equals("Shapes"))
            {
                return new FactoryShapes();
            }
            return null;
        }
    }
}
