//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Geometry
{
    public class MAccelStamped : Message
    {
        public const string k_RosMessageName = "geometry_msgs/AccelStamped";
        public override string RosMessageName => k_RosMessageName;

        //  An accel with reference coordinate frame and timestamp
        public MHeader header;
        public MAccel accel;

        public MAccelStamped()
        {
            this.header = new MHeader();
            this.accel = new MAccel();
        }

        public MAccelStamped(MHeader header, MAccel accel)
        {
            this.header = header;
            this.accel = accel;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(accel.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.accel.Deserialize(data, offset);

            return offset;
        }

        public override string ToString()
        {
            return "MAccelStamped: " +
            "\nheader: " + header.ToString() +
            "\naccel: " + accel.ToString();
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MAccelStamped>(k_RosMessageName);
        }
    }
}
