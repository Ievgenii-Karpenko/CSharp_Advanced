using System;

namespace _04_2_Events
{
    public class MyEventArgs : EventArgs
    {
        public char ch;
    }

    class KeyEvent
    {
        // Создадим событие, используя обобщенный делегат
        public event EventHandler<MyEventArgs> KeyDown;

        public void OnKeyDown(char ch)
        {
            MyEventArgs c = new MyEventArgs();

            if (KeyDown != null)
            {
                c.ch = ch;
                KeyDown(this, c);
            }
        }
    }

    class Program
    {
        public static void SomeM(object s, MyEventArgs arg)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        static void Main()
        {
            KeyEvent evnt = new KeyEvent();
            evnt.KeyDown += (sender, e) =>
            {
                switch (e.ch)
                {
                    case 'C':
                        {
                            MyColor(true);
                            break;
                        }
                    case 'B':
                        {
                            MyColor(false);
                            break;
                        }
                    case 'S':
                        {
                            Console.Write("\nSet hight: ");
                            try
                            {
                                int Width = int.Parse(Console.ReadLine()) / 8;
                                Console.Write("Set width: ");
                                int Height = int.Parse(Console.ReadLine()) / 8;
                                Console.WindowWidth = Width;
                                Console.WindowHeight = Height;
                                Console.WriteLine();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Unknown format!");
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("To large param!");
                            }
                            break;
                        }
                    case 'T':
                        {
                            Console.Write("\nWrite a title: ");
                            string s = Console.ReadLine();
                            Console.Title = s;
                            Console.WriteLine();
                            break;
                        }
                    case 'R':
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine();
                            break;
                        }
                    case 'E':
                        {
                            Console.Beep();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nCommand not found!");
                            break;
                        }
                }
            };

            evnt.KeyDown += SomeM;

            ConsoleTitle();
            char ch;
            do
            {
                Console.Write("Write a command: ");
                ConsoleKeyInfo key;
                key = Console.ReadKey();
                ch = key.KeyChar;
                evnt.OnKeyDown(key.KeyChar);
            }
            while (ch != 'E');
        }

        // Help methods
        static void ConsoleTitle()
        {
            CC(ConsoleColor.Green);
            Console.WriteLine("***************************\n\nConsole tune program"
                + "\n___________________________\n");
            CC(ConsoleColor.Yellow);
            Console.WriteLine("Commands: \n");
            Command("C", "Change font color");
            Command("B", "Change background dolor");
            Command("S", "Change console size");
            Command("T", "Change window header");
            Command("R", "Reset changes");
            Command("E", "Exit");
            Console.WriteLine();
        }

        static void CC(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        static void Command(string s1, string s2)
        {
            CC(ConsoleColor.Red);
            Console.Write(s1);
            CC(ConsoleColor.White);
            Console.Write(" - " + s2 + "\n");
        }

        static void MyColor(bool F_or_B)
        {
        link1:
            Console.Write("\nWrite a color: ");
            string s = Console.ReadLine();
            switch (s)
            {
                case "Black":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.Black;
                        else
                            Console.BackgroundColor = ConsoleColor.Black;
                        break;
                    }
                case "Yellow":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else
                            Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    }
                case "Green":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    }
                case "Red":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    }
                case "Blue":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else
                            Console.BackgroundColor = ConsoleColor.Blue;
                        break;
                    }
                case "Gray":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else
                            Console.BackgroundColor = ConsoleColor.Gray;
                        break;
                    }
                case "White":
                    {
                        if (F_or_B)
                            Console.ForegroundColor = ConsoleColor.White;
                        else
                            Console.BackgroundColor = ConsoleColor.White;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Try smth another :(");
                        goto link1;
                    }
            }
            Console.WriteLine("Color Changed!");
        }
    }
}
