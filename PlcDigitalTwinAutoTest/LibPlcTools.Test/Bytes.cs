using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibPlcTools.Test
{
    public class Bytes
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 4)]
        [InlineData(3, 8)]
        [InlineData(7, 128)]
        public void sadfsadfsadfsadfsterTest(byte bitmuster, byte ergebnis)
        {
            Assert.NotEqual(ergebnis, LibPlcTools.Bitmuster.BitmusterErzeugen(bitmuster));
        }
    }
}
