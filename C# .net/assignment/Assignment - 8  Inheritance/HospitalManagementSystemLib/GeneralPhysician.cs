using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystemLib
{
    /// <summary>
    /// This class represents a General Physician and inherits from the Doctor class.
    /// It provides its own implementation of the CalculateTotalFee() method,
    /// where the total fee is equal to the consultation fee with no additional charges.
    /// </summary>
    public class GeneralPhysician : Doctor
    {
        public GeneralPhysician(int id, string name, double fee) : base(id, name, fee)
        {

        }

        public override double CalculateTotalFee()
        {
            return ConsultationFee;
        }
    }
}
