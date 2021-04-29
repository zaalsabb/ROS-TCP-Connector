//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geometry
{
    public class MTransform : Message
    {
        public const string k_RosMessageName = "geometry_msgs/Transform";
        public override string RosMessageName => k_RosMessageName;

        //  This represents the transform between two coordinate frames in free space.
        public MVector3 translation;
        public MQuaternion rotation;

        public MTransform()
        {
            this.translation = new MVector3();
            this.rotation = new MQuaternion();
        }

        public MTransform(MVector3 translation, MQuaternion rotation)
        {
            this.translation = translation;
            this.rotation = rotation;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(translation.SerializationStatements());
            listOfSerializations.AddRange(rotation.SerializationStatements());

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.translation.Deserialize(data, offset);
            offset = this.rotation.Deserialize(data, offset);

            return offset;
        }

        public override string ToString()
        {
            return "MTransform: " +
            "\ntranslation: " + translation.ToString() +
            "\nrotation: " + rotation.ToString();
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MTransform>(k_RosMessageName);
        }
    }
}
