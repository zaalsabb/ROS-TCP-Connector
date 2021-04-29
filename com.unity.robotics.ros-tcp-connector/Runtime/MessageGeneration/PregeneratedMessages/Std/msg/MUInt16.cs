//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Std
{
    public class MUInt16 : Message
    {
        public const string k_RosMessageName = "std_msgs/UInt16";
        public override string RosMessageName => k_RosMessageName;

        public ushort data;

        public MUInt16()
        {
            this.data = 0;
        }

        public MUInt16(ushort data)
        {
            this.data = data;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(BitConverter.GetBytes(this.data));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.data = BitConverter.ToUInt16(data, offset);
            offset += 2;

            return offset;
        }

        public override string ToString()
        {
            return "MUInt16: " +
            "\ndata: " + data.ToString();
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MUInt16>(k_RosMessageName);
        }
    }
}
