using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Inventory_Management
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new add_new_user());
            //Application.Run(new unit());
            // Application.Run(new add_product_name());
            //Application.Run(new dealer_info());
            Application.Run(new purchase_master());
            //Application.Run(new Login());
        }
    }
}
