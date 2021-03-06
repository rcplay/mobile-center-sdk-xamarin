﻿using System;

namespace Microsoft.Azure.Mobile
{
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
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Change the base URL (scheme + authority + port only) used to communicate with the backend.
        /// </summary>
        /// <param name="serverUrl">Base URL to use for server communication.</param>
        public static void SetServerUrl(string serverUrl)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Configure the SDK.
        /// This may be called only once per application process lifetime.
        /// </summary>
        /// <param name="appSecret">A unique and secret key used to identify the application.</param>
        public static void Configure(string appSecret)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start services.
        /// This may be called only once per service per application process lifetime.
        /// </summary>
        /// <param name="services">List of services to use.</param>
        public static void Start(params Type[] services)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initialize the SDK with the list of services to start.
        /// This may be called only once per application process lifetime.
        /// </summary>
        /// <param name="appSecret">A unique and secret key used to identify the application.</param>
        /// <param name="services">List of services to use.</param>
        public static void Start(string appSecret, params Type[] services)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Enable or disable the SDK as a whole. Updating the property propagates the value to all services that have been started.
        /// </summary>
        /// <remarks>
        /// The default state is <c>true</c> and updating the state is persisted into local application storage.
        /// </remarks>
        public static bool Enabled
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Get the unique installation identifier for this application installation on this device.
        /// </summary>
        /// <remarks>
        /// The identifier is lost if clearing application data or uninstalling application.
        /// </remarks>
        public static Guid InstallId
        {
            get { throw new NotImplementedException(); }
        }
    }
}
