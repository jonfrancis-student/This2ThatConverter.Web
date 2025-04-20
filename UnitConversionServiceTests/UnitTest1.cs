using This2ThatConverter.Services;
using This2ThatConverter.Services.Interfaces;



namespace UnitConversionServiceTests
{
    public class UnitTest1
    {
        private readonly IUnitConversionService _service = new UnitConversionService();

        #region X to Ounces

        [Theory]
        [InlineData(100, 0.0035274)]
        [InlineData(1000, 0.035274)]

        public void MilligramsToOunces_ReturnsExpected(double input, double expected)
        {
            var result = _service.MilligramsToOunces(input);

            Assert.Equal(expected, result,4);
        }

        [Theory]
        [InlineData(100, 3.5274)]
        [InlineData(1000, 35.274)]

        public void GramsToOunces_ReturnsExpected(double input, double expected)
        {
            var result = _service.GramsToOunces(input);

            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(100, 3527.4)]
        [InlineData(1000, 35274.00004546)]

        public void KilogramsToOunces_ReturnsExpected(double input, double expected)
        {
            var result = _service.KilogramsToOunces(input);

            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(100, 3527400)]
        [InlineData(1000, 35274000)]

        public void MetricTonsToOunces_ReturnsExpected(double input, double expected)
        {
            var result = _service.MetricTonsToOunces(input);

            Assert.Equal(expected, result, 8);
        }
        #endregion

        #region X to Pounds


        [Theory]
        [InlineData(1000000, 2.20462262)]
        [InlineData(10000000, 22.04622622)]

        public void MilligramsToPounds_ReturnsExpected(double input, double expected)
        {
            var result = _service.MilligramsToPounds(input);

            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(1000000, 2204.62262)]
        [InlineData(2000000, 4409.245244)]

        public void GramsToPounds_ReturnsExpected(double input, double expected)
        {
            var result = _service.GramsToPounds(input);

            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(100, 3527.4)]
        [InlineData(1000, 35274.00004546)]

        public void KilogramsToPounds_ReturnsExpected(double input, double expected)
        {
            var result = _service.KilogramsToPounds(input);

            Assert.Equal(expected, result, 4);
        }

        [Theory]
        [InlineData(100, 3527400)]
        [InlineData(1000, 35274000)]

        public void MetricTonsToPounds_ReturnsExpected(double input, double expected)
        {
            var result = _service.MetricTonsToPounds(input);

            Assert.Equal(expected, result, 8);
        }
        #endregion
    }
}
