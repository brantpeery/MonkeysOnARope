using System;
using MonkeysOnARope;
namespace MonkeysOnARope
{
    class Program
    {
        static void Main(string[] args)
        {
            World w = new World();
            w.RaiseMessageEvent += OnWorldMessage;

            bool enterPressed = false;
            do
            {
                Console.WriteLine("Press L to add a monkey to the left side, R to add one to the right. Enter to start the run.");
                var key = Console.ReadKey();


                switch (key.Key)
                {
                    case ConsoleKey.R:
                        w.RightQue.Add(new Monkey(string.Format("Right{0}", w.RightQue.Count + 1), World.Side.Left));
                        Console.WriteLine(string.Format("Monkey {0} added to the Right side.", w.RightQue[w.RightQue.Count - 1].ID));
                        break;
                    case ConsoleKey.L:
                        w.LeftQue.Add(new Monkey(string.Format("Left{0}", w.LeftQue.Count + 1), World.Side.Right));
                        Console.WriteLine(string.Format("Monkey {0} added to the Left side.", w.LeftQue[w.LeftQue.Count - 1].ID));
                        break;
                    case ConsoleKey.Enter:
                        enterPressed = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (enterPressed == false);

            do
            {
                //Show the step number I am about to take
                Console.WriteLine(string.Format("Step:{0}", w.NumStepsTaken + 1));
                w.Step();
            } while (w.Done == false);
            Console.WriteLine("Everyone has crossed in {0} steps", w.NumStepsTaken);
            Console.ReadKey();
        }


        static void OnWorldMessage(object sender, string msg)
        {
            Console.WriteLine(msg);
        }


    }
}
