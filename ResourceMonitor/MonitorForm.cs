using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;
using System.IO;

namespace ResourceMonitor
{
    public partial class MonitorForm : Form
    {
        public MonitorForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            ReadConfig();

            trd = new Thread(new ThreadStart(TrdTask));
            trd.Start();

            rect = new Rectangle(0, 0, this.Width, this.Height);
            formPath = GetRoundedRectPath(rect, 16);
            Region = new Region(formPath);

            StartPosition = FormStartPosition.Manual;
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width - 10, 10);

            if (clickThrough)
            {
                SetWindowLong(Handle, -20, 0x20 | 0x80000);
                SetLayeredWindowAttributes(Handle, 0, 100, 0);
            }

            if (!alwaysOnTop)
            {
                TopMost = false;
            }
        }

        private void MonitorForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x0112, 0xF012, 0);
        }

        private void ReadConfig()
        {
            using (StreamReader reader = new StreamReader("ResourceMonitor.txt"))
            {
                alwaysOnTop = reader.ReadLine() == "true";
                clickThrough = reader.ReadLine() == "true";
            }
        }

        private void TrdTask()
        {
            while (true)
            {
                MemoryLabel.Text = "Memory: " + memoryUsage.NextValue().ToString("0.00") + "%";
                CpuLabel.Text = "CPU: " + cpuUsage.NextValue().ToString("0.00") + "%";
                Thread.Sleep(1000);
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        Thread trd;
        GraphicsPath formPath;
        Rectangle rect;

        bool alwaysOnTop, clickThrough;

        public PerformanceCounter memoryUsage = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        public PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32", EntryPoint = "SetWindowLong")]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);
    }
}
