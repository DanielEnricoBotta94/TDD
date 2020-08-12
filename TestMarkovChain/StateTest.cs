using System;
using System.Linq;
using MarkovChainTextGenerator;
using Xunit;

namespace TestMarkovChain
{
    public class StateTest
    {
        [Fact]
        public void StateCreation()
        {
            const string expectedStateValue = "L";
            var state = State.CreateInstance("L");
            Assert.Equal(expectedStateValue, state.Key);
        }
        
        [Theory]
        [InlineData(5)]
        [InlineData(8)]
        public void AttachStateKey(int occurrence)
        {
            var state = State.CreateInstance("L");
            state.Attach("A", occurrence);
            Assert.Equal(occurrence, state.GetConnections().First().Value);
        }
        
        [Theory]
        [InlineData(1,2, 3)]
        [InlineData(2,4, 6)]
        public void UpdateOccurence(int occurrence, int updatedOccurence, int expected)
        {
            var state = State.CreateInstance("L");
            state.Attach("A", occurrence);
            state.Attach("A", updatedOccurence);
            Assert.Equal(expected, state.GetConnections().First().Value);
        }
        
        [Theory]
        [InlineData(2, 3)]
        [InlineData(1000, 1001)]
        public void IncreaseOccurence(int occurrence, int expected)
        {
            var state = State.CreateInstance("L");
            state.Attach("A", occurrence);
            state.AddOccurrence("A");
            Assert.Equal(expected, state.GetConnections().First().Value);
        }
        
        [Theory]
        [InlineData(5)]
        [InlineData(8)]
        public void GetMarkovConnection(int occurrence)
        {
            var state = State.CreateInstance("L");
            state.Attach("A", occurrence);
            state.Attach("B", occurrence);
            var output = state.GenerateMarkovOutput();
            Assert.True(output.Equals("A") || output.Equals("B"));
        }
    }
}