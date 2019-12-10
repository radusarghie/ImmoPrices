using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Immo.Logic
{
    public static class GuidExtensions
    {
      
        public static Guid NextGuid(Guid guid)
        {
            int[] byteOrder = { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };
            var bytes = guid.ToByteArray();
            var canIncrement = byteOrder.Any(i => ++bytes[i] != 0);
            return new Guid(canIncrement ? bytes : new byte[16]);
        }
    }
}
