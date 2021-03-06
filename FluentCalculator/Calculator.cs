﻿using System.Collections.Generic;
using System.Linq;

namespace FluentCalculator
{
    public class Calculator : ISeed, IPlus, IMinus, IRedo, ISave
    {
        private int Value { get; set; }
        private Stack<int> Stack { get; } = new Stack<int>();
        private Stack<int> RedoStack { get; } = new Stack<int>();

        public ISeed Seed(int seed)
        {
            Value = seed;
            return this;
        }

        IPlus IOperation.Plus(int plus)
        {
            Stack.Push(plus);
            return this;
        }

        IMinus IOperation.Minus(int minus)
        {
            Stack.Push(-minus);
            return this;
        }

        IUndo IControl.Undo()
        {
            if (!Stack.Any())
                return this;
            RedoStack.Push(Stack.Pop());
            return this;
        }

        IRedo IUndo.Redo()
        {
            if (!RedoStack.Any())
                return this;
            Stack.Push(RedoStack.Pop());
            return this;
        }

        ISave IOperation.Save()
        {
            ((IBase)this).Result();
            return this;
        }

        int IBase.Result()
        {
            Value += Stack.Sum();
            Stack.Clear();
            RedoStack.Clear();
            return Value;
        }
    }
}