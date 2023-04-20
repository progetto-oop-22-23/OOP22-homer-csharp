using System;
using Homer.model;
namespace HomerTest
{
    class OutletTest
    {
        public static void Main(string[] args)
        {
            TestUpdateTick();
        }

        static void TestUpdateTick()
        {
            OutletState state = new OutletState(0,1500,10);
            Outlet outlet = new Outlet(state);
            double initialConsumption = state.Consumption;

            outlet.UpdateTick(new TimeSpan(0, 0, 1)); // Increase time by 1 second

            if (state.Consumption == initialConsumption)
            {
                Console.WriteLine("Test failed: Consumption did not change after calling UpdateTick.");
            }
            else
            {
                Console.WriteLine("Test passed: Consumption changed after calling UpdateTick.");
            }
        }
    }
}
