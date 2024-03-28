using Statistics1;

namespace UnitTestMod
{
    public class UnitTest1
    {

        [Fact]
        public void StatisticsMaximumTest()
        {
            int[] source = Statistics.source;

            Array.Sort(source);
            Array.Reverse(source);

            int expectedValue = source[0];

            int actual = Statistics.Maximum();

            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void StatisticsMinimumTest()
        {
            int[] source = Statistics.source;
            Array.Sort(source);

            int expectedValue = source[0];

            int actual = Statistics.Minimum();

            Assert.Equal(expectedValue, actual);

        }

        [Fact]
        public void StatisticsMeanTest()
        {
            int[] source = Statistics.source;
            Array.Sort(Statistics.source);
            double total = 0;
            double expectedValue = 0;

            for (int i = 0; i < source.LongLength; i++)
            {
                total += source[i];
            }

            expectedValue = total / source.LongLength;

            double actual = Statistics.Mean();

            Assert.Equal(expectedValue, actual);

        }

        [Fact]
        public void StatisticsMedianTest()
        {
            int[] source = Statistics.source;
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];

            double expectedValue = dbl;

            double actual = Statistics.Median();

            Assert.Equal(expectedValue, actual);

        }

        [Fact]
        public void StatisticsModeTest()
        {
            int[] source = Statistics.source;

            Array.Sort(source);

            int currentNum = source[0];
            int currentCount = 1;
            int maxCount = 1;
            int expectedValue = currentNum;

            for (int i = 1; i < source.Length; i++)
            {
                if (source[i] == currentNum)
                {
                    currentCount++;
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        expectedValue = currentNum;
                    }
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        expectedValue = currentNum;
                    }
                    currentNum = source[i];
                    currentCount = 1;
                }

            }

            int actualMode = Statistics.Mode();

            Assert.Equal(expectedValue, actualMode);
        }

        [Fact]
        public void StatisticsRangeTest()
        {
            int[] source = Statistics.source;
            Array.Sort(source);
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];
            int range = max - min;

            int expectedValue = range;

            int actualMode = Statistics.Range();

            Assert.Equal(expectedValue, actualMode);

        }

        [Fact]
        public void StatisticsStandardDeviationTest()
        {
            int[] source = Statistics.source;

            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double expectedValue = Math.Round(sd, 1);
            double roundedExpectedValue = Math.Round(expectedValue, 1);

            double actualMode = Statistics.StandardDeviation();

            Assert.Equal(roundedExpectedValue, actualMode);

        }
    }
}