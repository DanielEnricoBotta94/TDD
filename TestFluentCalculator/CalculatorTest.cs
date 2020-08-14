using System;
using FluentCalculator;
using Xunit;

namespace TestFluentCalculator
{
    public class CalculatorTest1
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(1000)]
        [InlineData(999999)]
        public void Seed(int seed)
        {
            var output = new Calculator()
                .Seed(seed)
                .Result();
            Assert.Equal(seed, output);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(100, 150, 250)]
        [InlineData(123, 345, 468)]
        public void Plus(int seed, int plus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Plus(plus)
                .Result();
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 2, 0)]
        [InlineData(100, 150, -50)]
        [InlineData(123, 345, -222)]
        public void Minus(int seed, int minus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Minus(minus)
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(100, 150, 100)]
        [InlineData(123, 345, 123)]
        public void UndoPlus(int seed, int plus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Minus(plus)
                .Undo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(100, 150, 100)]
        [InlineData(123, 345, 123)]
        public void UndoMinus(int seed, int minus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Minus(minus)
                .Undo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(100, 150, 100)]
        [InlineData(123, 345, 123)]
        public void MultipleUndo(int seed, int minus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Minus(minus)
                .Minus(minus)
                .Undo()
                .Undo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1)]
        public void MoreUndoThanOperations(int expected)
        {
            var output = new Calculator()
                .Seed(expected)
                .Minus(expected)
                .Undo()
                .Undo()
                .Undo()
                .Undo()
                .Undo()
                .Undo()
                .Undo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(100, 150, 250)]
        [InlineData(123, 345, 468)]
        public void RedoPlus(int seed, int plus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Plus(plus)
                .Undo()
                .Redo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        
        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 2, 0)]
        [InlineData(100, 150, -50)]
        [InlineData(123, 345, -222)]
        public void RedoMinus(int seed, int plus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Minus(plus)
                .Undo()
                .Redo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(100, 150, 250)]
        [InlineData(123, 345, 468)]
        public void MoreRedoThanUndo(int seed, int plus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Plus(plus)
                .Undo()
                .Redo()
                .Redo()
                .Redo()
                .Redo()
                .Redo()
                .Redo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(100, 150, 250)]
        [InlineData(123, 345, 468)]
        public void Save(int seed, int plus, int expected)
        {
            var output = new Calculator()
                .Seed(seed)
                .Plus(plus)
                .Save()
                .Plus(plus)
                .Undo()
                .Undo()
                .Undo()
                .Undo()
                .Result();
            Assert.Equal(expected, output);
        }
        
        [Fact]
        public void FinalTest()
        {
            var output = new Calculator()
                .Seed(10)
                .Plus(5)
                .Minus(2)
                .Save() // -> 13
                .Plus(5)
                .Undo()
                .Redo()
                .Undo()
                .Redo()
                .Result(); // -> result = 18

            Assert.Equal(18, output);
        }
    }
}