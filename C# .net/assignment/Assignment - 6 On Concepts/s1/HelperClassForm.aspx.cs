using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HelperLib;

/// <summary>
/// this c;ass HelperClassForm peroforms various operations on button click
///  - on button click it performs various operations like loggind, validation and conversion
/// </summary>
public partial class HelperClassForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //btn for logging
    protected void btnLogging_Click(object sender, EventArgs e)
    {
        #region
        try
        {
            //logging using helper class
            lblLoggingMsg.Text = Helper.Logging();
        }catch(Exception ex) { }
        #endregion
    }

    //btn for validation
    protected void btnValidation_Click(object sender, EventArgs e)
    {
        #region
        try
        {
            //validation and display
            lblValidationMsg.Text = Helper.Validation();
        }catch(Exception ex) { }
        #endregion
    }

    //btn for Conversion
    protected void btnConversion_Click(object sender, EventArgs e)
    {
        #region
        try
        {
            //conversion and display the result
            lblConversionMsg.Text = Helper.Conversion();
        }catch(Exception ex) { }
        #endregion
    }
}