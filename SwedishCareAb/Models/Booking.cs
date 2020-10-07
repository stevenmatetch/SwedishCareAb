using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace SwedishCareAb.Models
{
    public class Booking : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }

        private int _status { get; set; }
        public Booking()
        {

        }
        public int Status
        {
            get { return _status; }
            set
            {
               
                _status = value;
                NotifyPropertyChanged("Status");
                NotifyPropertyChanged("GetStatusText");
                NotifyPropertyChanged("ShowPicture");


            }
        }
        public int Statuss
        {
            get { return Status; }
            set
            {
                
                Status = value;
                NotifyPropertyChanged("Statuss");
            }
        }
        public string GetStatusText
        {

            get
            {

                switch (Status)
                {
                    case 10:
                        return "Bokad";
                    case 20:
                        return "Ankomstregistrerad";
                    case 23:
                        return "Ankomstregistrerad";
                    case 26:
                        return "Ankomstregistrerad";
                    case 30:
                        return "Ankomstregistrerad";
                    case 40:
                        return "Kontakta reception";
                    case 50:
                        return "Kontakta reception";
                    case 60:
                        return "Kontakta reception";
                    case 70:
                        return "Kontakta reception";
                    default:
                        return "";
                }

            }


        }
       
        public Visibility ShowPicture
        {
            get
            {
                if (Status == 10)
                {
                    return Visibility.Collapsed;
                }
                else if (Status >= 20 && Status <= 30)
                {
                    return Visibility.Visible;
                }


                else if (Status > 40)
                {
                    return Visibility.Collapsed;
                }
                return (Visibility)Status;



            }
           
        }
     

        public string Foreground
        {
           
            get
            {

                if (Status > 40)
                {
                    return "#808080";
                }
                else
                {
                    return "#000000";
                }

          
            }
        }

        public bool EnableRegistrera
        {
            get
            {
                if (Status == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;

        public Booking(int id, DateTime date, string description, int status, Company company)
        {
            ID = id;
            Description = description;
            Date = date;
            Status = status;
         
            Company = company;
        }
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }
 

        public string summary

        {
            get { return Date.ToString("yyyy-MM-dd    HH:mm:ss") + "    " + Description; }
        }
    }
}
