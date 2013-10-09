using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace SolarSystem
{
    class OrbitsCalculator : INotifyPropertyChanged
    {
        private DateTime _startTime;
        private DispatcherTimer _timer;

        // changes
        private double days = 0;
        private double earthRotationAngle = 0;

        const double EarthYear = 365.25;
        const double EarthRotationPeriod = 1.0;
        const double SunRotationPeriod = 25.0;
        const double TwoPi = Math.PI * 2;

        private double _daysPerSecond = 2;
        public double DaysPerSecond
        {
            get { return _daysPerSecond; }
            set { _daysPerSecond = value; Update("DaysPerSecond"); }
        }

        public double EarthOrbitRadius { get { return 40; } set { } }
        public double Days { get; set; }
        public double EarthRotationAngle { get; set; }
        public double SunRotationAngle { get; set; }
        public double EarthOrbitPositionX { get; set; }
        public double EarthOrbitPositionY { get; set; }
        public double EarthOrbitPositionZ { get; set; }
        public bool ReverseTime { get; set; }
        public bool Paused { get; set; }

        public OrbitsCalculator()
        {
            EarthOrbitPositionX = EarthOrbitRadius;
            DaysPerSecond = 2;
        }

        public void StartTimer()
        {
            _startTime = DateTime.Now;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += new EventHandler(OnTimerTick);
            _timer.Start();
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Tick -= OnTimerTick;
            _timer = null;
        }

        public void Pause(bool doPause)
        {
            if (doPause)
            {
                StopTimer();
            }
            else
            {
                StartTimer();
            }
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            // Changed Days to days
            days += (now - _startTime).TotalMilliseconds * DaysPerSecond / 1000.0 * (ReverseTime ? -1 : 1);
            _startTime = now;
            // The property get's the value just once - faster
            Days = days;
            Update("Days");
            OnTimeChanged();
        }

        private void OnTimeChanged()
        {
            EarthPosition();
            EarthRotation();
            SunRotation();
        }

        private void EarthPosition()
        {
            // Days changed to days
            double angle = 2 * Math.PI * days / EarthYear;
            EarthOrbitPositionX = EarthOrbitRadius * Math.Cos(angle);
            EarthOrbitPositionY = EarthOrbitRadius * Math.Sin(angle);
            Update("EarthOrbitPositionX");
            Update("EarthOrbitPositionY");
        }

        private void EarthRotation()
        {
            // changes
            double step;
            const int loopLen = 360;
            const double upgrade = 0.00005;
            for (step = 0; step <= loopLen; step += upgrade)
            {
                earthRotationAngle = step * days;
                earthRotationAngle /= EarthRotationPeriod;
            }
            // The property get's the value just once - faster
            EarthRotationAngle = earthRotationAngle;
            Update("EarthRotationAngle");
        }

        private void SunRotation()
        {
            // Days changed to days
            SunRotationAngle = 360 * days / SunRotationPeriod;
            Update("SunRotationAngle");
        }

        private void Update(string propertyName)
        {
            if (PropertyChanged != null)
            {
                var args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
