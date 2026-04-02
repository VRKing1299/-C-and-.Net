using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemLib
{
    /// <summary>
    /// This class represents a Surgeon and inherits from the Doctor class.
    /// It provides its own implementation of the CalculateTotalFee() method,
    /// where the total fee is addition of the consultation fee with additional charges of 25% of ConsultationFee.
    /// </summary>
    public class Surgeon : Doctor
    {
        public Surgeon(int id, string name, double fee) : base(id, name, fee)
        {

        }

        public override double CalculateTotalFee()
        {
            double surgeryCharges = ConsultationFee * 0.25;
            return ConsultationFee + surgeryCharges;
        }
    }
}
