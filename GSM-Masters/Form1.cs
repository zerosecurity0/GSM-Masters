using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSScriptLib;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout.Modes;
using DevExpress.XtraWaitForm;
using GSM_Masters.mtkclient.gui;
using GSM_Masters.Properties;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProgressBar = System.Windows.Forms.ProgressBar;


namespace GSM_Masters
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public static string stsLog = "";
        public static bool busyState = false;
        public string sevenzip = Path.Combine(Application.StartupPath, "data", "7zs", Environment.Is64BitOperatingSystem ? "7zax64.exe" : "7za.exe");
        public string sevenzipNew = Path.Combine(Application.StartupPath, "data", "7zs", "7z.exe");
        public List<comInfo> listDevices = new List<comInfo>();
        public class comInfo
        {
            public string name { get; set; }
            public string hwid { get; set; }
            public string comport { get; set; }
            public int type { get; set; }


        }
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnReadGPT_Click(object sender, EventArgs e)
        {
            if (Form1.busyState)
            {
                return;
            }
            Log.Text = null;
            MenuEx = MenuEksekusi.mode2;
            Task.Run(() => DimensitiRun("printgpt|Getting partitions"));
        }
        public bool Extract(string fileToExtract, string destExtract, string customexe = null)
        {
            string arguments = "x \"" + fileToExtract + "\" -o\"" + destExtract + "\" -r -y";
            var process = new Process();
            var startInfo = new ProcessStartInfo()
            {
                FileName = Equals(customexe, null) ? sevenzip : customexe,
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            process.StartInfo = startInfo;
            process.Start();
            string text = "";
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (!process.HasExited)
            {
                Thread.Sleep(100);
                text += process.StandardOutput.ReadToEnd();
                Console.WriteLine(text);
            }
            process.Dispose();
            if (text.Contains("Everything is Ok"))
            {
                return true;
            }
            return false;
        }
        public void SendLog(string text, Color? colors = default, bool breakline = false)
        {
            if (Log.InvokeRequired)
            {
                Log.Invoke(new Action(() =>
                {
                    if (string.IsNullOrEmpty(text))
                    {
                    }
                    // txtLog.AppendText(vbCrLf)
                    else
                    {

                    }
                    Log.SelectionStart = Log.TextLength;
                    Log.SelectionLength = 0;
                    // txtLog.Log.SelectionColor = If(colors, txtLog.Log.ForeColor)
                    if (breakline)
                    {
                        Log.AppendText(Constants.vbCrLf + text);
                        stsLog += Constants.vbCrLf + text;
                    }
                    else
                    {
                        Log.AppendText(text);
                        stsLog += text;
                    }
                    Log.SelectionColor = Log.ForeColor;
                    Log.ScrollToCaret();
                }));
                return;
            }
            if (string.IsNullOrEmpty(text))
            {
            }
            //txtLog.AppendText(vbCrLf);
            else
            {

            }
            Log.SelectionStart = Log.TextLength;
            Log.SelectionLength = 0;
            //Log.SelectionColor = If(colors, Log.ForeColor);
            if (breakline)
            {
                Log.AppendText(Constants.vbCrLf + text);
                stsLog += Constants.vbCrLf + text;
            }
            else
            {
                Log.AppendText(text);
                stsLog += text;
            }
            Log.SelectionColor = ForeColor;
            Log.ScrollToCaret();
        }
        public void SetProgressBarRunning(bool isRunning = true, bool enableStopButton = false)
        {
            busyState = isRunning;
            progressBarRunning(isRunning, enableStopButton);
        }

        private void controlButton(bool @bool = true)
        {
            // Dim list As List(Of SimpleButton) = New List(Of SimpleButton) From {
            // buttonConfig
            // }
            // list.ForEach(Sub(ByVal e)
            // If e.InvokeRequired Then
            // e.Invoke(CType(Sub() e.Enabled = Not bool, MethodInvoker))
            // Else
            // e.Enabled = Not bool
            // End If
            // End Sub)
        }
        public void progressBarRunning(bool @bool = true, bool enableStop = false)
        {
            controlButton(@bool);
            busyState = @bool;
            if (enableStop)
            {
                if (buttonStop.InvokeRequired)
                {
                    // If bool Then
                    // buttonStop.Enabled = True
                    // Else
                    // buttonStop.Enabled = False
                    // End If
                    buttonStop.Invoke(new Action(() => buttonStop.Text = "Terminate"));
                }
                else
                {
                    buttonStop.Text = "Terminate";
                    // If bool Then
                    // buttonStop.Enabled = True
                    // Else
                    // buttonStop.Enabled = False
                    // End If
                }
            }
            if (ProgressBar.InvokeRequired)
            {
                ProgressBar.Invoke(new Action(() => { if (@bool) { MarqueeProgressBar.Properties.Stopped = false; MarqueeProgressBar.BringToFront(); MarqueeProgressBar.Properties.MarqueeAnimationSpeed = 35; } else { MarqueeProgressBar.Properties.Stopped = true; ProgressBar.BringToFront(); ProgressBar.Position = 0; } }));
            }

            else if (@bool)
            {
                MarqueeProgressBar.Properties.Stopped = false;
                MarqueeProgressBar.BringToFront();
                MarqueeProgressBar.Properties.MarqueeAnimationSpeed = 35;
            }
            else
            {
                MarqueeProgressBar.Properties.Stopped = true;
                ProgressBar.BringToFront();
                ProgressBar.Position = 0;
            }
        }

        public void stylePercentProgress()
        {
            if (ProgressBar.InvokeRequired)
            {
                ProgressBar.Invoke(new Action(() =>
                {
                    ProgressBar.BringToFront();
                    ProgressBar.Properties.Minimum = 0;
                    ProgressBar.Properties.Maximum = 1000;
                }));
            }
            else
            {
                ProgressBar.BringToFront();
                ProgressBar.Properties.Minimum = 0;
                ProgressBar.Properties.Maximum = 1000;
            }
        }

        private bool GetBoolean(CheckEdit textbox)
        {
            var rt = default(bool);
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new Action(() => rt = textbox.Checked));
            }
            else
            {
                rt = textbox.Checked;
            }
            return rt;
        }
        private string TagString(TextEdit textbox)
        {
            if (textbox == null || textbox.Tag == null) // Check for null textbox and tag
            {
                return string.Empty; // Or return a default value, or throw an exception
            }

            string rt = "";
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new Action(() => rt = textbox.Tag.ToString()));
            }
            else
            {
                rt = textbox.Tag.ToString();
            }
            return rt;
        }

        // More concise version using the null-conditional operator (?.)
        

        #region MTK

        private string mtkcommand = "";
        private string[] erasecmd = Array.Empty<string>();
        private int erasecun = 0;
        private MenuEksekusi MenuEx = new MenuEksekusi();
        public bool preloadermode = false;
        public SerialPort Ports = new SerialPort();

        // 'STS
        public string objJob = "";
        public string objData = "";
        public string objSts = "";
        public string objAck = "";

        public enum MenuEksekusi
        {
            mode1,
            mode2
        }
        private string ramsize = null;
        private void ToggleButtonsEnabled(bool disableButtons = true)
        {
            var buttonList = new List<SimpleButton>() { btn_ReadDump, BtnReadGPT, btnRead, btnErase, btnWrite, btnMtkExit, buttonVerifyDump, btnReadHardwareKeys, btn_emichoose };
            buttonList.ForEach(currentButton => { if (currentButton.InvokeRequired) { currentButton.Invoke(new Action(() => currentButton.Enabled = !disableButtons)); } else { currentButton.Enabled = !disableButtons; } });
        }
        private bool StartEngine()
        {
            string text3 = Path.Combine(Application.StartupPath, "data", "mtk", "python.exe");
            string text5 = Path.Combine(Application.StartupPath, "data", "mtk", "mtk", "mtk");
            string text6 = Path.Combine(Application.StartupPath, "data", "mtk");
            string text4 = Path.Combine(Application.StartupPath, "data", "emi");

            if (!File.Exists(Path.Combine(text6, "python3.7z")))
            {
            }
            else
            {
                Extract(Path.Combine(text6, "python3.7z"), text6);
            }

            if (!File.Exists(text3) | !File.Exists(text5) | !Directory.Exists(text6))
            {
                if (!Extract(Path.Combine(Application.StartupPath, "data", "mtk.7z"), Path.Combine(Application.StartupPath, "data")))
                {
                    return false;
                }
            }
            return true;
        }


        private async Task DimensitiRun(string input) // Изменяем на async Task
        {
            string[] cmd = Strings.Split(input, "|");
            mtkcommand = cmd[0];

            string arguments = "\"" + Path.Combine(Application.StartupPath, "data", "mtk", "mtk", "mtk") + "\" " + cmd[0];
            bool flag2 = GetBoolean(chkEMI);
            string textpreloader = TagString(txtEMI);
            if (flag2)
            {
                if (string.IsNullOrEmpty(textpreloader) | textpreloader == "?")
                {
                    SendLog("Unknown custom preloader", default, false);
                    return; // Используем return вместо goto SKIP
                }
                else
                {
                    arguments += $" --preloader=\"{textpreloader}\" ";
                }
            }
            if (GetBoolean(chkExit))
            {
                bool result = CrashFunction();
                if (!result)
                {
                    return; // Используем return вместо goto SKIP
                }

                SendLog(Constants.vbNewLine);
            }
            Form1.stsLog = "";
            Form1.busyState = true;
            ramsize = null;
            ToggleButtonsEnabled();
            SendLog("Подожди не трогай меня... ", default);
            string text3 = Path.Combine(Application.StartupPath, "data", "mtk", "python.exe");
            string text5 = Path.Combine(Application.StartupPath, "data", "mtk", "mtk", "mtk");
            string text6 = Path.Combine(Application.StartupPath, "data", "mtk");
            string text4 = Path.Combine(Application.StartupPath, "data", "emi");

        RERUN:
            if (!File.Exists(text3) | !File.Exists(text5) | !Directory.Exists(text6))
            {
                if (!StartEngine())
                {
                    SendLog("FAIL", Color.Red);
                    goto SKIP; // Оставляем goto SKIP, так как здесь нет асинхронности
                }
                else
                {
                    goto RERUN; // Оставляем goto RERUN, так как здесь нет асинхронности
                }
            }
            else
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo()
                {
                    FileName = text3,
                    WorkingDirectory = text4,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                process.StartInfo = startInfo;
                string re = "";
                process.OutputDataReceived += (object sendingProcess, DataReceivedEventArgs dataLine) => DiLog(dataLine.Data, ref re);

                process.Start();
                process.BeginOutputReadLine();

                // Асинхронное ожидание завершения процесса
                await Task.Run(() => process.WaitForExit()); // Ключевое изменение!

                process.Dispose();

                if (string.IsNullOrEmpty(re) | string.IsNullOrWhiteSpace(re))
                {
                    goto SKIP; // Оставляем goto SKIP, так как здесь нет асинхронности
                }
            }

            string result1 = Form1.stsLog;
            if (MenuEx == MenuEksekusi.mode1)
            {
                if (!result1.ToUpper().Contains("ERROR") && !result1.ToUpper().Contains("FAIL") && !result1.ToUpper().Contains("SKIP") && result1.Contains("Подключите телефон в режиме BROM или Preloader... OK"))
                {
                    objSts = "DONE";
                }
                else
                {
                    objSts = "FAIL";
                }
            }

        SKIP:
            Form1.busyState = false;
            ToggleButtonsEnabled(false);
        }
        private bool CrashPreloader(SerialPort Ports)
        {
            byte[] da = Resources.preload;
            bool response = send_da(Convert.ToString(0), Convert.ToString(da.Length), Convert.ToString(0), da, Ports);


            return response;
        }

        private byte[] HexStringToBytes(string s)
        {
            try
            {
                s = s.Replace(Conversions.ToString(' '), "");
                int nBytes = s.Length / 2;
                var a = new byte[nBytes];
                for (int i = 0, loopTo = nBytes - 1; i <= loopTo; i++)
                    a[i] = Convert.ToByte(s.Substring(i * 2, 2), 16);

                return a;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public void echo(string inputhexstring, int lenBytesToSend, SerialPort Ports)
        {
            string finalinput = "";
            if (!(inputhexstring.Length % 2 == 0))
            {
                finalinput = "0" + inputhexstring;
            }
            else
            {
                finalinput = inputhexstring;
            }

            double len = finalinput.Length / 2d;
            string finalhex = "";

            if (len < lenBytesToSend)
            {
                double kurangnya = lenBytesToSend - len;
                if (kurangnya == 1d)
                {
                    finalhex = "00" + finalinput;
                }
                else if (kurangnya == 2d)
                {
                    finalhex = "0000" + finalinput;
                }
                else if (kurangnya == 3d)
                {
                    finalhex = "000000" + finalinput;
                }
            }
            else if (len > lenBytesToSend)
            {
                double kurangsub = len - lenBytesToSend;
                finalhex = finalinput.Substring(0, lenBytesToSend);
            }
            else
            {
                finalhex = finalinput;
            }

            byte[] data = HexStringToBytes(finalhex);
            writemtk(data, Ports);

            byte[] response = readmtk(lenBytesToSend, Ports);
            CheckResponse(finalhex, BytesToHextring(response));
        }
        public bool CheckResponse(string datasend, string response)
        {

            if (!((datasend.ToLower() ?? "") == (response.ToLower() ?? "")))
            {
                return true;
            }
            else
            {
                return true;
            }
        }
        private bool send_da(string DaAdressHexstring, string DaLen, string siglen, byte[] da, SerialPort Ports)
        {
            try
            {
                byte[] buff = new byte[] { };
                echo("d7", 1, Ports);
                echo(DaAdressHexstring, 4, Ports);
                echo(Conversion.Hex(DaLen), 4, Ports);
                echo(siglen, 4, Ports);
                readmtk(2, Ports);
                int kontolpanjang = da.Length;
                int kontolpendek = 0;
                int kontolgede = 0;
                int memekbau = 8192;
                byte[] toketgede = new byte[] { };
                using (var stream = new MemoryStream(da))
                {
                    while (kontolpanjang > 0)
                    {

                        if (kontolpanjang < memekbau)
                        {
                            memekbau = da.Length - kontolgede;
                        }
                        toketgede = new byte[memekbau];
                        kontolpendek = stream.Read(toketgede, 0, memekbau);

                        kontolpanjang -= kontolpendek;
                        kontolgede += kontolpendek;
                        writemtk(toketgede, Ports);
                        // ProcessBar(kontolgede, da.Length)
                    }
                }
                byte[] ceksum = readmtk(2, Ports);
                byte[] status = readmtk(2, Ports);
                // If Not BytesToHextring(status) = "0000" Then
                // ErrorResponseMtk(status)
                // Else
                // SendLog("Sending Loader true")
                // End If
                BytesToHextring(ceksum);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        private bool CrashFunction()
        {
            byte[] DaLoaderFinal = new byte[] { };
            byte[] DaLoaderFinal2 = new byte[] { };

            SendLog("Waiting for Preloader connection...");
            SetProgressBarRunning();
            var deviceList = listDevices;
            var selectedDevice = FindNewDevice(deviceList);

            if (selectedDevice is null)
            {
                SetProgressBarRunning(false);
                SendLog("Unknown Preloader connection", default, true);
                return false;
            }
            else
            {
                string[] usb = Misc.VID(selectedDevice.hwid);
                SendLog("Port " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": COM" + selectedDevice.comport, default, true);
                SendLog("VID " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": " + usb[0], default, true);
                SendLog("PID " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": " + usb[1], default, true);
            }
            SetProgressBarRunning(false);

            SendLog("Handshaking boot squence... ", default, true);
            try
            {
                using (var serialPort = new SerialPort("COM" + selectedDevice.comport))
                {
                    serialPort.RtsEnable = true;
                    serialPort.DtrEnable = true;
                    serialPort.WriteBufferSize = serialPort.BaudRate;
                    try
                    {
                        serialPort.Open();
                        if (!serialPort.IsOpen)
                        {
                            SendLog("FAIL", Color.Red);
                            return false;
                        }

                        if (!HandshakeMtk(serialPort))
                        {
                            return false;
                        }

                        string hwcode = "";
                        bool secureboot = false;
                        SendLog("Crashing preloader mode... ", default, true);
                        if (preloadermode == true)
                        {
                            if (!CrashPreloader(serialPort))
                            {
                                SendLog("FAIL", Color.Red);
                                return false;
                            }
                            else
                            {
                                SendLog("OK", Color.Green);
                                return true;
                            }
                        }
                        else
                        {
                            SendLog("FAIL", Color.Red);
                            return false;
                        }
                    }

                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        private Form1.comInfo FindNewDevice(List<Form1.comInfo> oldDevices)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                var newDevices = new List<Form1.comInfo>();
                while (true)
                {
                    if (!Form1.busyState)
                    {
                        return null;
                    }
                    if (stopwatch.ElapsedMilliseconds <= 30000L)
                    {
                        if (listDevices.Count == 0 || ReferenceEquals(listDevices, oldDevices))
                        {
                            continue;
                        }
                        newDevices = listDevices.Where((device) => oldDevices.All((oldDevice) => !ReferenceEquals(oldDevice.comport, device.comport))).ToList();
                        if (newDevices.Count > 0)
                        {
                            bool exitWhile = false;
                            foreach (var e in newDevices)
                            {
                                if (e.name.ToUpper().Contains("MEDIATEK") | e.name.ToUpper().Contains("PRELOADER"))
                                {
                                    exitWhile = true;
                                    break;
                                }
                            }

                            if (exitWhile)
                            {
                                break;
                            }
                        }
                        continue;
                    }
                    return null;
                }
                return newDevices[0];
            }
            catch (Exception ex)
            {
                msgBox(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static string trimStrings(string text)
        {
            string[] num = Strings.Split(text.Replace(": ", ":").Replace(" : ", ":"), ":");
            string rim = num[1].Replace(Constants.vbTab, "");
            return rim.Trim();
        }
        public void ProcessNum(double Process)
        {
            ProgressBar.Invoke(new Action(() => ProgressBar.Position = Convert.ToInt32(Process)));
        }
        private List<string> readergpt = new List<string>();
        public DialogResult msgBox(string text, string title = "", MessageBoxButtons button = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None, MessageBoxDefaultButton messageBoxDefaultButton = MessageBoxDefaultButton.Button1)
        {
            try
            {
                var dialog = DialogResult.None;
                if (InvokeRequired)
                {
                    Invoke(new Action(() => dialog = XtraMessageBox.Show(this, text, title, button, icon, messageBoxDefaultButton)));
                }
                else
                {
                    dialog = XtraMessageBox.Show(this, text, title, button, icon, messageBoxDefaultButton);
                }
                return dialog;
            }
            catch (Exception __unusedException__)
            {
                return DialogResult.None;
            }
        }
        private void DiLog(string data, ref string re)
        {
            try
            {
                re += data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!string.IsNullOrEmpty(data) && !string.IsNullOrWhiteSpace(data))
            {


                if (data.Contains("MTK Flash/Exploit Client"))
                {
                    SendLog("OK");
                    SendLog("Вот теперь подключи телефон... ", default, true);
                }


                if (data.Contains("CPU:"))
                {
                    string num = trimStrings(data).ToUpper();
                    SendLog("OK");
                    SendLog("Hardware " + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num, Color.Blue);
                }
                if (data.Contains("SBC enabled:"))
                {
                    string num = trimStrings(data);
                    SendLog("SBC " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    if (Convert.ToBoolean(num))
                        SendLog("YES", Color.Green);
                    else
                        SendLog("NO", Color.Red);
                }
                if (data.Contains("SLA enabled:"))
                {
                    string num = trimStrings(data);
                    SendLog("SLA " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    if (Convert.ToBoolean(num))
                        SendLog("YES", Color.Green);
                    else
                        SendLog("NO", Color.Red);
                }
                if (data.Contains("DAA enabled:"))
                {
                    string num = trimStrings(data);
                    SendLog("DAA " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    if (Convert.ToBoolean(num))
                        SendLog("YES", Color.Green);
                    else
                        SendLog("NO", Color.Red);
                }
                if (data.Contains("ME_ID:"))
                {
                    string num = trimStrings(data);
                    SendLog("MEID " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num, Color.Blue);
                }
                if (data.Contains("Loading payload"))
                {
                    string num = Misc.betweenStrings(data, "payload: ", ",");
                    SendLog("Payload " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num, Color.Blue);
                }
                if (data.Contains("dump preloader."))
                {
                    SendLog("Downloading preloader... ", default, true);
                }
                if (data.Contains("Uploading xflash") | data.Contains("Uploading legacy da"))
                {
                    SendLog("OK", Color.Green);
                    SendLog("Sending DA Loader... ", default, true);
                }
                if (data.Contains("uploaded stage 1") | data.Contains("Legacy DA2 is patch"))
                {
                    SendLog("OK", Color.Green);
                }
                // If data.Contains("Sending emi data ...") Then
                // SendLog("Sending EMI data... ", Nothing, True)
                // End If
                // If data.Contains("Sending emi data succ") Then
                // SendLog("OK", Color.Green)
                // End If
                // If data.Contains("Uploading stage 2") Then
                // SendLog("Loading Stage 2... ", Nothing, True)
                // End If
                // If data.Contains("uploaded stage 2") Then
                // SendLog("OK", Color.Green)
                // End If

                if (data.Contains("Error on DA sync") | data.Contains("Error on sending DA.") | data.Contains("Error on jumping to DA.") | data.Contains("Error jumping to DA:"))
                {
                    SendLog("FAIL", Color.Red);
                }

                if (data.Contains("Progress:"))
                {
                    string num = Misc.betweenStrings(data, "| ", "%");
                    ProcessNum(Convert.ToDouble(num.Replace("%", "")));
                }

                // ' RAM INFO

                if (data.Contains("DRAM Type:"))
                {
                    string num = Misc.betweenStrings(data, "Size: [", "]");
                    string mun = num.Contains("0x") ? Misc.ConvertSize(Misc.ParseString(num)) : null;
                    ramsize = mun;
                }

                #region INDEX
                if (MenuEx == MenuEksekusi.mode1)
                {
                    if (data.Contains("DA Extensions success"))
                    {
                        SendLog(mtkcommand + "... ", default, true);
                    }
                    if (data.Contains("Couldn't detect part"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    // 'ERASE
                    if (data.Contains("Error on format"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Formatted"))
                    {
                        SendLog("OK", Color.Green);
                    }
                    // 'WRITE
                    if (data.Contains("Failed to write"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Wrote"))
                    {
                        SendLog("OK", Color.Green);
                    }
                    // 'READ
                    if (data.Contains("Error on format"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Dumped"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    // 'BL - RL
                    if (data.Contains("has is either already unlocked"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Error on writing seccfg") | data.Contains("Couldn't detect existing seccfg") | data.Contains("Unknown seccfg partition header"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Successfully wrote seccfg"))
                    {
                        SendLog("OK", Color.Green);
                    }
                }
                if (MenuEx == MenuEksekusi.mode2)
                {
                    if (data.Contains("DA Extensions success"))
                    {
                        SendLog(mtkcommand + "... ", default, true);
                    }
                    if (data.Contains("Couldn't detect part"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    // 'ERASE
                    // If data.Contains("Formatting addr:") Then
                    // SendLog($"Erasing : {erasecmd(erasecun)}... ", Nothing, True)
                    // erasecun += 1
                    // End If
                    if (data.Contains("Erasing partition"))
                    {
                        string part = Misc.betweenStrings(data, "Erasing partition \"", "\"");
                        SendLog($"Erasing : " + part + "... ", default, true);
                    }
                    if (data.Contains("Error on format"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Formatted"))
                    {
                        SendLog("OK", Color.Green);
                    }
                    // 'WRITE
                    // If data.Contains("Writing partition") Then
                    // Dim num = Misc.RemoveResponse(data)
                    // Dim num2 = Path.GetFileNameWithoutExtension(num)
                    // SendLog($"Writing : {num2}... ", Nothing, True)
                    // End If
                    if (data.Contains("Writing partition"))
                    {
                        string part = Misc.betweenStrings(data, "Writing partition \"", "\"");
                        SendLog($"Writing : " + part + "... ", default, true);
                    }
                    if (data.Contains("Failed to write"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Wrote"))
                    {
                        SendLog("OK", Color.Green);
                    }
                    // 'READ
                    // If data.Contains("Dumping partition") Then
                    // Dim num = data.Replace(" """, " :""")
                    // Dim num2 = trimStrings(num)
                    // SendLog($"Reading : {num2.Replace("""", "")}... ", Nothing, True)
                    // End If
                    if (data.Contains("Dumping partition"))
                    {
                        string part = Misc.betweenStrings(data, "Dumping partition \"", "\"");
                        SendLog($"Reading : " + part + "... ", default, true);
                    }
                    if (data.Contains("Failed to dump"))
                    {
                        SendLog("FAIL", Color.Red);
                    }
                    if (data.Contains("Dumped"))
                    {
                        SendLog("OK", Color.Green);
                    }
                    // 'RGPT
                    if (data.Contains("Total disk size:"))
                    {
                        ParsingRun();
                    }
                    if (data.Contains("GPT Table:"))
                    {
                        readergpt.Clear();
                    }
                    if (data.Contains("PartName"))
                    {
                        readergpt.Add(data);
                    }
                }
                #endregion

                #region EMMC INFO 1
                if (data.Contains("EMMC ID:"))
                {
                    string num = trimStrings(data);
                    SendLog("Connecting storage... OK", default, true);
                    SendLog("Storage Type " + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog("Embedded multi media card (EMMC)", Color.Blue);

                    if (ramsize is not null)
                    {
                        SendLog("Memory " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                        SendLog("[" + ramsize + "]", Color.Blue);
                    }

                    SendLog("EMMC ID " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num, Color.Blue);
                }
                if (data.Contains("EMMC CID:"))
                {
                    string num = trimStrings(data);
                    SendLog("EMMC CID " + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num.ToUpper(), Color.Blue);
                }
                if (data.Contains("Boot1 Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("Boot1 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("Boot2 Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("Boot2 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("EMMC RPMB Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("RPMB " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("EMMC USER Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("Storage " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                #endregion

                #region EMMC INFO 2
                if (data.Contains("m_emmc_cid:"))
                {
                    string num = trimStrings(data);
                    SendLog("Connecting storage... OK", default, true);
                    SendLog("Storage Type " + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog("Embedded multi media card (EMMC)", Color.Blue);

                    if (ramsize is not null)
                    {
                        SendLog("Memory " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                        SendLog("[" + ramsize + "]", Color.Blue);
                    }

                    SendLog("EMMC CID " + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num.ToUpper(), Color.Blue);
                }
                if (data.Contains("m_emmc_boot1_size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("Boot1 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("m_emmc_boot2_size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("Boot2 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("m_emmc_rpmb_size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("RPMB " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("m_emmc_ua_size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("Storage " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                #endregion

                #region UFS INFO
                if (data.Contains("UFS ID:"))
                {
                    string num = trimStrings(data);
                    SendLog("Connecting storage... OK", default, true);
                    SendLog("Storage Type " + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog("Universal flash storage (UFS)", Color.Blue);

                    if (ramsize is not null)
                    {
                        SendLog("Memory " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                        SendLog("[" + ramsize + "]", Color.Blue);
                    }

                    SendLog("UFS ID " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num, Color.Blue);
                }
                if (data.Contains("UFS CID:"))
                {
                    string num = trimStrings(data);
                    SendLog("UFS CID " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    SendLog(num, Color.Blue);
                }
                if (data.Contains("UFS LU0 Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("LUN0 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("UFS LU1 Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("LUN1 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                if (data.Contains("UFS LU2 Size:"))
                {
                    string num = trimStrings(data);
                    string mun = Misc.ConvertSize(Misc.ParseString(num));
                    SendLog("LUN2 " + Constants.vbTab + Constants.vbTab + Constants.vbTab + ": ", default, true);
                    // SendLog(num, Nothing)
                    SendLog("[" + mun + "]", Color.Blue);
                }
                #endregion

                #region Error
                // If data.Contains("[LIB]:") Then
                // Dim num = trimStrings(data)
                // SendLog("Engine: " & num, Nothing, True)
                // End If
                #endregion
            }
        }
        public byte[] readmtk(int len, SerialPort Ports)
        {
            try
            {
                byte[] data = new byte[len];
                Ports.Read(data, 0, len);
                return data;
            }
            catch (Exception ex)
            {
                // SendLog("Error : " & ex.Message, True)
                return Array.Empty<byte>();
            }
        }

        public void writemtk(byte[] data, SerialPort Ports)
        {
            try
            {
                int len = data.Length;
                Ports.Write(data, 0, len);
            }
            catch (Exception ex)
            {
                // SendLog("Error : " & ex.Message, True)
            }
        }

        public string BytesToHextring(byte[] input)
        {
            return BitConverter.ToString(input).Replace("-", "").ToLower();
        }

        public bool HandshakeMtk(SerialPort Ports)
        {
            preloadermode = false;
            try
            {
                string sequence = "a00a5005";
                string handshake_magic = "5ff5affa";
                string resdata = "";
                string preloader_greet = "READY";
                byte[] a = new byte[] { 0xA0 };
                byte[] b = new byte[1];
                int retry = 0;
                while (true)
                {
                    writemtk(a, Ports);
                    b = readmtk(1, Ports);
                    if (BytesToHextring(b).ToLower() == "5f")
                    {
                        Ports.DiscardInBuffer();
                        Ports.DiscardOutBuffer();
                        resdata += BytesToHextring(b);
                        break;
                    }
                    else
                    {


                    }
                    preloadermode = true;
                    Ports.DiscardInBuffer();
                    Ports.DiscardOutBuffer();
                    retry += 1;

                    if (retry == 10)
                    {
                        SendLog("FAIL", Color.Red);
                        return false;
                    }

                }
                a = new byte[] { 0xA };
                writemtk(a, Ports);
                b = readmtk(1, Ports);
                resdata += BytesToHextring(b);

                a = new byte[] { 0x50 };
                writemtk(a, Ports);
                b = readmtk(1, Ports);
                resdata += BytesToHextring(b);
                a = new byte[] { 0x5 };
                writemtk(a, Ports);
                b = readmtk(1, Ports);
                resdata += BytesToHextring(b);


                if ((resdata.ToLower() ?? "") == (handshake_magic ?? ""))
                {
                    SendLog("OK", Color.Green);
                    return true;
                }
                else if ((resdata.ToLower() ?? "") == (sequence ?? ""))
                {
                    SendLog("OK", Color.Green);
                    return true;
                }
                else
                {
                    SendLog("FAIL", Color.Red);
                    SendLog("Handshake error: " + resdata, Color.Red, true);
                    return false;
                }
            }
            catch (IOException ex)
            {
                return false;
            }
        }
        private void ParsingRun()
        {
            try
            {
                var items = new DataTable();

                string[] columns = new[] { "dg0", "dg1", "dg2", "dg3", "dg4", "dg5", "dg6", "dg7" };
                foreach (string column in columns)
                    items.Columns.Add(column);

                foreach (string init in readergpt.ToArray())
                {
                    string num1 = Misc.betweenStrings(init, "PartName [", "]");
                    string num2 = Misc.betweenStrings(init, "Offset [", "]");
                    string num3 = Misc.betweenStrings(init, "Length [", "]");
                    string num4 = Misc.betweenStrings(init, "Flags [", "]");
                    string num5 = Misc.betweenStrings(init, "UUID [", "]");

                    string size = Misc.ConvertSize(Convert.ToInt64(num3, 16));

                    var dRow = items.NewRow();
                    dRow = items.NewRow();
                    dRow[0] = num1;
                    dRow[1] = "...";
                    dRow[2] = size;
                    dRow[3] = num2;
                    dRow[4] = num3;
                    dRow[5] = num4;
                    dRow[6] = num5;
                    dRow[7] = "...";


                    items.Rows.Add(dRow);
                    items.AcceptChanges();
                }

                if (GridControl5.InvokeRequired)
                {
                    GridControl5.Invoke(new Action(() =>
                    {
                        GridControl5.DataSource = items;
                        GridView5.SelectAll();
                    }));
                }
                else
                {
                    GridControl5.DataSource = items;
                    GridView5.SelectAll();
                }
                if (btnWrite.InvokeRequired)
                {
                    btnWrite.Invoke(new Action(() =>
                    {
                        btnRead.Enabled = true;
                        btnWrite.Enabled = true;
                        btnErase.Enabled = true;
                        btnMtkExit.Enabled = true;
                    }));
                }
                else
                {
                    btnRead.Enabled = true;
                    btnWrite.Enabled = true;
                    btnErase.Enabled = true;
                    btnMtkExit.Enabled = true;
                }

                SendLog("OK", Color.Green);
            }
            catch (Exception ex)
            {
                SendLog("Error: " + ex.GetHashCode(), Color.Red, true);
            }
        }
        private void DumpFUllflashbin(string cmds)
        {
            MenuEx = MenuEksekusi.mode2;
            string cmd = "";
            string cmr = "";
            int wrt = 0;
            if (cmds == "read dump")
            {
                Task.Run(() => DimensitiRun("rf flash.bin"));
            }
        }
        private void ConfigsHeuristic(string cmds)
        {
            MenuEx = MenuEksekusi.mode2;
            string cmd = "";
            string cmr = "";
            int wrt = 0;
            if (cmds == "erase")
            {
                for (int i = 0, loopTo = GridView5.DataRowCount - 1; i <= loopTo; i++)
                {
                    if (GridView5.IsRowSelected(i))
                    {
                        object[] selectedRowValues = Enumerable.Range(1, 8).Select(index => GridView5.GetRowCellValue(i, GridView5.Columns.First(c => c.VisibleIndex == index))).ToArray();

                        cmd += $"{selectedRowValues[0]},";
                        wrt += 1;
                    }
                }

                cmd = cmd.Substring(0, cmd.Length - 1);
                string[] ini = Strings.Split(cmd, ",");
                erasecmd = ini;
                erasecun = 0;

                XtraMessageBox.Show("Please unplug 'usb' connection and 'reconnect' after this message!", "Instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Text = null;
                Task.Run(() => DimensitiRun($" e {cmd}|Erasing partitions"));
            }
            if (cmds == "read")
            {
                var folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = true;
                if (!(folderDlg.ShowDialog() == DialogResult.OK))
                {
                    return;
                }

                for (int i = 0, loopTo1 = GridView5.DataRowCount - 1; i <= loopTo1; i++)
                {
                    if (GridView5.IsRowSelected(i))
                    {
                        object[] selectedRowValues = Enumerable.Range(1, 8).Select(index => GridView5.GetRowCellValue(i, GridView5.Columns.First(c => c.VisibleIndex == index))).ToArray();

                        cmd += $"{selectedRowValues[0]},";
                        cmr += $"\"{Path.Combine(folderDlg.SelectedPath, selectedRowValues[0].ToString() + ".img")}\",";
                        wrt += 1;
                    }
                }

                cmd = cmd.Substring(0, cmd.Length - 1);
                cmr = cmr.Substring(0, cmr.Length - 1);

                cmd = cmd + " " + cmr;
                Thread.Sleep(100);

                XtraMessageBox.Show("Please unplug 'usb' connection and 'reconnect' after this message!", "Instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Text = null;
                Task.Run(() => DimensitiRun($" r {cmd}|Reading partitions"));
            }
            if (cmds == "write")
            {
                for (int i = 0, loopTo2 = GridView5.DataRowCount - 1; i <= loopTo2; i++)
                {
                    if (GridView5.IsRowSelected(i))
                    {
                        object[] selectedRowValues = Enumerable.Range(1, 8).Select(index => GridView5.GetRowCellValue(i, GridView5.Columns.First(c => c.VisibleIndex == index))).ToArray();

                        if (!(selectedRowValues[1].ToString() == "...") | string.IsNullOrEmpty(selectedRowValues[1].ToString()))
                        {
                            cmd += $"{selectedRowValues[0]},";
                            cmr += $"\"{selectedRowValues[7]}\",";
                            wrt += 1;
                        }
                    }
                }

                if (wrt == 0)
                {
                    XtraMessageBox.Show("Please insert images to write", "???", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cmd = cmd.Substring(0, cmd.Length - 1);
                cmr = cmr.Substring(0, cmr.Length - 1);

                cmd = cmd + " " + cmr;
                Thread.Sleep(100);

                XtraMessageBox.Show("Please unplug 'usb' connection and 'reconnect' after this message!", "Instruction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Text = null;
                Task.Run(() => DimensitiRun($" w {cmd}|Writing partitions"));
            }
        }


        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (Form1.busyState)
            {
                return;
            }

            GridView view = GridControl5.MainView as GridView;
            int[] selectedRows = view.GetSelectedRows();
            if (selectedRows.Length == 0)
            {
                XtraMessageBox.Show("Please select partitions to read", "???", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MenuEx = MenuEksekusi.mode2;
            ConfigsHeuristic("read");
        }
        public CancellationTokenSource stop = new CancellationTokenSource();
        private void buttonStop_Click(object sender, EventArgs e)
        {
            utils.Stop = true;
            busyState = false;
            stop.Cancel();
        }

        private void btn_ReadDump_Click(object sender, EventArgs e)
        {
            if (Form1.busyState)
            {
                return;
            }           
            Log.Text = null;
            MenuEx = MenuEksekusi.mode1;
            objJob = "Read flash";
            Task.Run(() => DimensitiRun("rf flash.bin"));
        }

        private void ProcessDumpFile(string sourceFilePath, string destinationFilePath)
        {
            try
            {
                // Вычисляем хеши (используем путь к исходному файлу)
                string md5Hash = CalculateHash(sourceFilePath, "MD5");
                string sha1Hash = CalculateHash(sourceFilePath, "SHA1");                

                // Выводим хеши в лог
                SendLog($"\nMD5: {md5Hash}", Color.Blue);
                SendLog($"\nSHA1: {sha1Hash}", Color.Blue);               

                // Перемещаем файл из Data/emi в Data/Backup и переименовываем его
                File.Move(sourceFilePath, destinationFilePath); // Автоматически переименовывает при перемещении
                SendLog($"\nФайл перемещен в: {destinationFilePath}", Color.Green);                
            }
            catch (Exception ex)
            {
                SendLog($"Ошибка при обработке файла: {ex.Message}", Color.Red);
            }
        }
        private void ProcessDumpFile2(string sourceFilePathkeys, string destinationFilePathkeys)
        {
            try
            {
                // Перемещаем файл из Data/emi в Data/Backup и переименовываем его
                File.Move(sourceFilePathkeys, destinationFilePathkeys); // Автоматически переименовывает при перемещении
                SendLog($"\nФайл перемещен в: {destinationFilePathkeys}", Color.Green);
            }
            catch (Exception ex)
            {
                SendLog($"Ошибка при обработке файла: {ex.Message}", Color.Red);
            }
        }

        private string CalculateHash(string filePath, string algorithm)
        {
            using (var stream = File.OpenRead(filePath))
            {
                using (var hash = HashAlgorithm.Create(algorithm))
                {
                    if (hash == null)
                    {
                        throw new ArgumentException("Invalid hash algorithm: " + algorithm);
                    }
                    var hashBytes = hash.ComputeHash(stream);
                    return BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Преобразуем в строку
                }
            }
        }

        private void buttonVerifyDump_Click(object sender, EventArgs e)
        {
            
            string sourceFilePath = Path.Combine(Application.StartupPath, "data", "emi", "flash.bin");
            string sourceFilePathkeys = Path.Combine(Application.StartupPath, "data", "emi", "logs", "hwparam.json");
            string destinationFilePath = Path.Combine(Application.StartupPath, "data", "Backup", "userdata.bin"); // Имя изменено на userdata.bin
            string destinationFilePathkeys = Path.Combine(Application.StartupPath, "data", "Backup", "keys.json");

            if (File.Exists(sourceFilePath))
            {
                ProcessDumpFile(sourceFilePath, destinationFilePath);
                ProcessDumpFile2(sourceFilePathkeys, destinationFilePathkeys);
            }
            else
            {
                SendLog("Файл flash.bin не найден, точно делал копию?", Color.Red);
            }
        }

        private async void btnReadHardwareKeys_Click(object sender, EventArgs e)
        {
            if (Form1.busyState)
            {
                return;
            }

            Log.Text = null;
            MenuEx = MenuEksekusi.mode1;
            objJob = "Generate Keys";

            Form1.busyState = true; // Устанавливаем флаг занятости
            ToggleButtonsEnabled(); // Блокируем кнопки

            try
            {
                await Task.Run(() => DimensitiRun("da generatekeys")); // Запускаем DimensitiRun асинхронно и ждем завершения
                await ReadHwparamJsonAsync(); // Запускаем ReadHwparamJsonAsync только после завершения DimensitiRun
            }
            finally
            {
                Form1.busyState = false; // Снимаем флаг занятости
                ToggleButtonsEnabled(false); // Разблокируем кнопки
            }
        }

        private async Task ReadHwparamJsonAsync()
        {
            string filePath = Path.Combine(Application.StartupPath, "data", "emi", "Logs", "hwparam.json");

            if (File.Exists(filePath))
            {
                try
                {
                    string jsonContent = await ReadFileAsync(filePath); // Используем нашу функцию для чтения

                    // Обращаемся к SendLog через Invoke, так как Task.Run выполняется не в потоке UI
                    if (InvokeRequired)
                    {
                        Invoke((MethodDelegate)delegate
                        {
                            SendLog("\nСодержимое hardware keys:", Color.Blue);
                            SendLog(jsonContent, Color.Black);
                        });
                    }
                    else
                    {
                        SendLog("\nСодержимое hardware keys:", Color.Blue);
                        SendLog(jsonContent, Color.Black);
                    }
                }
                catch (Exception ex)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodDelegate)delegate
                        {
                            SendLog($"\nОшибка при чтении файла hardware keys:: {ex.Message}", Color.Red);
                        });
                    }
                    else
                    {
                        SendLog($"\nОшибка при чтении файла hardware keys:: {ex.Message}", Color.Red);
                    }
                }
            }
            else
            {
                if (InvokeRequired)
                {
                    Invoke((MethodDelegate)delegate
                    {
                        SendLog("Неизвестная ошибка!", Color.Red);
                    });
                }
                else
                {
                    SendLog("Неизвестная ошибка!", Color.Red);
                }
            }
        }
        private async Task<string> ReadFileAsync(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        //Делегат для Invoke
        delegate void MethodDelegate();

        private void btnErase_Click(object sender, EventArgs e)
        {
            if (Form1.busyState)
            {
                return;
            }

            GridView view = GridControl5.MainView as GridView;
            int[] selectedRows = view.GetSelectedRows();
            if (selectedRows.Length == 0)
            {
                XtraMessageBox.Show("Please select partitions to erase", "???", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MenuEx = MenuEksekusi.mode2;
            ConfigsHeuristic("erase");
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (Form1.busyState)
            {
                return;
            }

            GridView view = GridControl5.MainView as GridView;
            int[] selectedRows = view.GetSelectedRows();
            if (selectedRows.Length == 0)
            {
                XtraMessageBox.Show("Please select partitions to write", "???", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MenuEx = MenuEksekusi.mode2;
            ConfigsHeuristic("write");
        }

        private void btn_emichoose_Click(object sender, EventArgs e)
        {
            if (!chkEMI.Checked)
            {
                return;
            }
            var FD = new OpenFileDialog();
            FD.Title = "Preloader | EMI/BIN";
            FD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            FD.FileName = "";
            FD.Filter = "bin (*.bin)|*.bin";
            FD.RestoreDirectory = true;

            if (FD.ShowDialog() == DialogResult.OK)
            {
                txtEMI.Tag = "?";
                txtEMI.Tag = FD.FileName;
                txtEMI.Text = null;
                txtEMI.Text = Path.GetFileName(FD.FileName).ToString();
            }
        }
    }
}
