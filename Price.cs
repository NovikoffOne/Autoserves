using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Autoserves
{
    abstract class Price
    {
        protected const string EngineDetailName = "Двигатель";
        protected const string WheelDetailName = "Колесо";
        protected const string SteeringWheelDetailName = "Руль";
        protected const string SuspensionDetailName = "Подвеска";

        protected enum Work
        {
            Engine = 50000,
            Wheel = 10000,
            SteeringWheel = 8000,
            Suspension = 80000,
            Other = 5000
        }

        protected enum Detail
        {
            Engine = 30000,
            Wheel = 2000,
            SteeringWheel = 3000,
            Suspension = 50000
        }

        public abstract int GetPrice(string name);
    }

    class DetailPrice : Price
    {
        public override int GetPrice(string name)
        {
            if (name == EngineDetailName)
                return (int)Detail.Engine;
            else if (name == WheelDetailName)
                return (int)Detail.Wheel;
            else if (name == SteeringWheelDetailName)
                return (int)Detail.SteeringWheel;
            else if (name == SuspensionDetailName)
                return (int)Detail.Suspension;

            return 0;
        }
    }

    class WorkPrice : Price
    {
        public override int GetPrice(string name)
        {
            if (name == EngineDetailName)
                return (int)Work.Engine;
            else if (name == WheelDetailName)
                return (int)Work.Wheel;
            else if (name ==SteeringWheelDetailName)
                return (int)Work.SteeringWheel;
            else if (name == SuspensionDetailName)
                return (int)Work.Suspension;

            return (int)Work.Other;
        }
    }
}
