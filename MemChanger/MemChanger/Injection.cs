using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemChanger;
using Memory;
//string by james
namespace MemChanger
{
    public partial class Injection : Form
    {
        public Injection()
        {
            InitializeComponent();
        }
        Mem pnlmem = new Mem();
        private object name;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void aasxx();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
             int nHeightEllipse
         );
        private void Injection_Load(object sender, EventArgs e)
        {

        }

        private async void siticoneButton1_Click(object sender, EventArgs e)
        {
            label1.Text = "Injecting your Function!";
            int pnllist = pnlmem.GetProcIdFromName("HD-Player.exe");
            if (pnllist > 0)
            {
                pnlmem.OpenProcess(pnllist);
                IEnumerable<long> AoBScanResults = await pnlmem.AoBScan(0L, 140737488355327L, s.Text, true, true);
                if (AoBScanResults.Count() == 0)
                {
                }
                else if (AoBScanResults.Count() > 0)
                {
                    for (int i = 0; i < AoBScanResults.Count(); i++)
                        pnlmem.WriteMemory(AoBScanResults.ElementAt(i).ToString("X"), "bytes", r.Text, "", (Encoding)null);
                    label1.Text = "Injected!";
                }
            }
        }
    }
}
//string by james