using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfApp1Tema2___Checkers__New_.View_Models
{
    internal class StatisticsWindowViewModel
    {
        public int redWon { get; set; }
        public int blackWon { get; set; }

        public StatisticsWindowViewModel()
        {
            InitializeStatisticsFromXml();
        }

        private void InitializeStatisticsFromXml()
        {
            try
            {
                //please fix so its not the full path
                XDocument doc = XDocument.Load("D:\\Facultate\\MAP\\Teme\\Tema2 - Checkers\\WPF.NET-Checkers\\WpfApp1Tema2 - Checkers (New)\\WpfApp1Tema2 - Checkers (New)\\Inputs\\GameStatistics.xml");

                redWon = int.Parse(doc.Element("GameStatistics").Element("RedWins").Value);
                blackWon = int.Parse(doc.Element("GameStatistics").Element("BlackWins").Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing statistics from XML: " + ex.Message);
                redWon = 0;
                blackWon = 0;
            }
        }
    }
}
