using System;
using System.IO;
using GreetingKata;
using Xunit;
using Xunit.Abstractions;

namespace GreetingKataTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("Bob", "Hello, Bob")]
        [InlineData("Banana", "Hello, Banana")]
        public void Basic_Greeting(string name, string greeting)
        {
            var value = Greeting.Greet(name); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData(null, "Hello, my friend")]
        public void Null_Greeting(string name, string greeting)
        {
            var value = Greeting.Greet(name); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData("BOB", "HELLO BOB!")]
        public void Shout_Greeting(string name, string greeting)
        {
            var value = Greeting.Greet(name); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData("bOb", "Hello, bOb")]
        public void Dont_Shout_OnlyOneCaps_Greeting(string name, string greeting)
        {
            var value = Greeting.Greet(name); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData("Jill", "Jane", "Bob", "Hello, Jill, Jane and Bob.")]
        public void List_Greeting(string name1, string name2, string name3, string greeting)
        {
            var value = Greeting.Greet(name1, name2, name3); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData("Jill", "JANE", "Bob", "Hello, Jill and Bob. AND HELLO JANE!")]
        public void List_Greeting_Shout(string name1, string name2, string name3, string greeting)
        {
            var value = Greeting.Greet(name1, name2, name3); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData("Jill,Jane", "Bob", "Hello, Jill, Jane and Bob.")]
        [InlineData("Jill,JANE", "Bob", "Hello, Jill and Bob. AND HELLO JANE!")]
        public void List_Split_Input(string name1, string name2, string greeting)
        {
            var value = Greeting.Greet(name1, name2); 
            Assert.True(greeting.Equals(value));
        }
        
        [Theory]
        [InlineData("Jill", "\"Jane, Bob\"", "Hello, Jill and Jane, Bob.")]
        [InlineData("JILL", "\"Jane, Bob\"", "Hello, Jane, Bob. AND HELLO JILL!")]
        public void List_Escape_Input(string name1, string name2, string greeting)
        {
            var value = Greeting.Greet(name1, name2); 
            Assert.True(greeting.Equals(value));
        }
    }
}