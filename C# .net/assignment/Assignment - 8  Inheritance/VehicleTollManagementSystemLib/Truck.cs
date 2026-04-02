using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTollManagementSystemLib
{
    /// <summary>
    /// this class is child class of Vehicle class wich simulates the truck and
    /// provides ints own implementation for the Calculate Total Toll method with additional tax of 10% of base amount
    /// </summary>
    public class Truck : Vehicle
    {
        public Truck(int id, string name, double amount):base(id, name, amount)
        {

        }

        public override double CalculateTotalToll()
        {
            double tax = BaseTollAmount * 0.10;
            return BaseTollAmount + tax;
        }
    }
}
