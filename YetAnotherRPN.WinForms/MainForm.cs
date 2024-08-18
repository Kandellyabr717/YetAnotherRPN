namespace YetAnotherRPN.WinForms
{
    public class MainForm : Form
    {
        private Solver _solver;
        private Label _formulaLabel = new()
        {
            Text = "Введите формулу:",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.BottomLeft,
        };
        private Label _equalLabel = new()
        {
            Text = "=",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.TopCenter,
            Font = new Font("Consolas", 13)
        };
        private Label _resultLabel = new()
        {
            Text = "Результат:",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.BottomLeft,
        };
        private Label _exeptionLabel = new()
        {
            Text = "",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.TopLeft,
            ForeColor = Color.Red,
        };
        private TextBox _inputBox = new()
        {
            Dock = DockStyle.Fill,
        };
        private TextBox _resultBox = new()
        {
            ReadOnly = true,
            Dock = DockStyle.Fill,
        };
        private Button _calculateButton = new()
        {
            Text = "Рассчитать",
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleCenter,
        };
        private TableLayoutPanel _table = new()
        {
            Dock = DockStyle.Fill,
        };
        private TableLayoutPanel _topTable = new()
        {
            Dock = DockStyle.Fill,
        };
        private TableLayoutPanel _bottomTable = new()
        {
            Dock = DockStyle.Fill,
        };

        public MainForm(Solver solver)
        {
            Text = "Калькулятор обратной польской записи";
            Icon = Resources.Icon;
            Size = new Size(400, 200);
            FormBorderStyle = FormBorderStyle.FixedDialog;

            InitializeTables();
            AddControls();
            _solver = solver;

            _calculateButton.Click += Calculate;
            _inputBox.KeyDown += EnterHotkey;
        }

        private void Calculate(object? sender, EventArgs args)
        {
            try
            {
                var result = _solver.Solve(_inputBox.Text);
                _resultBox.Text = result.ToString();
                _exeptionLabel.Text = "";
            }
            catch (ArgumentException exeption)
            {
                _exeptionLabel.Text = exeption.Message;
                _resultBox.Text = "";
            }
        }

        private void EnterHotkey(object? sender, KeyEventArgs args)
        {
            if (args.KeyCode == Keys.Enter) Calculate(sender, args);
        }

        private void InitializeTables()
        {
            _table.RowStyles.Clear();
            _table.RowStyles.Add(new RowStyle(SizeType.Percent, 60));
            _table.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            _table.ColumnStyles.Clear();
            _table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            _table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            _table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            _topTable.RowStyles.Clear();
            _topTable.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333333f));
            _topTable.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333333f));
            _topTable.RowStyles.Add(new RowStyle(SizeType.Percent, 33.333333f));
            _topTable.ColumnStyles.Clear();
            _topTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            _topTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            _topTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));

            _bottomTable.RowStyles.Clear();
            _bottomTable.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
            _bottomTable.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
            _bottomTable.ColumnStyles.Clear();
            _bottomTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));
            _bottomTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            _bottomTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90));

            Controls.Add(_table);
        }

        private void AddControls()
        {
            _table.Controls.Add(new Panel(), 0, 0);
            _table.Controls.Add(_topTable, 1, 0);
            _table.Controls.Add(new Panel(), 2, 0);

            _table.Controls.Add(new Panel(), 0, 1);
            _table.Controls.Add(_bottomTable, 1, 1);
            _table.Controls.Add(new Panel(), 2, 1);

            _topTable.Controls.Add(_formulaLabel, 0, 0);
            _topTable.Controls.Add(new Panel(), 1, 0);
            _topTable.Controls.Add(_resultLabel, 2, 0);

            _topTable.Controls.Add(_inputBox, 0, 1);
            _topTable.Controls.Add(_equalLabel, 1, 1);
            _topTable.Controls.Add(_resultBox, 2, 1);

            _topTable.Controls.Add(_exeptionLabel, 0, 2);
            _topTable.Controls.Add(new Panel(), 1, 2);
            _topTable.Controls.Add(new Panel(), 2, 2);

            _bottomTable.Controls.Add(new Panel(), 0, 0);
            _bottomTable.Controls.Add(_calculateButton, 1, 0);
            _bottomTable.Controls.Add(new Panel(), 2, 0);

            _bottomTable.Controls.Add(new Panel(), 0, 1);
            _bottomTable.Controls.Add(new Panel(), 1, 1);
            _bottomTable.Controls.Add(new Panel(), 2, 1);
        }
    }
}
