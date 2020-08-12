using System;
using System.Collections;
using System.Linq;
using MarkovChainTextGenerator;
using Xunit;

namespace TestMarkovChain
{
    public class ManagerTest
    {
        [Fact]
        public void ManagerStatesNotNull()
        {
            var manager = Manager.CreateInstance("");
            Assert.NotNull(manager);
            Assert.NotNull(manager.States);
        }
        
        [Theory]
        [InlineData("S")]
        public void ManagerAddState(string key)
        {
            var manager = Manager.CreateInstance("");
            manager.AddState(key);
            Assert.NotEmpty(manager.States);
        }
        
        [Theory]
        [InlineData("S", "G", 1)]
        public void ManagerAddStateAttachConnection(string state, string connection, int occurrence)
        {
            var manager = Manager.CreateInstance("");
            manager
                .AddState(state)
                .Attach(connection, occurrence);
            var output = manager.GenerateOutput(state);
            Assert.Equal(connection, output);
        }

        [Theory]
        [InlineData("This is some input text")]
        public void MangerAddText(string input)
        {
            var manager = Manager.CreateInstance(input);
            var text = manager.GetText();
            Assert.Equal(input, text);
        }
        
        [Theory]
        [InlineData("ABC", 3)]
        [InlineData("STATE", 4)]
        public void MangerVerifyStateNumber(string input, int states)
        {
            var manager = Manager.CreateInstance(input);
           // Assert.Equal(states, manager.States.Count);
        }
        
        
        [Theory]
        [InlineData("S", "G", 1)]
        public void ManagerGenerateOutputBased(string state, string connection, int occurrence)
        {
            var manager = Manager.CreateInstance("");
            manager
                .AddState(state)
                .Attach(connection, occurrence);
            var output = manager.GenerateOutput(state);
            Assert.Equal(connection, output);
        }
    }
}