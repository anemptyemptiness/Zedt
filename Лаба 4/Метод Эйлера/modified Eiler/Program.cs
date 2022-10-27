using System;

namespace modified_Eiler
{
    class Program
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

        static void Main()
        {
            Eiler();
            ModifiedEiler();
            EilerKoshi();
            Console.WriteLine($"\nErrors:\nError for Eiler method: {Error(yEilerKoshiDefault, yEiler)}");
            Console.WriteLine($"Error for Eiler Modified method: {Error(yEilerKoshiDefault, yEilerModified)}");
            Console.WriteLine($"Error for Eiler-Koshi method(dx to dx4): {Error(yEilerKoshiDefault, yEilerKoshidx4)}");
            Console.WriteLine($"\nEiler-Koshi errors for different dx's:\nError for Eiler-Koshi method(dx to dx1): {Error(yEilerKoshiDefault, yEilerKoshidx1)}");
            Console.WriteLine($"Error for Eiler-Koshi method(dx to dx2): {Error(yEilerKoshiDefault, yEilerKoshidx2)}");
            Console.WriteLine($"Error for Eiler-Koshi method(dx to dx3): {Error(yEilerKoshiDefault, yEilerKoshidx3)}");
        }

        static public double Function(double x, double y)
        {
            double a0 = 0.480, a1 = -0.335, a2 = -0.301, a3 = -0.337, a4 = -0.040;

            return a0 + a1 * x + a2 * Math.Pow(x, 2) + a3 * y + a4 * x * y;
        }

        static public void ModifiedEiler()
        {

            double x, y, k1, k2, xk = 5.1;
            double x0 = 4.5, y0 = 1.1;
            double dx = 0.05;

            int count = 0;

            Console.WriteLine("\nmethod Eiler Modified:");
            for (double i = x0; i < xk; i += dx)
            {
                x = x0 + dx;
                k1 = (dx / 2) * Function(x0, y0);
                k2 = dx * Function(x0 + dx / 2, y0 + k1);
                y = y0 + k2;
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 2)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 12)
                {
                    yEilerModified = y0;
                }
            }
        }

        static public void Eiler()
        {
            double x, y, k1, xk = 5.1;
            double x0 = 4.5, y0 = 1.1;
            double dx = 0.05;
            
            int count = 0;
            
            Console.WriteLine("method Eiler:");
            for (double i = x0; i < xk; i += dx)
            {
                x = x0 + dx;
                k1 = dx * Function(x0, y0);
                y = y0 + k1;
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 2)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 12)
                {
                    yEiler = y0;
                }
            }
        }

        static public void EilerKoshi()
        {
            double x, y, k1, k2;
            double x0 = 4.5, y0 = 1.1, xk = 5.1;

            double dx = 0.05;
            double dx1 = dx / 2;
            double dx2 = dx / 4;
            double dx3 = dx / 6;
            double dx4 = dx / 8;

            int count = 0;

            Console.WriteLine($"\nmethod Eiler-Koshi for dx = {dx}:");
            for (double i = x0; i < xk; i += dx)
            {
                x = x0 + dx;
                k1 = dx * Function(x0, y0);
                k2 = dx * Function(x0 + dx, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 2)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 12)
                {
                    yEilerKoshiDefault = y0;
                }
            }

            Console.WriteLine($"\nmethod Eiler-Koshi for dx = {dx1}:");
            x0 = 4.5; y0 = 1.1; count = 0;
            for (double i = x0; i < xk + dx1; i += dx1)
            {
                x = x0 + dx1;
                k1 = dx1 * Function(x0, y0);
                k2 = dx1 * Function(x0 + dx1, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 3)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 24)
                {
                    yEilerKoshidx1 = y0;
                }
            }

            Console.WriteLine($"\nmethod Eiler-Koshi for dx = {dx2}:");
            x0 = 4.5; y0 = 1.1; count = 0;
            for (double i = x0; i < xk + dx2; i += dx2)
            {
                x = x0 + dx2;
                k1 = dx2 * Function(x0, y0);
                k2 = dx2 * Function(x0 + dx2, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 4)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 48)
                {
                    yEilerKoshidx2 = y0;
                }
            }

            Console.WriteLine($"\nmethod Eiler-Koshi for dx = {Math.Round(dx3, 4)}:");
            x0 = 4.5; y0 = 1.1; count = 0;
            for (double i = x0; i < xk; i += Math.Round(dx3, 4))
            {
                x = x0 + Math.Round(dx3, 4);
                k1 = Math.Round(dx3, 4) * Function(x0, y0);
                k2 = Math.Round(dx3, 4) * Function(x0 + Math.Round(dx3, 4), y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 4)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 72)
                {
                    yEilerKoshidx3 = y0;
                }
            }

            Console.WriteLine($"\nmethod Eiler-Koshi for dx = {dx4}:");
            x0 = 4.5; y0 = 1.1; count = 0;
            for (double i = x0; i < xk; i += dx4)
            {
                x = x0 + dx4;
                k1 = dx4 * Function(x0, y0);
                k2 = dx4 * Function(x0 + dx4, y0 + k1);
                y = y0 + 0.5 * (k1 + k2);
                Console.WriteLine($"x[{count}]: {Math.Round(x0, 5)}, y[{count}]: {y0}");
                x0 = x;
                y0 = y;

                count++;

                if (count == 96)
                {
                    yEilerKoshidx4 = y0;
                }
            }
        }

        static public double Error(double a, double b)
        {
            return Math.Abs(a - b);
        }
    }
}
