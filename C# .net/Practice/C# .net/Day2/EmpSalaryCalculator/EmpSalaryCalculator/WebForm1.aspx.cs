using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmpLib;

namespace EmpSalaryCalculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //button so calculate the net salary
        protected void button_Click(object sender, EventArgs e)
        {
            int basic, da, pf, hra;
            try
            {
                empId.Visible = true;
                empName.Visible = true;
                empSal.Visible = true;

                basic = Convert.ToInt16(tbBsal.Text);
                da = Convert.ToInt16(tbDF.Text);
                pf = Convert.ToInt16(tbPf.Text);
                hra = Convert.ToInt16(tbHra.Text);

                empId.Text = tbId.Text;
                empName.Text = tbEname.Text;

                Employee em = new Employee();

                empSal.Text =Convert.ToString( em.CalcNetSalary(basic, hra, da, pf));


            }catch(Exception ex)
            {
                errorMsg.Visible = true;
                errorMsg.Text = "an error has occured";

            }


        }
    }
}