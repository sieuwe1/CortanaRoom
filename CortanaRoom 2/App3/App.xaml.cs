using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CoRGB
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        Ledstrip l = new Ledstrip();

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
            if (e.Kind != ActivationKind.VoiceCommand)
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
                    Board.instance.ChangePinState(Setting.Instance.OfficeLightpin,1);
                    Setting.Instance.OfficeLightOn = true;
                    break;
                case "officelightoff":
                    Board.instance.ChangePinState(Setting.Instance.OfficeLightpin, 0);
                    Setting.Instance.OfficeLightOn = false;
                    break;
                case "mainlighton":
                    Board.instance.ChangePinState(Setting.Instance.MainLightpin, 1);
                    Setting.Instance.MainLightOn = true;
                    break;
                case "mainlightoff":
                    Board.instance.ChangePinState(Setting.Instance.MainLightpin, 0);
                    Setting.Instance.MainLightOn = false;
                    break;
                case "readinglighton":
                    Board.instance.ChangePinState(Setting.Instance.ReadingLightpin, 1);
                    Setting.Instance.ReadingLightOn = true;
                    break;
                case "readinglightoff":
                    Board.instance.ChangePinState(Setting.Instance.ReadingLightpin, 0);
                    Setting.Instance.ReadingLightOn = false;
                    break;
                case "officedeviceson":
                    Board.instance.ChangePinState(Setting.Instance.Officepin, 1);
                    Setting.Instance.OfficeOn = true;
                    break;
                case "officedevicesoff":
                    Board.instance.ChangePinState(Setting.Instance.Officepin, 0);
                    Setting.Instance.OfficeOn = false;
                    break;
                case "TVOn":
                    Board.instance.ChangePinState(Setting.Instance.TVpin, 0);
                    Setting.Instance.TVOn = true;
                    break;
                case "TVOff":
                    Board.instance.ChangePinState(Setting.Instance.TVpin, 0);
                    Setting.Instance.TVOn = false;
                    break;
                case "ledstripon":
                    Board.instance.WriteSmoothColor(255, 255, 255);
                    Setting.Instance.LedColor = "White";
                    break;
                case "ledstriponblue":
                    Board.instance.WriteSmoothColor(0, 0, 255);
                    Setting.Instance.LedColor = "Blue";
                    break;
                case "ledstriponred":
                    Board.instance.WriteSmoothColor(255, 0, 0);
                    Setting.Instance.LedColor = "Red";
                    break;
                case "ledstripongreen":
                    Board.instance.WriteSmoothColor(0, 255, 0);
                    Setting.Instance.LedColor = "Green";
                    break;
                case "ledstriponyellow":
                    Board.instance.WriteSmoothColor(255, 0, 255);
                    Setting.Instance.LedColor = "Yellow";
                    break;
                case "ledstriponcyan":
                    Board.instance.WriteSmoothColor(0, 255, 255);
                    Setting.Instance.LedColor = "Cyan";
                    break;
                case "ledstriponpurple":
                    Board.instance.WriteSmoothColor(128, 0, 128);
                    Setting.Instance.LedColor = "Purple";
                    break;
                case "ledstripoff":
                    Board.instance.WriteSmoothColor(0, 0, 0);
                    Setting.Instance.LedColor = "blank";
                    break;
                case "alloff":
                    Board.instance.AllOff();
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