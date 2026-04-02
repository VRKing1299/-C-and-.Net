using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTollManagementSystemLib
{
    /// <summary>
    /// this class is child class of Vehicle class wich simulates the Car and
    /// provides ints own implementation for the Calculate Total Toll method and reutrns the base amount without additional fee
    /// </summary>
    public class Car:Vehicle
    {
        public Car(int id, string name, double amount):base(id, name, amount)
        {

        }

        public override double CalculateTotalToll()
        {
            return BaseTollAmount;
        }
    }
}
