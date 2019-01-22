using System;

namespace VesselApp
{
    public class Program
    {

        public class OldShipException : Exception
        {
            public OldShipException() { }

            public OldShipException(string Year)
            {
                Console.WriteLine($"The vessel from {Year} is to old.");
            }
        }


        public class Speed : IFormattable
        {
            private string speed;

            public Speed(string Speed)
            {
                speed = Speed;
            }

            public Speed GetSpeed
            {
                get { return this; }
            }

            public string MS
            {
                get { return KNToMS(); }
            }
            private string KNToMS() { return Convert.ToString(0.5144 * Convert.ToDouble(speed)); }

            public string KN
            {
                get { return speed; }
            }

            public override string ToString()
            {
                return $"{KN}";
            }

            public string ToString(string format, IFormatProvider formatProvider)
            {
                if (string.IsNullOrEmpty(format)) format = "KN";

                switch (format.ToUpperInvariant())
                {
                    case "MS":
                        return $"{MS}";
                    case "KN":
                        return $"{KN}";
                    default:
                        throw new FormatException(string.Format($"The {format} format string is not supported."));
                }
            }
        }

        public class Vessel
        {
            private string name;
            private string yearBuilt;
            protected Speed speed;

            public Vessel(string Name, string Year, string Speed = "10")
            {


                if ((DateTime.Now.Year - Convert.ToInt32(Year)) > 20)
                {
                    throw new OldShipException(Year);
                }
                name = Name;
                yearBuilt = Year;
                speed = new Speed(Speed);
            }


            public string GetName() { return name; }
            public string GetYearBuilt() { return yearBuilt; }
            public string GetSpeed(string format = "KN") { return speed.ToString(format, null); }
            public virtual void GetVesselInfo(string SpeedFormat = "KN")
            {
                Console.WriteLine($"Name: {GetName()}");
                Console.WriteLine($"Year: {GetYearBuilt()}");
                Console.WriteLine($"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}");
            }

            public virtual string ToString(string SpeedFormat = "KN")
            {
                return $"Name: {name}{Environment.NewLine}Year: {yearBuilt}{Environment.NewLine}" +
                       $"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}";
            }
        }


        public class Ferry : Vessel
        {
            private string passangers;

            public Ferry(string Name, string Year, string Passangers, string Speed = "25") : base(Name, Year, Speed)
            {
                passangers = Passangers;
            }

            public string GetPassangers() { return passangers; }

            public override void GetVesselInfo(string SpeedFormat = "KN")
            {
                Console.WriteLine($"Name: {GetName()}");
                Console.WriteLine($"Year: {GetYearBuilt()}");
                Console.WriteLine($"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}");
                Console.WriteLine($"Passangers: {passangers}");
            }

            public override string ToString(string SpeedFormat = "KN")
            {
                return $"Name: {GetName()}{Environment.NewLine}Year: {GetYearBuilt()}{Environment.NewLine}" +
                       $"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}{Environment.NewLine}Passangers: {passangers}";
            }
        }

        public class Tugboat : Vessel
        {
            private string max_force;

            public Tugboat(string Name, string Year, string Max_force, string Speed = "15") : base(Name, Year, Speed)
            {
                max_force = Max_force;
            }

            public string GetMaxForce() { return max_force; }

            public override void GetVesselInfo(string SpeedFormat = "KN")
            {
                Console.WriteLine($"Name: {GetName()}");
                Console.WriteLine($"Year: {GetYearBuilt()}");
                Console.WriteLine($"Speed: {speed.ToString(SpeedFormat, null)}");
                Console.WriteLine($"Max force: {max_force} N");
            }

            public override string ToString(string SpeedFormat = "KN")
            {
                return $"Name: {GetName()}{Environment.NewLine}Year: {GetYearBuilt()}{Environment.NewLine}" +
                       $"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}{Environment.NewLine}Max force: {max_force} N";
            }

        }

        public class Submarine : Vessel
        {
            private string max_depth;

            public Submarine(string Name, string Year, string Max_depth, string Speed = "40") : base(Name, Year, Speed)
            {
                max_depth = Max_depth;
            }

            public string GetMaxDepth() { return max_depth; }

            public override void GetVesselInfo(string SpeedFormat = "KN")
            {
                Console.WriteLine($"Name: {GetName()}");
                Console.WriteLine($"Year: {GetYearBuilt()}");
                Console.WriteLine($"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}");
                Console.WriteLine($"Max depth: {max_depth} m");
            }

            public override string ToString(string SpeedFormat = "KN")
            {
                return $"Name: {GetName()}{Environment.NewLine}Year: {GetYearBuilt()}{Environment.NewLine}" +
                       $"Speed: {speed.ToString(SpeedFormat, null)} {SpeedFormat}{Environment.NewLine}Max depth: {max_depth} m";
            }

        }




        static void Main(string[] args)
        {

            System.Collections.Generic.List<Vessel> list = new System.Collections.Generic.List<Vessel>();

            try
            {
                list.Add(new Vessel("Thomas", "2001", "100,0"));
                list.Add(new Tugboat("Sivert", "1999", "50", "1,5"));
                list.Add(new Ferry("Even", "2005", "69"));
                list.Add(new Submarine("Lars", "2008", "10"));
            }
            catch (OldShipException) { }


            foreach (Vessel i in list)
            {
                i.GetVesselInfo("MS");
                Console.WriteLine(Environment.NewLine);
            }

            Console.ReadKey();
        }
    }
}