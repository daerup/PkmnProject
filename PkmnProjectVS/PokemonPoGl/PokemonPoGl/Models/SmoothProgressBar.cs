using System;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Threading;

// ReSharper disable once CheckNamespace
namespace smoothBar
{
    internal class SmoothProgressBar : ProgressBar
    {
        private readonly Timer drawTimer;
        private double speed;
        public double Acceleration { get; set; }

        // ReSharper disable once InconsistentNaming
        private new double Value;
        public double SmoothValue
        {
            get => this.Value;
            set
            {
                if (this.Value > 1000)
                    this.Value = 1000;
                else if (this.Value < 0)
                    this.Value = 0;
                else
                    this.Value = value;
            }
        }

        public SmoothProgressBar()
        {
            this.drawTimer = new Timer();
            this.drawTimer.Elapsed += OnTimerEvent;

            // 25 Fps für Timer verwenden
            this.drawTimer.Interval = 40;
            this.drawTimer.Enabled = true;

            this.speed = 0;
            this.Acceleration = 0.5;
        }

        public void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            // Dispatcher aufrufen um an STA-Thread von wpf zu gelangen
            this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) delegate
            {
                if (Math.Abs(this.Value - base.Value) > 0)
                {
                    // beliebiges maximum normalisieren
                    var faktor = 1 / this.Maximum;
                    // position auf Interval von 0-1 berechnen
                    var position = faktor * base.Value;

                    // Minimum berechnen zwischen beschleunigter und negativ beschleunigter Bewegung
                    // parameter 1: v = a*t
                    // parameter 2: v = sqrt(2*Bremsweg*a)
                    this.speed = Math.Min(this.speed + this.Acceleration * (this.drawTimer.Interval / 1000),
                        Math.Sqrt(2 * Math.Abs(faktor * this.Value - position) * this.Acceleration));

                    // Nach rechts oder Links bewegen. s = v * t
                    if (this.Value > base.Value)
                    {
                        position += this.drawTimer.Interval / 1000 * this.speed;
                        base.Value = Math.Min(position / faktor, this.Value);
                    }
                    else
                    {
                        position -= this.drawTimer.Interval / 1000 * this.speed;
                        base.Value = Math.Max(position / faktor, this.Value);
                    }
                }
            });
        }
    }
}