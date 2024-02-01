using System;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using poc_maui.Controls;
using UIKit;

namespace poc_maui.Platforms.iOS.Handlers
{
	public class CustomDatePickerHandler : DatePickerHandler
	{
        CustomDatePicker _customDatePicker;
        MauiDatePicker _mauiDatePicker;

        protected override MauiDatePicker CreatePlatformView()
        {
            return base.CreatePlatformView();
        }

        protected override void ConnectHandler(MauiDatePicker platformView)
        {
            _customDatePicker = VirtualView as CustomDatePicker;
            _mauiDatePicker = new MauiDatePicker();

            UIDatePicker picker = (UIDatePicker)platformView.InputView;
            picker.PreferredDatePickerStyle = UIDatePickerStyle.Compact;
            platformView.InputView = picker;
            platformView.ReloadInputViews();

            var originalToolbar = _mauiDatePicker.InputAccessoryView as UIToolbar;
            if (originalToolbar != null && originalToolbar.Items.Length <= 2)
            {
                //Access iOS DatePicker Done Button and it's Clicked event, subscribing to it.
                originalToolbar.Items[1].Clicked += OnDone;

                platformView.InputAccessoryView = originalToolbar;
                originalToolbar.ReloadInputViews();

                base.ConnectHandler(platformView);
            }
        }

        private void OnDone(object sender, EventArgs e)
        {
            _customDatePicker.Date = (_customDatePicker as DatePicker).Date;

            //to close the datepicker dialog since unfocus() only works once you change the date.
            (this as IDatePickerHandler)?.PlatformView.ResignFirstResponder();
        }

        protected override void DisconnectHandler(MauiDatePicker platformView)
        {
            base.DisconnectHandler(platformView);
        }
    }
}

