using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carmotub.Views.Controls
{
    public partial class Calendar : UserControl
    {
        public DateTime CurrentDate { get; set; }
        public Calendar()
        {
            InitializeComponent();
            InitialiseScheduler();
        }

        private void InitialiseScheduler()
        {
            /*CurrentDate = DateTime.Now;
            SelectMonth(CurrentDate.Month);

            scheduler1.SelectedDate = CurrentDate;
            scheduler1.Events.Add(new Event() { Start = DateTime.Now.AddDays(1),End = DateTime.Now.AddDays(1), Color = new SolidColorBrush(Color.FromArgb(255,205,230,247)),Subject = "Client blablabla" });
            scheduler1.Events.Add(new Event() { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1), Color = new SolidColorBrush(Color.FromArgb(255, 205, 230, 247)), Subject = "Client blablabla" });
            scheduler1.Events.Add(new Event() { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1), Color = new SolidColorBrush(Color.FromArgb(255, 205, 230, 247)), Subject = "Client blablabla" });
            scheduler1.Events.Add(new Event() { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1), Color = new SolidColorBrush(Color.FromArgb(255, 205, 230, 247)), Subject = "Client blablabla" });
            scheduler1.Events.Add(new Event() { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1), Color = new SolidColorBrush(Color.FromArgb(255, 205, 230, 247)), Subject = "Client blablabla" });
            scheduler1.Events.Add(new Event() { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(1), Color = new SolidColorBrush(Color.FromArgb(255, 205, 230, 247)), Subject = "Client blablabla" });*/
        }

        /*private void scheduler1_OnEventDoubleClick(object sender, Event ev)
        {

        }

        private void scheduler1_OnScheduleDoubleClick(object sender, DateTime ev)
        {

        }*/

        private void SelectMonth(int month)
        {
            switch (month)
            {
                case 1:
                    CurrentMonthAndYear.Text = "Janvier " + CurrentDate.Year;
                    break;

                case 2:
                    CurrentMonthAndYear.Text = "Février " + CurrentDate.Year;
                    break;

                case 3:
                    CurrentMonthAndYear.Text = "Mars " + CurrentDate.Year;
                    break;

                case 4:
                    CurrentMonthAndYear.Text = "Avril " + CurrentDate.Year;
                    break;

                case 5:
                    CurrentMonthAndYear.Text = "Mai " + CurrentDate.Year;
                    break;

                case 6:
                    CurrentMonthAndYear.Text = "Juin " + CurrentDate.Year;
                    break;

                case 7:
                    CurrentMonthAndYear.Text = "Juillet " + CurrentDate.Year;
                    break;

                case 8:
                    CurrentMonthAndYear.Text = "Août " + CurrentDate.Year;
                    break;

                case 9:
                    CurrentMonthAndYear.Text = "Septembre " + CurrentDate.Year;
                    break;

                case 10:
                    CurrentMonthAndYear.Text = "Octobre " + CurrentDate.Year;
                    break;

                case 11:
                    CurrentMonthAndYear.Text = "Novembre " + CurrentDate.Year;
                    break;

                case 12:
                    CurrentMonthAndYear.Text = "Décembre " + CurrentDate.Year;
                    break;
            }
        }

        private void AddMonth_Click(object sender, RoutedEventArgs e)
        {
            /*CurrentDate = CurrentDate.AddMonths(1);
            scheduler1.SelectedDate = CurrentDate;

            SelectMonth(CurrentDate.Month);*/
        }

        private void RemoveMonth_Click(object sender, RoutedEventArgs e)
        {
            /*CurrentDate = CurrentDate.AddMonths(-1);
            scheduler1.SelectedDate = CurrentDate;

            SelectMonth(CurrentDate.Month);*/
        }
        
    }
}
