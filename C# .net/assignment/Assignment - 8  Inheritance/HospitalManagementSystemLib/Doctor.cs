using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemLib
{
    /// <summary>
    /// this class prepresents abstract Doctor class in Hospital management system
    /// this class stores the common Doctor information and requires the implementing class to 
    /// provide its own method for calculating total fees
    /// </summary>
    public abstract class Doctor
    {

        public int DoctorId { get; }
        public string DoctorName { get; }
        public double ConsultationFee { get; }

        public Doctor (int id , string name , double fee)
        {
            DoctorId = id;
            DoctorName = name;
            ConsultationFee = fee;
        }

        public abstract double CalculateTotalFee();
    }
}
