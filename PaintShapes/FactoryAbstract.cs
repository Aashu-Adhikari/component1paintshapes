using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShapes
{
    public abstract class FactoryAbstract
    {
        public abstract Shapes getShapes(String shapeType);
    }
}
