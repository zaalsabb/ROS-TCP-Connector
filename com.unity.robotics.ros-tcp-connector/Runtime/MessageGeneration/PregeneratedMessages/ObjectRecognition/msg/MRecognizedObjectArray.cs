//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.ObjectRecognition
{
    public class MRecognizedObjectArray : Message
    {
        public const string k_RosMessageName = "object_recognition_msgs/RecognizedObjectArray";
        public override string RosMessageName => k_RosMessageName;

        // #################################################### HEADER ###########################################################
        public MHeader header;
        //  This message type describes a potential scene configuration: a set of objects that can explain the scene
        public MRecognizedObject[] objects;
        // #################################################### SEARCH ###########################################################
        //  The co-occurrence matrix between the recognized objects
        public float[] cooccurrence;

        public MRecognizedObjectArray()
        {
            this.header = new MHeader();
            this.objects = new MRecognizedObject[0];
            this.cooccurrence = new float[0];
        }

        public MRecognizedObjectArray(MHeader header, MRecognizedObject[] objects, float[] cooccurrence)
        {
            this.header = header;
            this.objects = objects;
            this.cooccurrence = cooccurrence;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            
            listOfSerializations.Add(BitConverter.GetBytes(objects.Length));
            foreach(var entry in objects)
                listOfSerializations.Add(entry.Serialize());
            
            listOfSerializations.Add(BitConverter.GetBytes(cooccurrence.Length));
            foreach(var entry in cooccurrence)
                listOfSerializations.Add(BitConverter.GetBytes(entry));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            
            var objectsArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.objects= new MRecognizedObject[objectsArrayLength];
            for(var i = 0; i < objectsArrayLength; i++)
            {
                this.objects[i] = new MRecognizedObject();
                offset = this.objects[i].Deserialize(data, offset);
            }
            
            var cooccurrenceArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.cooccurrence= new float[cooccurrenceArrayLength];
            for(var i = 0; i < cooccurrenceArrayLength; i++)
            {
                this.cooccurrence[i] = BitConverter.ToSingle(data, offset);
                offset += 4;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MRecognizedObjectArray: " +
            "\nheader: " + header.ToString() +
            "\nobjects: " + System.String.Join(", ", objects.ToList()) +
            "\ncooccurrence: " + System.String.Join(", ", cooccurrence.ToList());
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MRecognizedObjectArray>(k_RosMessageName);
        }
    }
}
