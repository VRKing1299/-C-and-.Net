using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemLib
{
    /// <summary>
    /// This class represents a VisitingDoctor and inherits from the Doctor class.
    /// It provides its own implementation of the CalculateTotalFee() method,
    /// where the total fee is addition of the consultation fee with additional charges of travell allowance.
    /// </summary>
    public class VisitingDoctor : Doctor
    {
        public double travelAllowance;
        public VisitingDoctor(int id, string name, double fee, double travelAllowance) : base(id, name, fee)
        {
            this.travelAllowance = travelAllowance;
        }

        public override double CalculateTotalFee()
        {
            return ConsultationFee + travelAllowance;
        }
    }
}
