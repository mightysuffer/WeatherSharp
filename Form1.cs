using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace coursa42
{
    public partial class Form1 : Form
    {
        const string APPID = "799d0d6ae05187b7cc9d5acfeb87c175";
        string cityName = "Moscow";
        int day = 2;
        public Form1()
        {
            InitializeComponent();
            GetWeather(cityName);
            GetForecast(cityName);
        }
        void GetWeather(string cityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid=799d0d6ae05187b7cc9d5acfeb87c175&cnt=6", cityName, APPID);

                try
                {
                    var json = web.DownloadString(url);
                    weaterInfo.root wi = JsonConvert.DeserializeObject<weaterInfo.root>(json);
                    weaterInfo.root output = wi;

                        lbl_cityName.Text = string.Format("{0}", output.name);
                        lbl_country.Text = string.Format("{0}", output.sys.country);
                        lbl_Temp.Text = string.Format("{0}", output.main.temp);
                        weatherIcon.BackgroundImage = setIcon(output.weather[0].icon);
                        lbl_descr.Text = string.Format("{0}", output.weather[0].description);
                }
                catch
                {
                    MessageBox.Show("City not found.");
                }
                

            }
            
        }
        void GetForecast(string cityName)
        {
            
            {
                try
                {
                    int days = day + 1;
                    string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&appid=799d0d6ae05187b7cc9d5acfeb87c175&cnt={1}", cityName, days);
                    using (WebClient web = new WebClient())
                    {
                        var json = web.DownloadString(url);
                        var Object = JsonConvert.DeserializeObject<weatherForecast>(json);
                        weatherForecast forecast = Object;

                        //tommorow forecast
                        lbl_cond2.Text = string.Format("{0}", forecast.list[1].weather[0].main);
                        lbl_describe2.Text = string.Format("{0}", forecast.list[1].weather[0].description);
                        lbl_tempday2.Text = string.Format("{0}", forecast.list[1].temp.day);
                        lbl_tempmor2.Text = string.Format("{0}", forecast.list[1].temp.morn);
                        lbl_tempeve2.Text = string.Format("{0}", forecast.list[1].temp.eve);
                        lbl_windspeed2.Text = string.Format("{0}", forecast.list[1].speed);
                        lbl_day2.Text = string.Format("{0}", getDate(forecast.list[1].dt).DayOfWeek);
                        date2.Text = string.Format("{0}", getDate(forecast.list[1].dt).Date);
                        weatherIcon23.BackgroundImage = setIcon(forecast.list[1].weather[0].icon);

                        //3rd day forecast
                        lbl_cond3.Text = string.Format("{0}", forecast.list[day].weather[0].main);
                        lbl_describe3.Text = string.Format("{0}", forecast.list[day].weather[0].description);
                        lbl_tempday3.Text = string.Format("{0}", forecast.list[day].temp.day);
                        lbl_tempmor3.Text = string.Format("{0}", forecast.list[day].temp.morn);
                        lbl_tempeve3.Text = string.Format("{0}", forecast.list[day].temp.eve);
                        lbl_windspeed3.Text = string.Format("{0}", forecast.list[day].speed);
                        lbl_day3.Text = string.Format("{0}", getDate(forecast.list[day].dt).DayOfWeek);
                        date3.Text = string.Format("{0}", getDate(forecast.list[day].dt).Date);
                        weatherIcon33.BackgroundImage = setIcon(forecast.list[day].weather[0].icon);
                    }
                }
                catch
                {
                    MessageBox.Show("City not found.");
                }
            }

        }


        // millisecound to DateTime methode
        DateTime getDate(double millisecound)
        {

            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecound).ToLocalTime();

            return day;
        }

        Image setIcon (string iconID)
        {
            string url = string.Format("http://openweathermap.org/img/w/{0}.png", iconID); 
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
                using (var weatherIcon = response.GetResponseStream())
            {
                Image weatherImg = Bitmap.FromStream(weatherIcon);
                return weatherImg;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_day2_Click(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            if (city_name.Text != "");
            {
                var CITYNAME = city_name.Text;
                bool result = false;
                if (Regex.IsMatch(CITYNAME, (@"^[a-zA-Zа-яА-я-]+$")))
                {
                    result = true;
                }               
               if (result)
                {
                    GetWeather(CITYNAME);
                    GetForecast(CITYNAME);
                }
                else
                {
                    MessageBox.Show("Данные введены неправильно.");
                }
            }
        }


        private void lbl_describe2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            day = 0;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            day = 1;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            day = 2;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            day = 3;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            day = 4;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            day = 5;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            day = 6;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            day = 7;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            day = 8;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            day = 9;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            day = 10;
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            day = 11;
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            day = 12;
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            day = 13;
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            day = 14;
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            day = 15;
        }

        private void date2_Click(object sender, EventArgs e)
        {

        }
    }
}
