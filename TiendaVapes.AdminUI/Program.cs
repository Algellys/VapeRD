using System;
using System.Windows.Forms;

namespace TiendaVapes.AdminUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                LoginForm login = new LoginForm();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    MainForm main = new MainForm();
                    Application.Run(main);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
