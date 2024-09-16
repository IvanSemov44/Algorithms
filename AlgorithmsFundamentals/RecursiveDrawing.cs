namespace RecurtionAndBackTracking
{
    //2. Recursive Drawing
    //Write a program that draws the figure below depending on n.

    //Exams
    //2

    //**
    //*
    //#
    //##

    //5

    //*****
    //****
    //***
    //**
    //*
    //#
    //##
    //###
    //####
    //#####


    internal class RecursiveDrawing
    {

        internal static void DrawFigure()
        {
            int n = int.Parse(Console.ReadLine());
            DrawFigure(n);
        }

        private static void DrawFigure(int n)
        {
            if (n == 0)
                return;

            Console.WriteLine(new string('*', n));

            DrawFigure(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}
