namespace Aoc2022.Tests;

using Day03;

public class Day03Test : BaseTest<Day03>
{
    public Day03Test()
    {
        Sut = new Day03();
    }

    public class GetRuckSacks : Day03Test
    {
        [Fact]
        public void ShouldGetRuckSacks()
        {
            InputProvider.Setup(x => x.Read())
                .Returns(new[]
                {
                    "ones",
                    "twos"
                });

            IEnumerable<RuckSack> actual = Sut.GetRuckSacks(InputProvider.Object);
            actual.Count().Should().Be(2);
        }

        [Fact]
        public void ShouldSumRuckSacks()
        {

            InputProvider.Setup(x => x.Read())
                .Returns(new[]
                {
                    "vJrwpWtwJgWrhcsFMMfFFhFp",
                    "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                    "PmmdzqPrVvPwwTWBwg",
                    "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                    "ttgJtRGJQctTZtZT",
                    "CrZsJsPPZsGzwwsLwLmpwMDw"
                });

            var actual = Sut.SolveOne(InputProvider.Object);
            actual.Should().Be(157);
        }
        
        [Fact]
        public void ShouldFindBadge()
        {
            InputProvider.Setup(x => x.Read())
                .Returns(new[]
                {
                    "vJrwpWtwJgWrhcsFMMfFFhFp",
                    "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                    "PmmdzqPrVvPwwTWBwg",
                    "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                    "ttgJtRGJQctTZtZT",
                    "CrZsJsPPZsGzwwsLwLmpwMDw"
                });

            var actual = Sut.SolveTwo(InputProvider.Object);
            actual.Should().Be(70);
        }
    }

   
}