//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Tf2
{
    public class MTF2Error : Message
    {
        public const string k_RosMessageName = "tf2_msgs/TF2Error";
        public override string RosMessageName => k_RosMessageName;

        public const byte NO_ERROR = 0;
        public const byte LOOKUP_ERROR = 1;
        public const byte CONNECTIVITY_ERROR = 2;
        public const byte EXTRAPOLATION_ERROR = 3;
        public const byte INVALID_ARGUMENT_ERROR = 4;
        public const byte TIMEOUT_ERROR = 5;
        public const byte TRANSFORM_ERROR = 6;
        public byte error;
        public string error_string;

        public MTF2Error()
        {
            this.error = 0;
            this.error_string = "";
        }

        public MTF2Error(byte error, string error_string)
        {
            this.error = error;
            this.error_string = error_string;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.Add(new[]{this.error});
            listOfSerializations.Add(SerializeString(this.error_string));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            this.error = data[offset];;
            offset += 1;
            var error_stringStringBytesLength = DeserializeLength(data, offset);
            offset += 4;
            this.error_string = DeserializeString(data, offset, error_stringStringBytesLength);
            offset += error_stringStringBytesLength;

            return offset;
        }

        public override string ToString()
        {
            return "MTF2Error: " +
            "\nerror: " + error.ToString() +
            "\nerror_string: " + error_string.ToString();
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MTF2Error>(k_RosMessageName);
        }
    }
}
