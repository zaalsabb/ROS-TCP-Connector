//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Std
{
    public class MFloat64MultiArray : Message
    {
        public const string k_RosMessageName = "std_msgs/Float64MultiArray";
        public override string RosMessageName => k_RosMessageName;

        //  Please look at the MultiArrayLayout message definition for
        //  documentation on all multiarrays.
        public MMultiArrayLayout layout;
        //  specification of data layout
        public double[] data;
        //  array of data

        public MFloat64MultiArray()
        {
            this.layout = new MMultiArrayLayout();
            this.data = new double[0];
        }

        public MFloat64MultiArray(MMultiArrayLayout layout, double[] data)
        {
            this.layout = layout;
            this.data = data;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(layout.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(data.Length));
            foreach(var entry in data)
                listOfSerializations.Add(BitConverter.GetBytes(entry));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.layout.Deserialize(data, offset);
            
            var dataArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.data= new double[dataArrayLength];
            for(var i = 0; i < dataArrayLength; i++)
            {
                this.data[i] = BitConverter.ToDouble(data, offset);
                offset += 8;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MFloat64MultiArray: " +
            "\nlayout: " + layout.ToString() +
            "\ndata: " + System.String.Join(", ", data.ToList());
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MFloat64MultiArray>(k_RosMessageName);
        }
    }
}
