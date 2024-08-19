using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace scadatest
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Tạo các đối tượng của Form1 và Form2
            Main form1 = new Main();
            //Login form2 = new Login();

            // Hiển thị cả hai form
            form1.Show();
            using (Login form2 = new Login())
            {
                // Hiển thị Form2 như một hộp thoại
                form2.ShowDialog();
            }
            

            Application.Run(form1); // Hoặc Application.Run(form2);
  

        }
        //private static bool RunningAsAdmin()
        //{
        //    WindowsIdentity id = WindowsIdentity.GetCurrent();
        //    WindowsPrincipal principal = new WindowsPrincipal(id);

        //    return principal.IsInRole(WindowsBuiltInRole.Administrator);
        //}

    }
}
