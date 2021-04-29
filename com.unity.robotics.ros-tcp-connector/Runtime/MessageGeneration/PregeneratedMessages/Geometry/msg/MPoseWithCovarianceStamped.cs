//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Geometry
{
    public class MPoseWithCovarianceStamped : Message
    {
        public const string k_RosMessageName = "geometry_msgs/PoseWithCovarianceStamped";
        public override string RosMessageName => k_RosMessageName;

        //  This expresses an estimated pose with a reference coordinate frame and timestamp
        public MHeader header;
        public MPoseWithCovariance pose;

        public MPoseWithCovarianceStamped()
        {
            this.header = new MHeader();
            this.pose = new MPoseWithCovariance();
        }

        public MPoseWithCovarianceStamped(MHeader header, MPoseWithCovariance pose)
        {
            this.header = header;
            this.pose = pose;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.AddRange(pose.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            offset = this.pose.Deserialize(data, offset);

            return offset;
        }

        public override string ToString()
        {
            return "MPoseWithCovarianceStamped: " +
            "\nheader: " + header.ToString() +
            "\npose: " + pose.ToString();
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MPoseWithCovarianceStamped>(k_RosMessageName);
        }
    }
}
