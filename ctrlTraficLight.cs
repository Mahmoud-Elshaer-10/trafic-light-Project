using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using trafik_light_Project.Properties;

namespace trafik_light_Project
{
    public partial class ctrlTraficLight : UserControl
    {
        public enum enLight { Red, Orange, Green }
        private enLight _CurrentLight = enLight.Red;

        [Category("Traffic Light Config"), Description("Choose starting light.")]
        public enLight CurrentLight
        {
            get { return _CurrentLight; }

            set
            {
                _CurrentLight = value;

                switch (CurrentLight)
                {
                    case enLight.Red:
                        pbLight.Image = Resources.Red;
                        lblCountDown.ForeColor = Color.Red;
                        break;
                    case enLight.Orange:
                        pbLight.Image = Resources.Orange;
                        lblCountDown.ForeColor = Color.Orange;
                        break;
                    case enLight.Green:
                        pbLight.Image = Resources.Green;
                        lblCountDown.ForeColor = Color.Green;
                        break;
                    default:
                        lblCountDown.ForeColor = Color.Red;
                        break;
                }
            }
        }

        [Category("Traffic Light Config"), Description("Red light duration in seconds.")]
        public int RedTime { get; set; } = 10;
        [Category("Traffic Light Config"), Description("Orange light duration in seconds.")]
        public int OrangeTime { get; set; } = 3;
        [Category("Traffic Light Config"), Description("Green light duration in seconds.")]
        public int GreenTime { get; set; } = 10;

        private int _CurrentCountDownValue;

        public int GetCurrentTime()
        {
            switch (CurrentLight)
            {
                case enLight.Red:
                    return RedTime;
                case enLight.Orange:
                    return OrangeTime;
                case enLight.Green:
                    return GreenTime;

                default:
                    return RedTime;
            }
        }

        public void Start()
        {
            _CurrentCountDownValue = GetCurrentTime();
            lblCountDown.Text = _CurrentCountDownValue.ToString();
            LightTimer.Start();
        }

        private void LightTimer_Tick(object sender, EventArgs e)
        {
            --_CurrentCountDownValue;
            // OR _CurrentCountDownValue--;

            lblCountDown.Text = _CurrentCountDownValue.ToString();
            if (_CurrentCountDownValue == 0)
            {
                _ChangeLight();
            }
        }

        private enLight _NextLight;

        private void _ChangeLight()
        {
            switch (CurrentLight)
            {
                case enLight.Red:
                    CurrentLight = enLight.Orange;
                    _NextLight = enLight.Green;
                    _CurrentCountDownValue = OrangeTime;
                    lblCountDown.Text = _CurrentCountDownValue.ToString();

                    RaiseOrangeLightOn();

                    break;

                case enLight.Orange:
                    if (_NextLight == enLight.Green)
                    {
                        CurrentLight = enLight.Green;
                        _CurrentCountDownValue = GreenTime;
                        lblCountDown.Text = _CurrentCountDownValue.ToString();

                        RaiseGreenLightOn();
                    }
                    else
                    {
                        CurrentLight = enLight.Red;
                        _CurrentCountDownValue = RedTime;
                        lblCountDown.Text = _CurrentCountDownValue.ToString();

                        RaiseRedLightOn();
                    }
                    break;

                case enLight.Green:
                    CurrentLight = enLight.Orange;
                    _NextLight = enLight.Red;
                    _CurrentCountDownValue = OrangeTime;
                    lblCountDown.Text = _CurrentCountDownValue.ToString();

                    RaiseOrangeLightOn();

                    break;

                default:
                    pbLight.Image = Resources.Red;
                    break;
            }
        }

        #region ================ Events Definitions ================
        public class TraficLightEventArgs : EventArgs
        {
            public enLight CurrentLight { get; }
            public int LightDuration { get; }

            public TraficLightEventArgs(enLight CurrentLight, int LightDuration)
            {
                this.CurrentLight = CurrentLight;
                this.LightDuration = LightDuration;
            }
        }

        public event EventHandler<TraficLightEventArgs> RedLightOn;
        public void RaiseRedLightOn()
        {
            RedLightOn?.Invoke(this, new TraficLightEventArgs(enLight.Red, RedTime));
        }

        public event EventHandler<TraficLightEventArgs> OrangeLightOn;
        public void RaiseOrangeLightOn()
        {
            OrangeLightOn?.Invoke(this, new TraficLightEventArgs(enLight.Orange, OrangeTime));
        }

        public event EventHandler<TraficLightEventArgs> GreenLightOn;
        public void RaiseGreenLightOn()
        {
            GreenLightOn?.Invoke(this, new TraficLightEventArgs(enLight.Green, GreenTime));
        }
        #endregion

        public ctrlTraficLight()
        {
            InitializeComponent();
        }
    }
}
