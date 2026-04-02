using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestLib
{
    public abstract class Employee
    {
        protected int id, sal;
        private string name;

        public string Name
        {
            get { return name; }
        }

        public int Id
        {
            get { return id; }
        }

        public int Sal
        {
            get { return sal; }
        }

        public abstract int CalcSal();

        public Employee(int empId,string empName,int sal)
        {
            id = empId;
            name = empName;
            this.sal = sal;
        }
    }


    //child class 
    public class ContractBasedEmp : Employee
    {
        string contactPeriod;
        int payAsPerContractperiod;

        public string ContactPeriod
        {
            get
            {
                return contactPeriod;
            }
        }

        public int PayAsPerContractperiod
        {
            get
            {
                return payAsPerContractperiod;
            }
        }

 
        public ContractBasedEmp(int empId,string empName,int sal,string contactPeriod, int payAsPerContractperiod):base(empId,empName,sal)//  base calls the paren class constructor which takes the value from child class constructor
        {
            this.contactPeriod = contactPeriod;
            this.payAsPerContractperiod = payAsPerContractperiod;
        }

        public override int CalcSal()
        {
            return payAsPerContractperiod + sal;
        }
    }

    //another child class 
    public class SaleriedEmployee : Employee
    {
        int bonus;

        public int Bonus
        {
            get
            {
                return bonus;
            }
        }

        public SaleriedEmployee(int empId, string empName, int sal, int bonus) : base(empId, empName, sal)
        {
            this.bonus = bonus;
        }

        public override int CalcSal()
        {
            return sal + bonus;
        }
    }
}
