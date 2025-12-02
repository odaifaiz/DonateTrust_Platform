using SPF.Data;
using System;
using System.Windows.Forms;
using System.Linq;
using SPF.Model;


namespace SPF.App  // أو حسب اسم النيم سبيس عندك
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {



            

            // هنا نضمن أن EF يشيّك على قاعدة البيانات وينشئها لو غير موجودة
            using (var ctx = new SpfContext())
            {
                ctx.Database.Initialize(false);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form0()); // أو فورم البداية عندك
        }
    }
}

