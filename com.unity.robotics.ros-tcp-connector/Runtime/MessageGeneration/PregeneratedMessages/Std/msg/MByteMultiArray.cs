//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Std
{
    public class MByteMultiArray : Message
    {
        public const string k_RosMessageName = "std_msgs/ByteMultiArray";
        public override string RosMessageName => k_RosMessageName;

        //  Please look at the MultiArrayLayout message definition for
        //  documentation on all multiarrays.
        public MMultiArrayLayout layout;
        //  specification of data layout
        public sbyte[] data;
        //  array of data

        public MByteMultiArray()
        {
            this.layout = new MMultiArrayLayout();
            this.data = new sbyte[0];
        }

        public MByteMultiArray(MMultiArrayLayout layout, sbyte[] data)
        {
            this.layout = layout;
            this.data = data;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(layout.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(data.Length));
            listOfSerializations.Add((byte[]) (Array)this.data);

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.layout.Deserialize(data, offset);
            
            var dataArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.data= new sbyte[dataArrayLength];
            for(var i = 0; i < dataArrayLength; i++)
            {
                this.data[i] = (sbyte)data[offset];
                offset += 1;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MByteMultiArray: " +
            "\nlayout: " + layout.ToString() +
            "\ndata: " + System.String.Join(", ", data.ToList());
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MByteMultiArray>(k_RosMessageName);
        }
    }
}
