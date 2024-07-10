namespace YetAnotherRPN
{
    public class Solver
    {
        private Dictionary<string, Func<float, float, float>> _operations = new()
        {
            {"+", (x, y) => x + y},
            {"-", (x, y) => x - y},
            {"*", (x, y) => x * y},
            {"/", (x, y) => x / y},
        };
        private Stack<float> _stack = new();

        public float Solve(string expression)
        {
            var parsed = Parse(expression);
            _stack = new();
            foreach (var operand in parsed)
            {
                if (_stack.Count < 2) _stack.Push(int.Parse(operand));
                else if (_stack.Count == 2)
                {
                    var second = _stack.Pop();
                    var first = _stack.Pop();
                    float result;
                    try
                    {
                        result = _operations[operand](first, second);
                    }
                    catch
                    {
                        throw new ArgumentException("Не валидное выражение");
                    }
                    _stack.Push(result);
                }
            }
            if (_stack.Count != 1) throw new ArgumentException("Не валидное выражение");
            return _stack.Pop();
        }

        public List<string> Parse(string expression)
        {
            var result = new List<string>();
            var number = new List<char>();
            foreach(var chr in expression)
            {
                if (char.IsDigit(chr)) number.Add(chr);
                else if (char.IsWhiteSpace(chr)) AddNumber();
                else if (_operations.ContainsKey(chr.ToString()))
                {
                    AddNumber();
                    result.Add(chr.ToString());
                }
                else throw new ArgumentException($"Неизвестный символ: {chr}");
            }
            AddNumber();
            return result;

            void AddNumber()
            {
                if (number.Count == 0) return;
                result.Add(int.Parse(number.ToArray()).ToString());
                number = new();
            }
        }
    }
}
