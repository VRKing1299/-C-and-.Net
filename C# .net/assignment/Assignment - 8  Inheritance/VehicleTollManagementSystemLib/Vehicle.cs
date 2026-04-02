using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTollManagementSystemLib
{

    /// <summary>
    /// this class prepresents abstract vehicle class in toll management system
    /// this class stores the common payment information and requires the implementing class to 
    /// provide its own method for calculating total toall
    /// </summary>
    public abstract class Vehicle
    {
        public int VehicleNumber { get; }
        public string OwnerName{ get; }
        public double BaseTollAmount { get; }

        public Vehicle(int id, string name , double amount)
        {
            VehicleNumber = id;
            OwnerName = name;
            BaseTollAmount = amount;
        }

        public abstract double CalculateTotalToll();
    }
}
