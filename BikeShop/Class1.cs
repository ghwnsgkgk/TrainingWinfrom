using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;

namespace BikeShop
{
    public class Human
    {
        public string FirstName { get; set; }
        public bool HasDrivingLicense { get; set; }
    }
    
    public class Car : Notifier
    {
        private double speed;
        public Color color;
        public double Speed
        {
            get
            {return speed;}
            set
            {speed = value; OnPropertyChanged("Speed"); }  //속성값이 변경되는 것을 클라이언트 시스템에 통보해주는 역할 
        }
        public Color Color { get; set; }
        public Human Driver { get; set; }
    }
}
