// ---
// Information
// ---
// Program name - Kinect for hand based gestures (wavebot)
// Program version - 1.0
// Description - Main window for the controlling arduino components using hand based gestures from the kinect.
// Program credits - Created at HackUMass 2015. Open sourced and free to use.
// Team - 15
// ---

/// Importing necesary libraries
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/// defining the name space, everything stays in here.
namespace KinectHandTracking
{
    /// <summary>
    /// UI for Main Window. Defining the hardware.
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members
        // Defining the position and connections of the kinect.
        KinectSensor _sensor;
        MultiSourceFrameReader _reader;
        IList<Body> _bodies;

        // Specifying the Arduino's I/O connections.
        // This is done so that the switch output from the kinect is redireted to an action for the arduino.
        #endregion
        private System.ComponentModel.IContainer components = null;
        private System.IO.Ports.SerialPort serialPort1;
        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            serialInit();
        }

        #endregion

        private void serialInit()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            serialPort1.PortName = "COM10";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();
           
         //   serialPort1.Close();
        }

        #region Event handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _sensor = KinectSensor.GetDefault();

            if (_sensor != null)
            {
                _sensor.Open();

                _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color | FrameSourceTypes.Depth | FrameSourceTypes.Infrared | FrameSourceTypes.Body);
                _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_reader != null)
            {
                _reader.Dispose();
            }

            if (_sensor != null)
            {
                _sensor.Close();
            }
        }

        void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            var reference = e.FrameReference.AcquireFrame();

            // Color
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    camera.Source = frame.ToBitmap();
                }
            }

            // Body
            using (var frame = reference.BodyFrameReference.AcquireFrame())
            {
                if (frame != null)
                {
                    canvas.Children.Clear();

                    _bodies = new Body[frame.BodyFrameSource.BodyCount];

                    frame.GetAndRefreshBodyData(_bodies);

                    foreach (var body in _bodies)
                    {
                        if (body != null)
                        {
                            if (body.IsTracked)
                            {
                                // Determining the joints
                                Joint handRight = body.Joints[JointType.HandRight];
                                Joint thumbRight = body.Joints[JointType.ThumbRight];

                                Joint handLeft = body.Joints[JointType.HandLeft];
                                Joint thumbLeft = body.Joints[JointType.ThumbLeft];

                                // Hands and thumbs
                                canvas.DrawHand(handRight, _sensor.CoordinateMapper);
                                canvas.DrawHand(handLeft, _sensor.CoordinateMapper);
                                canvas.DrawThumb(thumbRight, _sensor.CoordinateMapper);
                                canvas.DrawThumb(thumbLeft, _sensor.CoordinateMapper);

                                // hand states
                                string rightHandState = "-";
                                string leftHandState = "-";

                                // if and else conditions for each scenario.
                                // if hand open then led on, else close and so on.
                                switch (body.HandRightState)
                                {
                                    case HandState.Open:
                                        serialPort1.Write("1");
                                        rightHandState = "Open";
                                        break;
                                    case HandState.Closed:
                                        serialPort1.Write("0");
                                        rightHandState = "Closed";
                                        break;
                                    case HandState.Lasso:
                                        serialPort1.Write("2");
                                        rightHandState = "Lasso";
                                        break;
                                    case HandState.Unknown:
                                        rightHandState = "Unknown...";
                                        break;
                                    case HandState.NotTracked:
                                        rightHandState = "Not tracked";
                                        break;
                                    default:
                                        break;
                                }

                                switch (body.HandLeftState)
                                {
                                    case HandState.Open:
                                        serialPort1.Write("4");
                                        leftHandState = "Open";
                                        break;
                                    case HandState.Closed:
                                        serialPort1.Write("3");
                                        leftHandState = "Closed";
                                        break;
                                    case HandState.Lasso:
                                        serialPort1.Write("5");
                                        leftHandState = "Lasso";
                                        break;
                                    case HandState.Unknown:
                                        leftHandState = "Unknown...";
                                        break;
                                    case HandState.NotTracked:
                                        leftHandState = "Not tracked";
                                        break;
                                    default:
                                        break;
                                }

                                tblRightHandState.Text = rightHandState;
                                tblLeftHandState.Text = leftHandState;
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }

}
