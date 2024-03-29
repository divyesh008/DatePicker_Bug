﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace poc_maui;

[Activity(
    Theme = "@style/Maui.SplashTheme",
    MainLauncher = true,
    ScreenOrientation = ScreenOrientation.Unspecified,
    ConfigurationChanges = ConfigChanges.ScreenSize |
    ConfigChanges.Orientation |
    ConfigChanges.UiMode |
    ConfigChanges.ScreenLayout |
    ConfigChanges.SmallestScreenSize |
    ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}

