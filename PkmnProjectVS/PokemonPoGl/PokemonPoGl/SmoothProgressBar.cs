using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

namespace smoothBar
{
    class SmoothProgressBar : ProgressBar
    {
        public bool ShouldBlink { get; set; }
        private readonly Timer _drawTimer;
        private double _speed;

        private new double Value;

        public double SmoothValue
        {
            get => Value;
            set
            {
                if (Value > 1000)
                {
                    Value = 1000;
                }
                else if (Value < 0)
                {
                    Value = 0;
                }
                else
                {
                    Value = value;
                }
            }
        }


        public double Acceleration { get; set; }

        public SmoothProgressBar()
        {
            _drawTimer = new Timer();
            _drawTimer.Elapsed += OnTimerEvent;

            // 25 Fps für Timer verwenden
            _drawTimer.Interval = 40;
            _drawTimer.Enabled = true;

            ShouldBlink = false;
            _speed = 0;
            Acceleration = 0.5;
            Value = 1000;
        }

        public void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            // Dispatcher aufrufen um an STA-Thread von wpf zu gelangen
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
            {
                if (Value != base.Value)
                {
                    // beliebiges maximum normalisieren
                    double faktor = 1 / Maximum;
                    // position auf Interval von 0-1 berechnen
                    double position = faktor * base.Value;

                    // Minimum berechnen zwischen beschleunigter und negativ beschleunigter Bewegung
                    // parameter 1: v = a*t
                    // parameter 2: v = sqrt(2*Bremsweg*a)
                    _speed = Math.Min(_speed + Acceleration * (_drawTimer.Interval / 1000),
                        Math.Sqrt(2 * Math.Abs((faktor * Value) - position) * Acceleration));

                    // Nach rechts oder Links bewegen. s = v * t
                    if (Value > base.Value)
                    {
                        position += (_drawTimer.Interval / 1000) * _speed;
                        base.Value = Math.Min(position / faktor, Value);
                    }
                    else
                    {
                        position -= (_drawTimer.Interval / 1000) * _speed;
                        base.Value = Math.Max(position / faktor, Value);
                    }
                }
            });
        }
    }
}