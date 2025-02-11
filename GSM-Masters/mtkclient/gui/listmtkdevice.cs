using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GSM_Masters.mtkclient.gui
{
    public class listmtkdevice
    {
        public static string Brand { get; set; }
        public static string DevicesName { get; set; }
        public static string ModelName { get; set; }
        public static string Platform { get; set; }
        public class Info
        {
            public string Devices { get; set; }
            public string Models { get; set; }
            public string Platform { get; set; }
            public string Conn { get; set; }
            public string Broom { get; set; }
            public string New { get; set; }

            public Info(
                string Devices,
                string Models,
                string Platform,
                string Conn,
                string Broom,
                string New
            )
            {
                this.Devices = Devices;
                this.Models = Models;
                this.Platform = Platform;
                this.Conn = Conn;
                this.Broom = Broom;
                this.New = New;
            }
        }

        public static List<Info> DataSource(string path)
        {
            Devicelists = (List<Info>)JsonConvert.DeserializeObject<List<Info>>(path);
            List<Info> lists = new List<Info>();
            lists.Clear();

            foreach (Info inf in Devicelists)
            {
                lists.Add(
                    new Info(inf.Devices, inf.Models, inf.Platform, inf.Conn, inf.Broom, inf.New)
                );
            }

            return lists;
        }

        public static List<Info> Devicelists = new List<Info>();
    }
}
