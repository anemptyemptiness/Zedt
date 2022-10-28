using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace zed
{
    public partial class Form1 : Form

    {
        //Global errors 
        static double yEiler;
        static double yEilerModified;
        static double yEilerKoshiDefault;
        static double yEilerKoshidx1;
        static double yEilerKoshidx2;
        static double yEilerKoshidx3;
        static double yEilerKoshidx4;

        //Global counts
        static int eilerKoshiErrorDx;
        static int eilerkoshiErrorDx1;
        static int eilerkoshiErrorDx2;
        static int eilerkoshiErrorDx3;
        static int eilerkoshiErrorDx4;
        public Form1()
        {
            InitializeComponent();
            DrawGraph();
            //DrawBarError();
            //DrawBarCount();
        }

        public void DrawGraph()
        {
            // создание панели
            GraphPane myPane = zedGraphControl1.GraphPane;

            // очищаем на панели всё, что на ней осталось
            myPane.CurveList.Clear();

            // лист точек
            PointPairList listEiler = new PointPairList();
            PointPairList listEilerModified = new PointPairList();
            PointPairList listEilerKoshiDx = new PointPairList();
            PointPairList listEilerKoshiDx1 = new PointPairList();
            PointPairList listEilerKoshiDx2 = new PointPairList();
            PointPairList listEilerKoshiDx3 = new PointPairList();
            PointPairList listEilerKoshiDx4 = new PointPairList();

            // меняем название осей и заголовка графика
            myPane.XAxis.Title.Text = "Ось Х";
            myPane.YAxis.Title.Text = "Ось Y";
            myPane.Title.Text = "График зависимостей y=y(x)";
            myPane.Title.FontSpec.IsBold = true;

            // Э-метод
            double x, y, k1, xk = 5.1;
            double x0 = 4.5, y0 = 1.1;
            double dx = 0.05;

            int count = 0;

            for (double i = x0; i < xk; i += dx)
            {
                x = x0 + dx;
                k1 = dx * Function(x0, y0);
                y = y0 + k1;
                x0 = x;
                y0 = y;
                listEiler.Add(x0, y0);
                count++;

                if (count == 12)
                {
                    yEiler = y0;
                }
            }

            //ЭМ-метод

            double k2; k1 = 1;
            x0 = 4.5; y0 = 1.1;
            dx = 0.05;

            count = 0;

            for (double i = x0; i < xk; i += dx)
            {
                x = x0 + dx;
                k1 = (dx / 2) * Function(x0, y0);
                k2 = dx * Function(x0 + dx / 2, y0 + k1);
                y = y0 + k2;
                x0 = x;
                y0 = y;
                listEilerModified.Add(x0, y0);
                count++;

                if (count == 12)
                {
                    yEilerModified = y0;
                }
            }

            //ЭК-метод dx

            x0 = 4.5; y0 = 1.1; k1 = 1; k2 = 2;

            dx = 0.05;
            double dx1 = dx / 2;
            double dx2 = dx / 4;
            double dx3 = dx / 6;
            double dx4 = dx / 8;

            count = 0;

            for (double i = x0; i < xk; i += dx)
            {
                x = x0 + dx;
                k1 = dx * Function(x0, y0);
                k2 = dx * Function(x0 + dx, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                x0 = x;
                y0 = y;
                listEilerKoshiDx.Add(x0, y0);
                count++;

                if (count == 12)
                {
                    yEilerKoshiDefault = y0;
                    eilerKoshiErrorDx = count;
                }
            }

            //ЭК-метод dx1

            x0 = 4.5; y0 = 1.1; count = 0; k1 = 1; k2 = 1;

            for (double i = x0; i < xk + dx1; i += dx1)
            {
                x = x0 + dx1;
                k1 = dx1 * Function(x0, y0);
                k2 = dx1 * Function(x0 + dx1, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                x0 = x;
                y0 = y;
                listEilerKoshiDx1.Add(x0, y0);
                count++;

                if (count == 24)
                {
                    yEilerKoshidx1 = y0;
                    eilerkoshiErrorDx1 = count;
                }
            }

            //ЭК-метод dx2

            x0 = 4.5; y0 = 1.1; count = 0; k1 = 1; k2 = 1;
            for (double i = x0; i < xk + dx2; i += dx2)
            {
                x = x0 + dx2;
                k1 = dx2 * Function(x0, y0);
                k2 = dx2 * Function(x0 + dx2, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                x0 = x;
                y0 = y;
                listEilerKoshiDx2.Add(x0, y0);
                count++;

                if (count == 48)
                {
                    yEilerKoshidx2 = y0;
                    eilerkoshiErrorDx2 = count;
                }
            }

            //ЭК-метод dx3

            x0 = 4.5; y0 = 1.1; count = 0; k1 = 1; k2 = 1;
            for (double i = x0; i < xk; i += Math.Round(dx3, 4))
            {
                x = x0 + Math.Round(dx3, 4);
                k1 = Math.Round(dx3, 4) * Function(x0, y0);
                k2 = Math.Round(dx3, 4) * Function(x0 + Math.Round(dx3, 4), y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                x0 = x;
                y0 = y;
                listEilerKoshiDx3.Add(x0, y0);
                count++;

                if (count == 72)
                {
                    yEilerKoshidx3 = y0;
                    eilerkoshiErrorDx3 = count;
                }
            }

            //ЭК-метод dx4

            x0 = 4.5; y0 = 1.1; count = 0; k1 = 1; k2 = 1;
            for (double i = x0; i < xk; i += dx4)
            {
                x = x0 + dx4;
                k1 = dx4 * Function(x0, y0);
                k2 = dx4 * Function(x0 + dx4, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                x0 = x;
                y0 = y;
                listEilerKoshiDx4.Add(x0, y0);
                count++;

                if (count == 96)
                {
                    yEilerKoshidx4 = y0;
                    eilerkoshiErrorDx4 = count;
                }
            }

            // Подпись графика функции
            LineItem myCurve1 = myPane.AddCurve("Э", listEiler, Color.Blue, SymbolType.None);
            LineItem myCurve2 = myPane.AddCurve("ЭМ", listEilerModified, Color.Red, SymbolType.None);
            LineItem myCurve3 = myPane.AddCurve("ЭК(dx = 0.05)", listEilerKoshiDx, Color.Green, SymbolType.None);
            LineItem myCurve4 = myPane.AddCurve("ЭК(dx = 0.025)", listEilerKoshiDx1, Color.Green, SymbolType.None);
            LineItem myCurve5 = myPane.AddCurve("ЭК(dx = 0.0125)", listEilerKoshiDx2, Color.Yellow, SymbolType.None);
            LineItem myCurve6 = myPane.AddCurve("ЭК(dx = 0.0083)", listEilerKoshiDx3, Color.Violet, SymbolType.None);
            LineItem myCurve7 = myPane.AddCurve("ЭК(dx = 0.00625)", listEilerKoshiDx4, Color.Black, SymbolType.None);

            // Обновление данных об осях
            zedGraphControl1.AxisChange();

            // обновление графика
            zedGraphControl1.Invalidate();
        }

        static public double Function(double x, double y)
        {
            double a0 = 0.480, a1 = -0.335, a2 = -0.301, a3 = -0.337, a4 = -0.040;

            return a0 + a1 * x + a2 * Math.Pow(x, 2) + a3 * y + a4 * x * y;
        }

        static public double Error(double a, double b)
        {
            return Math.Abs(a - b);
        }

    }
}
