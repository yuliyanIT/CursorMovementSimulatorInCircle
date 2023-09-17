using System;
using System.Threading;
using WindowsInput;
class Program
{
    static void Main()
    {
        Console.WriteLine("Simulation...");
        SimulateCircularCursorMovement();
    }

    static void SimulateCircularCursorMovement()
    {
        var inputSimulator = new InputSimulator();
        int screenWidth = 1920;
        int screenHeight = 1080; 
        double centerX = screenWidth / 2.0;
        double centerY = screenHeight / 2.0;


        int numberOfCircles = 5;
        double[] circleRadii = new double[numberOfCircles];
        for (int i = 0; i < numberOfCircles; i++)
        {
            circleRadii[i] = Math.Min(centerX, centerY) - 50 + (i + 1) * 100; 
        }

        foreach (var radius in circleRadii)
        {
            for (double angle = 0; angle <= 360; angle += 1)
            {
                double radians = angle * (Math.PI / 180);
                double x = centerX + (radius * Math.Cos(radians));
                double y = centerY + (radius * Math.Sin(radians));

                inputSimulator.Mouse.MoveMouseTo((int)x, (int)y);

                Thread.Sleep(10); 
            }
        }

        Console.WriteLine("Finished");
    }
}
