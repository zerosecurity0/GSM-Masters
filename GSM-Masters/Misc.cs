using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using RestSharp;

namespace GSM_Masters.mtkclient.gui
{

    public class Misc
    {
        private static readonly Random random = new Random();
        internal static string netorare = "1$1#zZ$2y$10$39Cd0h7s47psBvadc3pvfO0fjIrpj26uGR1Nwti0oOQhLbsU34KZ6"; // "1$1#zZ$2y$10$39Cd0h7s47psBvadc3pvfO0fjIrpj26uGR1Nwti0oOQhLbsU34KZ6"

        

       
        public static byte[] StringByteToArrayByte(string byteString)
        {
            byte[] byteArray = new byte[(byteString.Length / 2)];

            for (int i = 0, loopTo = byteString.Length - 1; i <= loopTo; i += 2)
                byteArray[i / 2] = byte.Parse(byteString.Substring(i, 2), NumberStyles.HexNumber);

            return byteArray;
        }

        public static string ExtractSubstring(string source, string startDelimiter, string endDelimiter)
        {
            if (!source.Contains(startDelimiter))
            {
                return string.Empty;
            }
            if (!source.Contains(endDelimiter))
            {
                return string.Empty;
            }
            int startIndex = source.IndexOf(startDelimiter) + startDelimiter.Length;
            int endIndex = source.IndexOf(endDelimiter, startIndex);
            if (endIndex == -1)
            {
                return "";
            }
            if (string.IsNullOrEmpty(endDelimiter))
            {
                return source.Substring(startIndex);
            }
            return source.Substring(startIndex, endIndex - startIndex);
        }

        public static double ParseString(string hexNumber)
        {
            hexNumber = hexNumber.Replace("x", string.Empty);
            long result;
            long.TryParse(hexNumber, NumberStyles.HexNumber, null, out result);
            return result;
        }

        public static string betweenStrings(string text, string start, string end)
        {
            int num = text.IndexOf(start) + start.Length;
            int num2 = text.IndexOf(end, num);
            if (Equals(end, ""))
            {
                return text.Substring(num);
            }
            return text.Substring(num, num2 - num);
        }

        public static string ConvertSize(double value)
        {
            string[] strArray = new string[9] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double dblSByte = value;
            int i;
            i = 0;

            while (i < strArray.Length && value >= 1024d)
            {
                dblSByte = value / 1024.0d;
                i += 1;
                value /= 1024d;
            }
            return string.Format("{0:0} {1}", dblSByte, strArray[i]);
        }

        public static string ConvertByte(double value)
        {
            string[] strArray = new string[9] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double dblSByte = value;
            int i;
            i = 0;

            while (i < strArray.Length && value >= 1024d)
            {
                dblSByte = value / 1024.0d;
                i += 1;
                value /= 1024d;
            }
            return string.Format("{0:0}", dblSByte);
        }

        public static string GenerateRandomString(int stringLength)
        {
            return new string((from randomChar in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", stringLength)
                               select randomChar[random.Next(randomChar.Length)]).ToArray());
        }

        public static string NormalizeSearchTerm(string searchTerm)
        {
            var regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string input = searchTerm.Normalize(NormalizationForm.FormD);
            return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
        }

        public static byte[] ReplaceBytes(byte[] source, byte[] findBytes, byte[] replaceByte)
        {
            byte[] result = null;
            int index = IndexOfBytes(source, findBytes);

            if (index >= 0)
            {
                result = new byte[(source.Length - findBytes.Length + replaceByte.Length)];
                Buffer.BlockCopy(source, 0, result, 0, index);
                Buffer.BlockCopy(replaceByte, 0, result, index, replaceByte.Length);
                Buffer.BlockCopy(source, index + findBytes.Length, result, index + replaceByte.Length, source.Length - (index + findBytes.Length));
            }

            return result;
        }

        public static int IndexOfBytes(byte[] source, byte[] findBytes)
        {
            int result = -1;
            int currentIndex = 0;

            for (int i = 0, loopTo = source.Length - 1; i <= loopTo; i++)
            {
                if (source[i] == findBytes[currentIndex])
                {
                    if (currentIndex == findBytes.Length - 1)
                    {
                        result = i - currentIndex;
                        break;
                    }
                    currentIndex += 1;
                }
                else
                {
                    currentIndex = source[i] == findBytes[0] ? 1 : 0;
                }
            }

            return result;
        }

        public static bool CheckFilesMatch(string filePath1, string filePath2)
        {
            using (var fileStream1 = new FileStream(filePath1, FileMode.Open))
            {
                using (var fileStream2 = new FileStream(filePath2, FileMode.Open))
                {
                    return CompareStreams(fileStream1, fileStream2);
                }
            }
        }

        private static bool CompareStreams(Stream stream1, Stream stream2)
        {
            var buffer1 = new byte[2048];
            var buffer2 = new byte[2048];
            int bytesRead1;
            int bytesRead2;

            do
            {
                bytesRead1 = stream1.Read(buffer1, 0, 2048);
                bytesRead2 = stream2.Read(buffer2, 0, 2048);

                if (bytesRead1 == bytesRead2)
                {
                    if (bytesRead1 == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            while (buffer1.Take(bytesRead1).SequenceEqual(buffer2.Take(bytesRead2)));

            return false;
        }


        public static void CreateZeroFilledFile(string filePath)
        {
            int fileSize = 524288;
            var fileContent = new byte[fileSize];

            for (int i = 0, loopTo = fileContent.Length - 1; i <= loopTo; i++)
                fileContent[i] = 0;

            using (var fileStream = File.Create(filePath))
            {
                fileStream.Write(fileContent, 0, fileContent.Length);
            }
        }

        public static string[] VID(string stream)
        {
            string[] array = new string[2];
            int num = stream.IndexOf("VID_");
            string text = stream.Substring(num + 4);
            array[0] = text.Substring(0, 4);
            int num2 = stream.IndexOf("PID_");
            string text2 = stream.Substring(num2 + 4);
            array[1] = text2.Substring(0, 4);
            return array;
        }

        public static string RemoveResponse(string cmd)
        {
            return cmd.Replace("DA_handler - Writing partition: ", "");
        }


        // LG

        public static string BytesToString(long byteCount)
        {
            string[] array = new string[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0L)
            {
                return "0" + array[0];
            }
            long num = Math.Abs(byteCount);
            int num2 = Convert.ToInt32(Math.Floor(Math.Log(num, 1024.0d)));
            double num3 = Math.Round(num / Math.Pow(1024.0d, num2), 1);
            return Math.Sign(byteCount) * num3 + array[num2];
        }

        public static string extractATResponse(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            if (!text.Contains('\u0002'.ToString()) || !text.Contains('\u0003'.ToString()))
            {
                return null;
            }
            int num = text.IndexOf('\u0002'.ToString()) + '\u0002'.ToString().Length;
            int num2 = text.IndexOf('\u0003'.ToString(), num);
            return text.Substring(num, num2 - num);
        }

        public static string[] extractDeviceID(string hwid)
        {
            var array = new string[2];
            int num = hwid.IndexOf("VID_");
            string text = hwid.Substring(num + 4);
            array[0] = text.Substring(0, 4);
            int num2 = hwid.IndexOf("PID_");
            string text2 = hwid.Substring(num2 + 4);
            array[1] = text2.Substring(0, 4);
            return array;
        }
    }
}