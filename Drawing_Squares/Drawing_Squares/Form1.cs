using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_Squares
{
    public partial class Form1 : Form
    {

        Rectangle rect;

        Point LocationXY; // Start
        Point LocationX1Y1; // End

        Random random = new Random();

        bool IsMouseDown = false;

        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size dimension = new Size(400, 400);
            this.ClientSize = dimension;
            ResizeRedraw = true;
            BackColor = Color.Black;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            LocationXY = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;

                Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;

                IsMouseDown = false;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var color = getRandomColor();
            var width = getWidth();
            
            Pen pen = new Pen(color,width);

            if (rect != null)
            {
                e.Graphics.DrawRectangle(pen, GetRect());
            }
        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();
            rect.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            rect.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
            rect.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            rect.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);
            return rect;
        }

        private Color getRandomColor()
        { 
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private int getWidth()
        {
            return random.Next(8);
        }
    }
}

