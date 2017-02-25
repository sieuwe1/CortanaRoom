using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace App3
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.Register();
        }

        private async void Register()
        {
            var storageFile =
                await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///VoiceCommandDefinition.xml"));
            await
                Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(storageFile);
        }

        protected override void OnActivated(IActivatedEventArgs e)
        {
            base.OnActivated(e);
            if (e.Kind != Windows.ApplicationModel.Activation.ActivationKind.VoiceCommand)
            {
                return;
            }

            var commandArgs = e as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
            var speechRecognitionResult = commandArgs.Result;
            var command = speechRecognitionResult.Text;


            // Get the name of the voice command and the text spoken.
            string voiceCommandName = speechRecognitionResult.RulePath[0];
            switch (voiceCommandName)
            {
                case "officelighton":
                    MainPage.officelighton();
                    break;
                case "officelightoff":
                    MainPage.officelightoff();
                    break;
                case "mainlighton":
                    MainPage.mainlighton();
                    break;
                case "mainlightoff":
                    MainPage.mainlightoff();
                    break;
                case "readinglighton":
                    MainPage.readinglighton();
                    break;
                case "readinglightoff":
                    MainPage.readinglightoff();
                    break;
                case "officedeviceson":
                    MainPage.officedeviceson();
                    break;
                case "officedevicesoff":
                    MainPage.officedevicesoff();
                    break;
                case "opendoor":
                    MainPage.opendoor();
                    break;

                case "closedoor":
                    MainPage.closedoor();
                    break;

                case "ledstripon":
                    MainPage.ledstripon();
                    break;

                case "ledstriponblue":
                    MainPage.ledstriponblue();
                    break;
                case "ledstriponred":
                    MainPage.ledstriponred();
                    break;
                case "ledstripongreen":
                    MainPage.ledstripongreen();
                    break;

                case "ledstriponyellow":
                    MainPage.ledstriponyellow();
                    break;

                case "ledstriponcyan":
                    MainPage.ledstriponcyan();
                    break;

                case "ledstriponorange":
                    MainPage.ledstriponorange();
                    break;

                case "ledstriponpink":
                    MainPage.ledstriponpink();
                    break;

                case "ledstriponpurple":
                    MainPage.ledstripongreen();
                    break;
                    

                case "ledstripoff":
                    MainPage.ledstripoff();
                    break;
                case "allon":
                    MainPage.allon();
                    break;
                case "alloff":
                    MainPage.alloff();
                    break;
                case "ledstriponfade":
                    MainPage.fadeon();
                    break;


                default:
                    break;
            }


            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                //use the "command" which was spoken by the user.
                // i am just checking weather the Activation is by Voice command or not and  navigating.
                if (e.Kind != Windows.ApplicationModel.Activation.ActivationKind.VoiceCommand)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Kind);
                }
                else
                {
                    rootFrame.Navigate(typeof(MainPage), e.Kind);
                }

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
            }
            // Ensure the current window is active
            Window.Current.Activate();


        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
