using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IWalkBehavior walkBehavior = new WalkBehaviorD();
            IDuck duck = new WildDuck(walkBehavior);
            IDuck cityDuck = new CityDuck();
            IDuck mountainDuck = new MountainDuck();
            IDuck cloudDuck = new CloudDuck();

            Console.WriteLine(duck.Fly());
            Console.WriteLine(cityDuck.Fly());
            Console.WriteLine(mountainDuck.Fly());
            Console.WriteLine(mountainDuck.Fly());


        }
    }
    interface IDuck
    {
        string Walk();
        string Display();
        string Fly();
    }

    interface IWalkBehavior
    {
        string Walk();
    }

    class WalkBehaviorD: IWalkBehavior
    {
        public string Walk()
        {
            return "D";
        }
    }

    class WildDuck : IDuck
    {
        private IWalkBehavior _walkbehavior;

        public WildDuck(IWalkBehavior b)
        {
            this._walkbehavior = b;
        }

    
        public string Walk()
        {
            return "Walking wildly";
        }

        public string Display()
        {
            throw new NotImplementedException();
        }

        public string Fly()
        {
            return "Seriously wild flying";
        }
    }

    class CityDuck : IDuck
    {
        public string Walk()
        {
            return "Walking causally";
        }

        public string Display()
        {
            throw new NotImplementedException();
        }

        public string Fly()
        {
            return "High-intensity flying";
        }
    }

    class MountainDuck : IDuck
    {
        public string Walk()
        {
            return "Flies or stands still";
        }

        public string Display()
        {
            throw new NotImplementedException();
        }

        public string Fly()
        {
            return "High-altitude flying";
        }
    }

    class CloudDuck : IDuck
    {
        public string Walk()
        {
            return "No Walking";
        }

        public string Display()
        {
            throw new NotImplementedException();
        }

        public string Fly()
        {
            return "High-altitude flying";
        }
    }
}
