using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ExcelBTCAddin
{
    [ComVisible(true)]
    public class MyRibbon : ExcelRibbon
    {
        public void SayHello(IRibbonControl control1)
        {

            try
            {
                var activeCell = new ExcelReference(5, 5);
                //ExcelAsyncUtil.QueueAsMacro(() => XlCall.Excel(XlCall.xlcSelect, activeCell));
                MessageBox.Show("a");
                //MessageBox.Show("CF - " + current.ColumnFirst + " ------ CL - " + current.ColumnLast);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
