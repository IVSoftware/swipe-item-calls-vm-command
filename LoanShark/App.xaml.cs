﻿namespace LoanShark
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            if (Application.Current is not null && DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                Application.Current.UserAppTheme = AppTheme.Light;
                var window = base.CreateWindow(activationState);
                window.Width = 540;
                window.Height = 960;

                // Time to complete async window resizing.
                window.Dispatcher.DispatchAsync(() => { }).GetAwaiter().OnCompleted(() =>
                {
                    var disp = DeviceDisplay.Current.MainDisplayInfo;
                    window.X = (disp.Width / disp.Density - window.Width) / 2;
                    window.Y = (disp.Height / disp.Density - window.Height) / 2;
                });
                return window;
            }
            else
            {
                return base.CreateWindow(activationState);
            }
        }
    }
}
