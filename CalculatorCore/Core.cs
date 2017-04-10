using System;

namespace SimpleCalculator.Core {
    public interface ICalculator {
        String Calculate(String input);
    }

    public interface IOperation {
        int Operate(int left, int right);
    }

    public interface IOperationData {
        Char Symbol { get; }
    }
}
