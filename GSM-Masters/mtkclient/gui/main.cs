using DevExpress.XtraEditors;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GSM_Masters.mtkclient.gui
{
    public static class main 
    {
        #region Disable Sleep
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        // Constants for EXECUTION_STATE
        public enum EXECUTION_STATE : uint
        {
            ES_SYSTEM_REQUIRED = 0x1,
            ES_DISPLAY_REQUIRED = 0x2,
            ES_CONTINUOUS = 0x80000000U
        }

        // Method to prevent Windows from entering sleep mode
        public static void PreventSleep()
        {
            SetThreadExecutionState(
                EXECUTION_STATE.ES_CONTINUOUS
                    | EXECUTION_STATE.ES_SYSTEM_REQUIRED
                    | EXECUTION_STATE.ES_DISPLAY_REQUIRED
            );
        }

        // Method to allow Windows to enter sleep mode
        public static void AllowSleep()
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS);
        }
        #endregion
        
        public static string partname = "";
        public static string proseseksekusi = "";
        public static string listdo = "";
        public static string listdo2 = "";
        public static bool bootonly = false;
        public static bool isReadGPTList = false;
        public static string merkhp = "";
        public static string foldername;
        public static string foldersave;
        public static int totaltodo;

        

    }
}
