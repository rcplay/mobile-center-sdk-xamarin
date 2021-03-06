﻿using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Java.Lang;

namespace Microsoft.Azure.Mobile
{
    using Com.Microsoft.Azure.Mobile;
    using AndroidWrapperSdk = Com.Microsoft.Azure.Mobile.Ingestion.Models.WrapperSdk;

    /// <summary>
    /// SDK core used to initialize, start and control specific service.
    /// </summary>
    public static class MobileCenter
    {
        /// <summary>
        /// This property controls the amount of logs emitted by the SDK.
        /// </summary>
        public static LogLevel LogLevel
        {
            get
            {
                var value = AndroidMobileCenter.LogLevel;
                switch (value)
                {
                    case 2:
                        return LogLevel.Verbose;
                    case 3:
                        return LogLevel.Debug;
                    case 4:
                        return LogLevel.Info;
                    case 5:
                        return LogLevel.Warn;
                    case 6:
                        return LogLevel.Error;
                    case 7:
                        return LogLevel.Assert;
                    case Com.Microsoft.Azure.Mobile.Utils.MobileCenterLog.None:
                        return LogLevel.None;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }

            set
            {
                int androidValue;
                switch (value)
                {
                    case LogLevel.Verbose:
                        androidValue = 2;
                        break;
                    case LogLevel.Debug:
                        androidValue = 3;
                        break;
                    case LogLevel.Info:
                        androidValue = 4;
                        break;
                    case LogLevel.Warn:
                        androidValue = 5;
                        break;
                    case LogLevel.Error:
                        androidValue = 6;
                        break;
                    case LogLevel.Assert:
                        androidValue = 7;
                        break;
                    case LogLevel.None:
                        androidValue = Com.Microsoft.Azure.Mobile.Utils.MobileCenterLog.None;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
                AndroidMobileCenter.LogLevel = androidValue;
            }
        }

        /// <summary>
        /// Change the base URL (scheme + authority + port only) used to communicate with the backend.
        /// </summary>
        /// <param name="serverUrl">Base URL to use for server communication.</param>
        public static void SetServerUrl(string serverUrl)
        {
            AndroidMobileCenter.SetServerUrl(serverUrl);
        }

        /// <summary>
        /// Configure the SDK.
        /// This may be called only once per application process lifetime.
        /// </summary>
        /// <param name="appSecret">A unique and secret key used to identify the application.</param>
        public static void Configure(string appSecret)
        {
            AndroidMobileCenter.Configure(SetWrapperSdkAndGetApplication(), appSecret);
        }

        /// <summary>
        /// Start services.
        /// This may be called only once per service per application process lifetime.
        /// </summary>
        /// <param name="services">List of services to use.</param>
        public static void Start(params Type[] services)
        {
            AndroidMobileCenter.Start(GetServices(services));
        }

        /// <summary>
        /// Initialize the SDK with the list of services to start.
        /// This may be called only once per application process lifetime.
        /// </summary>
        /// <param name="appSecret">A unique and secret key used to identify the application.</param>
        /// <param name="services">List of services to use.</param>
        public static void Start(string appSecret, params Type[] services)
        {
            AndroidMobileCenter.Start(SetWrapperSdkAndGetApplication(), appSecret, GetServices(services));
        }


        /// <summary>
        /// Enable or disable the SDK as a whole. Updating the property propagates the value to all services that have been started.
        /// </summary>
        /// <remarks>
        /// The default state is <c>true</c> and updating the state is persisted into local application storage.
        /// </remarks>
        public static bool Enabled
        {
            get { return AndroidMobileCenter.Enabled; }
            set { AndroidMobileCenter.Enabled = value; }
        }

        /// <summary>
        /// Get the unique installation identifier for this application installation on this device.
        /// </summary>
        /// <remarks>
        /// The identifier is lost if clearing application data or uninstalling application.
        /// </remarks>
        public static Guid InstallId => Guid.Parse(AndroidMobileCenter.InstallId.ToString());

        private static Application SetWrapperSdkAndGetApplication()
        {
            AndroidMobileCenter.SetWrapperSdk(new AndroidWrapperSdk { WrapperSdkName = WrapperSdk.Name, WrapperSdkVersion = WrapperSdk.Version });
            return (Application)Application.Context;
        }

        private static Class[] GetServices(IEnumerable<Type> services)
        {
            return services.Select(service => Class.FromType((Type)service.GetProperty("BindingType").GetValue(null, null))).ToArray();
        }
    }
}