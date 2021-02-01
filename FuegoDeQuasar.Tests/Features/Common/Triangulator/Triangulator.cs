using FuegoDeQuasar.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FuegoDeQuasar.Tests.Features.Common.Triangulator
{
    public class Triangulator
    {
        [Fact]
        public void Triangulate_InputIsDocumented_ReturnCorrectResult()
        {
            var p1 = new Position(-500, -200);
            var p2 = new Position(100, -100);
            var p3 = new Position(500, 100);

            var d1 = (float)100.0;
            var d2 = (float)115.5;
            var d3 = (float)142.7;

            var result = FuegoDeQuasar.Features.Common.Triangulator.Triangulator.Triangulate(p1, p2, p3, d1, d2, d3);

            Assert.Equal(-487.2859125, result.X, 1);
            Assert.Equal(1557.014225, result.Y, 1);
        }
    }
}
