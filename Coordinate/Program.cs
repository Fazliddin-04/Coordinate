using System;

namespace Coordinate
{
    interface IFlyable
    {
        void FlyTo(double distance); // interface method (does not have a body)
        void GetFlyTime(); // interface method (does not have a body)
    }
    class Bird : IFlyable
    {
        public int speed = 0;
        double currentPosition = 0;

        public void FlyTo(double distance)
        {
            // The body of FlyTo() is provided here
            currentPosition += distance;
            Console.WriteLine(" Current position: " + currentPosition);
        }
        public void GetFlyTime()
        {
            // The body of GetFlyTime() is provided here
            Console.WriteLine(" Bird's fly time: " + Math.Floor(currentPosition / speed) + " hrs");
        }
    }
    class Airplane : IFlyable
    {
        public int speed = 200;
        double time = 0;
        double currentPosition = 0;

        public void FlyTo(double distance)
        {
            // The body of FlyTo() is provided here
            if (distance < 10)  // restriction  
            { 
                Console.WriteLine("Do not bother Airplane!");
                return;
            }
            double i = Math.Floor(distance / 10);
            while (i > 0)
            {
                speed += 10;
                i--;
            }

            time = Math.Floor(currentPosition / speed);
            currentPosition += distance;
            Console.WriteLine(" Current position: " + currentPosition);
        }
        public void GetFlyTime()
        {
            // The body of GetFlyTime() is provided here
            Console.WriteLine(" Airplane's fly time: " + time + " hrs");
        }
    }
    class Drone : IFlyable
    {
        public int speed = 0;
        double time = 0;
        double currentPosition = 0;

        public void FlyTo(double distance)
        {
            // The body of FlyTo() is provided here
            if (distance > 1000) // restriction
            { 
                Console.WriteLine("The impossibility of flying a drone at a distance of more than 1000 km");
                return;
            }

            time = Math.Floor(currentPosition / speed) * 10;

            currentPosition += distance;
            Console.WriteLine(" Current position: " + currentPosition);
        }
        public void GetFlyTime()
        {
            // The body of GetFlyTime() is provided here
            Console.WriteLine(" Drone's fly time: " + time + " hrs");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Car Park in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                Bird bird = new Bird();
                Airplane airplane = new Airplane();
                Drone drone = new Drone();

                Random rnd = new Random();
                bird.speed = rnd.Next(1, 20); // The speed of the bird is set randomly

                string obj = "";
                Console.WriteLine("Please, enter an object (bird, airplane, drone or all): ");
                obj = Console.ReadLine();

                // Ask the user to type the second number.
                Console.Write("Type distance (km) in number, and then press Enter: ");
                string numInput = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput = Console.ReadLine();
                }

                try
                {
                    switch (obj)
                    {
                        case "Bird" or "bird" or "BIRD":
                            Console.WriteLine(" Speed: " + bird.speed);
                            bird.FlyTo(cleanNum2);
                            bird.GetFlyTime();
                            break;
                        case "Airplane" or "airplane" or "AIRPLANE":
                            Console.WriteLine(" Initial speed: " + airplane.speed);
                            airplane.FlyTo(cleanNum2);
                            airplane.GetFlyTime();
                            Console.WriteLine(" Speed: " + airplane.speed);
                            break;
                        case "Drone" or "drone" or "DRONE":
                            Console.WriteLine(" Speed: " + drone.speed);
                            drone.FlyTo(cleanNum2);
                            drone.GetFlyTime();
                            break;
                        case "All" or "all" or "ALL":
                            Console.WriteLine("Bird:");
                            Console.WriteLine(" Speed: " + bird.speed);
                            bird.FlyTo(cleanNum2);
                            bird.GetFlyTime();
                            Console.WriteLine("------------------------\n");
                            Console.WriteLine("Airplane:");
                            Console.WriteLine(" Initial speed: " + airplane.speed);
                            airplane.FlyTo(cleanNum2);
                            airplane.GetFlyTime();
                            Console.WriteLine(" Speed: " + airplane.speed);
                            Console.WriteLine("------------------------\n");
                            Console.WriteLine("Drone:");
                            Console.WriteLine(" Speed: " + drone.speed);
                            drone.FlyTo(cleanNum2);
                            drone.GetFlyTime();
                            Console.WriteLine("------------------------\n");
                            break;
                        default:
                            Console.WriteLine("Something went wrong...");
                            break;
               
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! Something went wrong...\n - Details: " + e.Message);
                }

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}
