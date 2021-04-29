//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geometry
{
    public class MAccelWithCovariance : Message
    {
        public const string k_RosMessageName = "geometry_msgs/AccelWithCovariance";
        public override string RosMessageName => k_RosMessageName;

        //  This expresses acceleration in free space with uncertainty.
        public MAccel accel;
        //  Row-major representation of the 6x6 covariance matrix
        //  The orientation parameters use a fixed-axis representation.
        //  In order, the parameters are:
        //  (x, y, z, rotation about X axis, rotation about Y axis, rotation about Z axis)
        public double[] covariance;

        public MAccelWithCovariance()
        {
            this.accel = new MAccel();
            this.covariance = new double[36];
        }

        public MAccelWithCovariance(MAccel accel, double[] covariance)
        {
            this.accel = accel;
            this.covariance = covariance;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(accel.SerializationStatements());
            
            Array.Resize(ref covariance, 36);
            foreach(var entry in covariance)
                listOfSerializations.Add(BitConverter.GetBytes(entry));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.accel.Deserialize(data, offset);
            
            this.covariance= new double[36];
            for(var i = 0; i < 36; i++)
            {
                this.covariance[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MAccelWithCovariance: " +
            "\naccel: " + accel.ToString() +
            "\ncovariance: " + System.String.Join(", ", covariance.ToList());
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MAccelWithCovariance>(k_RosMessageName);
        }
    }
}
