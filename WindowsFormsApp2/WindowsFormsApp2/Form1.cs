using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsInput.Native;
using WindowsInput;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public string getLine()
        {
            var lines = File.ReadAllLines("words.txt");
            var r = new Random();
            var randomLineNumber = r.Next(0, lines.Length - 1);
            var line = lines[randomLineNumber];
            return line;
        }
       
            InputSimulator sim = new InputSimulator();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goToTextBox();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void goToTextBox()
        {

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(2326, 652);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 2326, 652, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 2326, 652, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 2326, 652, 0, 0);
            sim.Keyboard.TextEntry(getLine());
            enterSubmission();
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
        public void enterSubmission()
        {
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);

            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);

            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);

            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            /*

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(2258, 772);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 2258 ,772, 0, 0);

            DateTime _desired = DateTime.Now.AddSeconds(5);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            goBack();
            */
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }
        public void goBack()
        {

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(1944 ,196);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 1944, 196, 0, 0);

            DateTime _desired = DateTime.Now.AddSeconds(2);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
            goToTextBox();
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

    }


}
