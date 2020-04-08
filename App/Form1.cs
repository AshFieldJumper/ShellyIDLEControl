using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.Properties;
using Newtonsoft.Json;

namespace App
{
    public partial class Form1 : Form
    {
        private int time = 1000;
        private static string host;
        private static bool hostStatus;
        private bool idle = false;
        private bool canReadPower = true;

        public Form1()
        {
            InitializeComponent();

            ipInput.Text = getSettings("ip");
            idleTime.Text = getSettings("time");
        }

        private string getSettings(string key)
        {
            if (Settings.Default[key] != null)
            {
                return Properties.Settings.Default[key].ToString();
            }

            return "";
        }

        private void CheckIdleTimer_Tick(object sender, System.EventArgs e)
        {
            uint idleTime = Win32.GetIdleTime();
            Console.WriteLine(idleTime);
            if (canReadPower)
            {
                getPower();
            }

            if (hostStatus)
            {
                shellyStatus.BackColor = Color.Green;
                if (idleTime > time && !idle)
                {
                    //Win32.LockWorkStation();
                    controlShelly("off");
                    idle = true;
                }
                else if (idleTime < time && idle)
                {
                    controlShelly("on");
                    idle = false;
                }
            }
            else
            {
                stop();
            }
        }

        private void controlShelly(string turn)
        {
            using (var client = new WebClient())
            {
                var responseString = client.DownloadString("http://" + host + "/relay/0?turn=" + turn);
                if (responseString == null)
                {
                    hostStatus = false;
                }
            }
        }

        private void getPower()
        {
            using (var client = new WebClient())
            {
                try
                {
                    var responseString = client.DownloadString("http://" + host + "/meter/0");
                    if (responseString != null)
                    {
                        dynamic input = JsonConvert.DeserializeObject(responseString);
                        power.Text = input.power + "W";
                    }
                }
                catch (Exception)
                {
                    power.Text = "Not supported";
                    canReadPower = false;
                }
            }
        }

        private void idleTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            stop();

            int newTime = Convert.ToInt16(idleTime.Text);
            host = ipInput.Text;
            time = newTime * 1000;
            var ping = Task.Factory.StartNew(() => Pinger(host));
            ping.Wait();
            hostStatus = ping.Result;
            if (!hostStatus)
            {
                stop();
                status.Text = "Cannot resolve IP";

            }
            else
            {
                Settings.Default["ip"] = host;
                shellyStatus.BackColor = Color.Green;
                execute.Enabled = true;
                status.Text = "Ready to start!";
            }
            Settings.Default["time"] = newTime;
            Settings.Default.Save();
        }

        public bool Pinger(string ip, int bufferSize = 32)
        {
            Ping ping = new Ping();
            byte[] buffer = new byte[bufferSize];
            PingOptions pingOpt = new PingOptions(64, true);

            try
            {
                PingReply pingReply = ping.Send(ip, 100, buffer, pingOpt);

                if (pingReply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void execute_Click(object sender, EventArgs e)
        {
            if (CheckIdleTimer.Enabled)
            {
                stop();
            }
            else
            {
                if (host != "" && hostStatus)
                {
                    status.Text = "Running...";

                    Console.WriteLine("Timer started");
                    CheckIdleTimer.Start();
                    execute.Text = "Stop";
                }
                else
                {
                    status.Text = "ERROR";
                }
            }
        }
        private void stop()
        {
            status.Text = "Stopped";
            canReadPower = true;
            power.Text = "--";
            CheckIdleTimer.Stop();
            execute.Text = "Start";
        }
    }
}
