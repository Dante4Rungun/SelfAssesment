using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SelfAssessment
{
    public partial class CircleDiagram : Form
    {
        
        public CircleDiagram()
        {
            InitializeComponent();
            pictureBox1.Invalidate();
        }


        List<Point> points = new List<Point>();
        Point center;
        private void CircleDiagram_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1080, 613);
            this.MaximumSize = new Size(1080, 613);
            label16.Text = $"{Convert.ToString(Program.competenceResults[0])}%";
            label17.Text = $"{Convert.ToString(Program.competenceResults[1])}%";
            label18.Text = $"{Convert.ToString(Program.competenceResults[2])}%";
            label19.Text = $"{Convert.ToString(Program.competenceResults[3])}%";
            label20.Text = $"{Convert.ToString(Program.competenceResults[4])}%";
            label21.Text = $"{Convert.ToString(Program.competenceResults[5])}%";
            label22.Text = $"{Convert.ToString(Program.competenceResults[6])}%";
            label23.Text = $"{Convert.ToString(Program.competenceResults[7])}%";
            label24.Text = $"{Convert.ToString(Program.competenceResults[8])}%";
            label25.Text = $"{Convert.ToString(Program.competenceResults[9])}%";
            label26.Text = $"{Convert.ToString(Program.competenceResults[10])}%";
            label27.Text = $"{Convert.ToString(Program.competenceResults[11])}%";
            label28.Text = $"{Convert.ToString(Program.competenceResults[12])}%";
            label29.Text = $"{Convert.ToString(Program.competenceResults[13])}%";
            label30.Text = $"{Convert.ToString(Program.competenceResults[14])}%";
            //InvokeOnClick(button1, EventArgs.Empty);

        }

        private void TakePoints()
        {
            points.Clear();
            int count = 15;  //текстбокс "Количество вершин"
            int length = 120;//текстбокс "Длина стороны"
            double R = length / (2 * Math.Sin(Math.PI / count)); //Радиус описанной окружности
            for (double angle = 0.0; angle <= 2 * Math.PI; angle += 2 * Math.PI / count) //цикл по углу
            {
                int x = (int)(R * Math.Cos(angle)); //расчет координаты x точки
                int y = (int)(R * Math.Sin(angle)); //расчет координаты y точки
                points.Add(new Point((int)R + x + 20, (int)R + y)); //добавление точки в список точек
            }
            
            //this.Invalidate(); //Команда перерисовать форму
        }

        private void CircleCenter()
        {
            int x1 = points[0].X;
            int y1 = points[0].Y;
            int x2 = points[1].X;
            int y2 = points[1].Y;
            int x3 = points[2].X;
            int y3 = points[2].Y;

            int A = x2 - x1;
            int B = y2 - y1;
            int C = x3 - x1;
            int D = y3 - y1;

            int E = A * (x1 + x2) + B * (y1 + y2);
            int F = C * (x1 + x3) + D * (y1 + y3);
            int G = 2 * (A * (y3 - y2) - B * (x3 - x2));

            int Cx = (D * E - B * F) / G;
            int Cy = (A * F - C * E) / G;
            Point coordsCenter = new Point(Cx,Cy);
            center = coordsCenter;
        }

        private List<int> coord50(int x1, int y1, int x2, int y2, double cmpResult)
        {
            List<int> crd25 = new List<int> { };
            int x50 = (x1 + x2) / 2;
            int y50 = (y1 + y2) / 2;

            int x25 = (x1 + x50) / 2;
            int y25 = (y1 + y50) / 2;

            int x025 = (x1 + x25) / 2;
            int y025 = (y1 + y25) / 2;

            int x2550 = (x25 + x50) / 2;
            int y2550 = (y25 + y50) / 2;

            int x75 = (x50 + x2) / 2;
            int y75 = (y50 + y2) / 2;

            int x5075 = (x50 + x75) / 2;
            int y5075 = (y50 + y75 ) / 2;

            int x75100 = (x75 + x2) / 2;
            int y75100 = (y75 + y2) / 2;

            if (cmpResult == 0)
            {
                crd25.Add(x1);
                crd25.Add(y1);
            }
            else if (cmpResult >=0 && cmpResult <= 12.5)
            {
                crd25.Add(x025);
                crd25.Add(y025);
            }
            else if (cmpResult <= 25 && cmpResult >= 12.5)
            {
                crd25.Add(x25);
                crd25.Add(y25);
            }
            else if (cmpResult > 25 && cmpResult <= 37.5)
            {
                crd25.Add(x2550);
                crd25.Add(y2550);
            }
            else if (cmpResult > 37.5 && cmpResult <= 50)
            {
                crd25.Add(x50);
                crd25.Add(y50);
            }
            else if (cmpResult > 50 && cmpResult <= 62.5)
            {
                crd25.Add(x75);
                crd25.Add(y75);
            }
            else if (cmpResult > 50 && cmpResult <= 75)
            {
                crd25.Add(x75);
                crd25.Add(y75);
            }
            else if (cmpResult > 75)
            {
                crd25.Add(x2);
                crd25.Add(y2);
            }

            return crd25;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 1.7F;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            SolidBrush backCircle = new SolidBrush(Color.White);
            Graphics g = pictureBox1.CreateGraphics();
            SolidBrush myCorp1 = new SolidBrush(Color.Brown);
            SolidBrush myCorp2 = new SolidBrush(Color.DarkOrange);
            SolidBrush myCorp3 = new SolidBrush(Color.Orange);
            //first
            SolidBrush myCorp4 = new SolidBrush(Color.Red);
            SolidBrush myCorp5 = new SolidBrush(Color.Tomato);
            SolidBrush myCorp6 = new SolidBrush(Color.Coral);
            //second
            SolidBrush myCorp7 = new SolidBrush(Color.Maroon);
            SolidBrush myCorp8 = new SolidBrush(Color.MediumVioletRed);
            SolidBrush myCorp9 = new SolidBrush(Color.Orchid);
            //third
            SolidBrush myCorp10 = new SolidBrush(Color.RoyalBlue);
            SolidBrush myCorp11 = new SolidBrush(Color.SteelBlue);
            SolidBrush myCorp12 = new SolidBrush(Color.PaleTurquoise);
            //fourth
            SolidBrush myCorp13 = new SolidBrush(Color.DarkGreen);
            SolidBrush myCorp14 = new SolidBrush(Color.LimeGreen);
            SolidBrush myCorp15 = new SolidBrush(Color.Aquamarine);

            List<SolidBrush> myBrushes = new List<SolidBrush> { myCorp1, myCorp2, myCorp3, myCorp4, myCorp5, myCorp6, myCorp7, myCorp8, myCorp9, myCorp10, myCorp11, myCorp12, myCorp13, myCorp14, myCorp15 };
            TakePoints();
            CircleCenter();

            for (int i = 0; i < 15; i++)
            {
                g.FillPolygon(backCircle, new Point[] {
                new Point(center.X,center.Y),new Point(points[i].X,points[i].Y),
                new Point(points[i+1].X,points[i+1].Y),new Point(center.X,center.Y)
                });
                g.DrawLine(pen, points[i], points[i + 1]);
                g.DrawLine(pen, center, points[i]);

            }
            for (int i = 0; i < 15; i++)
            {
                g.FillPolygon(myBrushes[i], new Point[] {
                new Point(center.X,center.Y),new Point(coord50(center.X,center.Y,points[i].X,points[i].Y,Program.competenceResults[i])[0],coord50(center.X,center.Y,points[i].X,points[i].Y,Program.competenceResults[i])[1]),
                new Point(coord50(center.X,center.Y,points[i+1].X,points[i+1].Y,Program.competenceResults[i])[0],coord50(center.X,center.Y,points[i+1].X,points[i+1].Y,Program.competenceResults[i])[1]),new Point(center.X,center.Y)
                });
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CircleDiagram_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //base.OnPaint(e);
 
            //this.Invalidate();
        }
    }
}
