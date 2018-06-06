using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

// ReSharper disable once CheckNamespace
namespace smoothBar
{
    internal class SmoothProgressBar : ProgressBar
    {
        private readonly Timer _drawTimer;
        private double _speed;
        public double Acceleration { get; set; }

        // ReSharper disable once InconsistentNaming
        private new double Value;
        public double SmoothValue
        {
            get => Value;
            set
            {
                if (Value > 1000)
                    Value = 1000;
                else if (Value < 0)
                    Value = 0;
                else
                    Value = value;
            }
        }
        public SmoothProgressBar()
        {
            _drawTimer = new Timer();
            _drawTimer.Elapsed += OnTimerEvent;

            // 25 Fps für Timer verwenden
            _drawTimer.Interval = 40;
            _drawTimer.Enabled = true;

            _speed = 0;
            Acceleration = 0.5;
        }




        public void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            // Dispatcher aufrufen um an STA-Thread von wpf zu gelangen
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
            {
                if (Math.Abs(Value - base.Value) > 0)
                {
                    // beliebiges maximum normalisieren
                    var faktor = 1 / Maximum;
                    // position auf Interval von 0-1 berechnen
                    var position = faktor * base.Value;

                    // Minimum berechnen zwischen beschleunigter und negativ beschleunigter Bewegung
                    // parameter 1: v = a*t
                    // parameter 2: v = sqrt(2*Bremsweg*a)
                    _speed = Math.Min(_speed + Acceleration * (_drawTimer.Interval / 1000),
                        Math.Sqrt(2 * Math.Abs(faktor * Value - position) * Acceleration));

                    // Nach rechts oder Links bewegen. s = v * t
                    if (Value > base.Value)
                    {
                        position += _drawTimer.Interval / 1000 * _speed;
                        base.Value = Math.Min(position / faktor, Value);
                    }
                    else
                    {
                        position -= _drawTimer.Interval / 1000 * _speed;
                        base.Value = Math.Max(position / faktor, Value);
                    }
                }
            });
        }
    }
}