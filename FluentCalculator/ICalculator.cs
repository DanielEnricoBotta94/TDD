namespace FluentCalculator
{
    public interface IBase
    {
        int Result();
    }

    public interface IOperation
    {
        IPlus Plus(int plus);
        IMinus Minus(int minus);
        ISave Save();
    }

    public interface IControl
    {
        IUndo Undo();
    }

    public interface ISeed : IOperation, IBase { }

    public interface IPlus : IControl, IOperation, IBase{ }

    public interface IMinus : IControl, IOperation, IBase { }
    
    public interface ISave : IOperation, IBase { }

    public interface IUndo : IControl, IOperation, IBase
    {
        IRedo Redo();
    }

    public interface IRedo : IUndo { }
}