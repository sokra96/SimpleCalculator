using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace SimpleCalculator
{
    internal class Calculation
    {
        double _num1;
        double _num2;
        string _operation;
        string _expression;
        double _finalResult;
        double _result;
        DateTime _createdAt;

        public double Num1 { get => _num1; }
        public double Num2 { get => _num2; }
        public string Operation { get => _operation; }
        public double Result { get => _result; }
        public string Expression { get => _expression; }
        public double FinalResult { get => _finalResult; }
        public DateTime CreatedAt { get => _createdAt; }

        public void Initialize(double num1, double num2, string operation)
        {
            _num1 = num1;
            _num2 = num2;

            if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
            {
                throw new ArgumentException("Invalid operation! Must be +, -, * or /");
            }
            _operation = operation;
            if (_operation == "/" && _num2 == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed");
            }
        }
        public void PerformCalculation()
        {
            switch (_operation)
            {
                case "+": _result = _num1 + _num2; break;
                case "-": _result = _num1 - _num2; break;
                case "*": _result = _num1 * _num2; break;
                case "/": _result = _num1 / _num2; break;

            }
            _createdAt = DateTime.Now;
        }

        public double PerformCalculation(double num1, double num2, string operation)
        {
            Initialize(num1, num2, operation);
            PerformCalculation();
            return _result;
        }


        public void SetFinalResult(string expression, double finalResult)
        {
            _expression = expression;
            _finalResult = finalResult;
            _createdAt = DateTime.Now;
        }
    }
}
