﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GoogleVisionBarCodeScanner
{
    public class CameraView : View
    {
        public static BindableProperty VirbationOnDetectedProperty = BindableProperty.Create(nameof(VirbationOnDetected), typeof(bool), typeof(CameraView), true);
        public bool VirbationOnDetected
        {
            get
            {
                return (bool)GetValue(VirbationOnDetectedProperty);
            }
            set
            {
                SetValue(VirbationOnDetectedProperty, value);
            }
        }


        public static BindableProperty DefaultTorchOnProperty = BindableProperty.Create(nameof(DefaultTorchOn), typeof(bool), typeof(CameraView), false);
        public bool DefaultTorchOn
        {
            get
            {
                return (bool)GetValue(DefaultTorchOnProperty);
            }
            set
            {
                SetValue(DefaultTorchOnProperty, value);
            }
        }
        public event EventHandler<OnDetectedEventArg> OnDetected;
        public void TriggerOnDetected(List<BarcodeResult> barCodeResults)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                OnDetected?.Invoke(this, new OnDetectedEventArg { BarcodeResults = barCodeResults });
            });
        }
    }
    
    public class OnDetectedEventArg : EventArgs
    {
        public List<BarcodeResult> BarcodeResults = new List<BarcodeResult>();
    }
}
