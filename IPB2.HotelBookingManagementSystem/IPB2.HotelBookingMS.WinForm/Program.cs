using System;
using System.Windows.Forms;

namespace IPB2.HotelBookingMS.WinForm;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new FrmRoom());
    }
}
