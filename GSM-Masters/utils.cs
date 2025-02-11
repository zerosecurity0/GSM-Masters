using System;
using System.Drawing;
using GSM_Masters;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace GSM_Masters.mtkclient.gui
{
    public class utils
    {
        public static Form1 mainForm;
        public static bool Stop;

        public static void WriteLog(string text, Color? colors = default, bool breakline = false)
        {
            if (mainForm.Log.InvokeRequired)
            {
                mainForm.Log.Invoke(new Action(() =>
                {
                    if (string.IsNullOrEmpty(text))
                    {
                    }
                    // txtLog.AppendText(vbCrLf)
                    else
                    {

                    }
                    mainForm.Log.SelectionStart = mainForm.Log.TextLength;
                    mainForm.Log.SelectionLength = 0;
                    //mainForm.Log.SelectionColor = If(colors, mainForm.Log.ForeColor);
                    if (breakline)
                    {
                        mainForm.Log.AppendText(Constants.vbCrLf + text);
                    }
                    else
                    {
                        mainForm.Log.AppendText(text);
                    }
                    mainForm.Log.SelectionColor = mainForm.Log.ForeColor;
                    mainForm.Log.ScrollToCaret();
                }));
                return;
            }
            if (string.IsNullOrEmpty(text))
            {
            }
           // mainForm.Log.AppendText(vbCrLf);
            else
            {

            }
            mainForm.Log.SelectionStart = mainForm.Log.TextLength;
            mainForm.Log.SelectionLength = 0;
            // txtLog.Log.SelectionColor = If(colors, txtLog.Log.ForeColor)
            if (breakline)
            {
                mainForm.Log.AppendText(Constants.vbCrLf + text);
            }
            else
            {
                mainForm.Log.AppendText(text);
            }
            mainForm.Log.SelectionColor = mainForm.Log.ForeColor;
            mainForm.Log.ScrollToCaret();
        }

        

        

        

    }
}