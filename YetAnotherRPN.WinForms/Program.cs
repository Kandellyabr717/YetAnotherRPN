namespace YetAnotherRPN.WinForms
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(new Solver()));
        }
    }
}
