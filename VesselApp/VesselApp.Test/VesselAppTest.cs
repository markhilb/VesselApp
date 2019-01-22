using System;
using Xunit;

namespace VesselApp.Test
{
    public class VesselTesting
    {
        [Fact]
        public void Creating_Vessel_Test()
        {
            string curr_year = Convert.ToString(DateTime.Now.Year);

            var ship = new Program.Vessel("Test", curr_year);

            Assert.NotNull(ship);
            Assert.IsType<Program.Vessel>(ship);
        }

        [Fact]
        public void Creating_Bad_Vessel_Test()
        {
            string bad_year = Convert.ToString(DateTime.Now.Year - 21);

            Assert.Throws<Program.OldShipException>(() => new Program.Vessel("Bad", bad_year));
        }

        [Fact]
        public void Getting_Vessel_values()
        {
            string name = "Test";
            string speed = "50.0";

            string curr_year = Convert.ToString(DateTime.Now.Year);
            var ship = new Program.Vessel(name, curr_year, speed);

            Assert.Equal(name, ship.GetName());
            Assert.Equal(curr_year, ship.GetYearBuilt());
            Assert.Equal(speed, ship.GetSpeed());
        }

        [Fact]
        public void Getting_Ferry_values_Test()
        {
            string name = "Test";
            string passangers = "200";
            string speed = "50.0";

            string curr_year = Convert.ToString(DateTime.Now.Year);
            var ship = new Program.Ferry(name, curr_year, passangers, speed);

            Assert.Equal(name, ship.GetName());
            Assert.Equal(curr_year, ship.GetYearBuilt());
            Assert.Equal(passangers, ship.GetPassangers());
            Assert.Equal(speed, ship.GetSpeed());
        }

        [Fact]
        public void Getting_Tugboat_values_Test()
        {
            string name = "Test";
            string max_force = "200";
            string speed = "50.0";

            string curr_year = Convert.ToString(DateTime.Now.Year);
            var ship = new Program.Tugboat(name, curr_year, max_force, speed);

            Assert.Equal(name, ship.GetName());
            Assert.Equal(curr_year, ship.GetYearBuilt());
            Assert.Equal(max_force, ship.GetMaxForce());
            Assert.Equal(speed, ship.GetSpeed());
        }

        [Fact]
        public void Getting_Submarine_values_Test()
        {
            string name = "Test";
            string max_depth = "500";
            string speed = "50.0";

            string curr_year = Convert.ToString(DateTime.Now.Year);
            var ship = new Program.Submarine(name, curr_year, max_depth, speed);

            Assert.Equal(name, ship.GetName());
            Assert.Equal(curr_year, ship.GetYearBuilt());
            Assert.Equal(max_depth, ship.GetMaxDepth());
            Assert.Equal(speed, ship.GetSpeed());
        }

        [Fact]
        public void Speed_To_String_Test()
        {
            string speed_kn = "100";
            string speed_ms = Convert.ToString(0.5144 * 100);

            Program.Speed speed = new Program.Speed("100");

            Assert.Equal(speed_kn, speed.ToString());
            Assert.Equal(speed_kn, speed.ToString("KN", null));
            Assert.Equal(speed_ms, speed.ToString("MS", null));
            Assert.Throws<FormatException>(() => speed.ToString("NotCorrectInput", null));
        }
    }
}