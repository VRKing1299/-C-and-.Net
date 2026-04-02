using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTollManagementSystemLib
{
    /// <summary>
    /// this class is child class of Vehicle class wich simulates the Bus and
    /// provides ints own implementation for the Calculate Total Toll method with additonal tax of 5% on base amount
    /// </summary>
    public class Bus:Vehicle
    {
        public Bus(int id, string name, double amount):base(id, name, amount)
        {

        }

        public override double CalculateTotalToll()
        {
            double tax = BaseTollAmount * 0.05;
            return BaseTollAmount + tax;
        }
    }
}
