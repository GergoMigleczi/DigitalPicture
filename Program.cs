using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DigitalPicture
{
    struct Picture
    {
        public int r;
        public int g;
        public int b;
        public Picture(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
    class DigitalPicture
    {
        static List<Picture> PixelList = new List<Picture>();

        //Read the file and store the data
        static void Task1()
        {
            StreamReader sr = new StreamReader("kep.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split();
                int r = int.Parse(line[0]);
                int g = int.Parse(line[1]);
                int b = int.Parse(line[2]);

                Picture row = new Picture(r, g, b);
                PixelList.Add(row);
            }
            sr.Close();
        }

        //Print if the colour given by the user can be found in the picture or not
        static void Task2()
        {
            Console.WriteLine("Task 2");
            Console.WriteLine("RGB code:");
            string[] rgb = Console.ReadLine().Split();
            int givenR = int.Parse(rgb[0]);
            int givenG = int.Parse(rgb[1]);
            int givenB = int.Parse(rgb[2]);
            bool canBeFound = false;
            foreach (Picture item in PixelList)
            {
                if (item.r == givenR && item.g == givenG && item.b == givenB)
                    canBeFound = true;

            }
            if (canBeFound)
                Console.WriteLine("The colour can be found in the picture");
            else
                Console.WriteLine("The colour can not be found in the picture");
        }

        //Find the 8th pixel in the 35th row. 
        //Calculatte how many times that colour appears in teh 35th row and 8th coloumn.
        static void Task3()
        {
            Console.WriteLine("Task 3");
            int row = 0;
            int counter = 0;
            Picture TheColour = new Picture();
            int inTheRow = 0;
            int inTheColoumn = 0;
            foreach (Picture item in PixelList)
            {
                counter++;
                row = (int)Math.Floor((double)counter / 50) + 1;

                int coloumn = counter % 50 + 1;


                if (row == 35 && coloumn == 8)
                {
                    TheColour = item;
                    break;
                }
            }
            counter = 0;
            foreach (Picture item in PixelList)
            {
                counter++;
                row = (int)Math.Floor((double)counter / 50) + 1;

                int coloumn = counter % 50 + 1;


                if (row == 35 && item.r == TheColour.r && item.g == TheColour.g && item.b == TheColour.b)
                {
                    inTheRow++;
                }
                if (coloumn == 8 && item.r == TheColour.r && item.g == TheColour.g && item.b == TheColour.b)
                {
                    inTheColoumn++;
                }
            }
            Console.WriteLine($"In the row: {inTheRow} In the coloumn: {inTheColoumn}");
        }

        //Calculate which base colour appears in the picture the most times. Red green or blue?
        static void Task4()
        {
            Console.WriteLine("Task 4");

            int red = 0, green = 0, blue = 0;
            foreach (Picture item in PixelList)
            {
                if (item.r == 255 && item.g == 0 && item.b == 0)
                    red++;
                if (item.r == 0 && item.g == 255 && item.b == 0)
                    green++;
                if (item.r == 0 && item.g == 0 && item.b == 255)
                    blue++;
            }
            if (red > green && red > blue)
                Console.WriteLine("Red appears the most");
            if (green > red && green > blue)
                Console.WriteLine("Green appears the most");
            if (blue > red && blue > green)
                Console.WriteLine("Blue appears the most");
        }

        //Make a 3px wide black border. The picture size can not change.    
        static void Task5()
        {
            StreamWriter sw = new StreamWriter("keretes.txt");
            int counter = 0;
            foreach (Picture item in PixelList)
            {
                counter++;
                int row = (int)Math.Floor((double)counter / 50) + 1;
                int coloumn = counter % 50 + 1;

                if (coloumn < 4 || coloumn > 47 || row < 4 || row > 47)
                    sw.WriteLine("0 0 0");
                else
                    sw.WriteLine($"{item.r} {item.g} {item.b}");
            }

            sw.Flush();
            sw.Close();
        }

        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Console.ReadKey();
        }
    }
}
