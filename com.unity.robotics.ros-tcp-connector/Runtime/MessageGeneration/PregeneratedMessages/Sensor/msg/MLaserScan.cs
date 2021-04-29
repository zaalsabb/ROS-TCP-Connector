//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Sensor
{
    public class MLaserScan : Message
    {
        public const string k_RosMessageName = "sensor_msgs/LaserScan";
        public override string RosMessageName => k_RosMessageName;

        //  Single scan from a planar laser range-finder
        // 
        //  If you have another ranging device with different behavior (e.g. a sonar
        //  array), please find or create a different message, since applications
        //  will make fairly laser-specific assumptions about this data
        public MHeader header;
        //  timestamp in the header is the acquisition time of 
        //  the first ray in the scan.
        // 
        //  in frame frame_id, angles are measured around 
        //  the positive Z axis (counterclockwise, if Z is up)
        //  with zero angle being forward along the x axis
        public float angle_min;
        //  start angle of the scan [rad]
        public float angle_max;
        //  end angle of the scan [rad]
        public float angle_increment;
        //  angular distance between measurements [rad]
        public float time_increment;
        //  time between measurements [seconds] - if your scanner
        //  is moving, this will be used in interpolating position
        //  of 3d points
        public float scan_time;
        //  time between scans [seconds]
        public float range_min;
        //  minimum range value [m]
        public float range_max;
        //  maximum range value [m]
        public float[] ranges;
        //  range data [m] (Note: values < range_min or > range_max should be discarded)
        public float[] intensities;
        //  intensity data [device-specific units].  If your
        //  device does not provide intensities, please leave
        //  the array empty.

        public MLaserScan()
        {
            this.header = new MHeader();
            this.angle_min = 0.0f;
            this.angle_max = 0.0f;
            this.angle_increment = 0.0f;
            this.time_increment = 0.0f;
            this.scan_time = 0.0f;
            this.range_min = 0.0f;
            this.range_max = 0.0f;
            this.ranges = new float[0];
            this.intensities = new float[0];
        }

        public MLaserScan(MHeader header, float angle_min, float angle_max, float angle_increment, float time_increment, float scan_time, float range_min, float range_max, float[] ranges, float[] intensities)
        {
            this.header = header;
            this.angle_min = angle_min;
            this.angle_max = angle_max;
            this.angle_increment = angle_increment;
            this.time_increment = time_increment;
            this.scan_time = scan_time;
            this.range_min = range_min;
            this.range_max = range_max;
            this.ranges = ranges;
            this.intensities = intensities;
        }
        public override List<byte[]> SerializationStatements()
        {
            var listOfSerializations = new List<byte[]>();
            listOfSerializations.AddRange(header.SerializationStatements());
            listOfSerializations.Add(BitConverter.GetBytes(this.angle_min));
            listOfSerializations.Add(BitConverter.GetBytes(this.angle_max));
            listOfSerializations.Add(BitConverter.GetBytes(this.angle_increment));
            listOfSerializations.Add(BitConverter.GetBytes(this.time_increment));
            listOfSerializations.Add(BitConverter.GetBytes(this.scan_time));
            listOfSerializations.Add(BitConverter.GetBytes(this.range_min));
            listOfSerializations.Add(BitConverter.GetBytes(this.range_max));
            
            listOfSerializations.Add(BitConverter.GetBytes(ranges.Length));
            foreach(var entry in ranges)
                listOfSerializations.Add(BitConverter.GetBytes(entry));
            
            listOfSerializations.Add(BitConverter.GetBytes(intensities.Length));
            foreach(var entry in intensities)
                listOfSerializations.Add(BitConverter.GetBytes(entry));

            return listOfSerializations;
        }

        public override int Deserialize(byte[] data, int offset)
        {
            offset = this.header.Deserialize(data, offset);
            this.angle_min = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.angle_max = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.angle_increment = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.time_increment = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.scan_time = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.range_min = BitConverter.ToSingle(data, offset);
            offset += 4;
            this.range_max = BitConverter.ToSingle(data, offset);
            offset += 4;
            
            var rangesArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.ranges= new float[rangesArrayLength];
            for(var i = 0; i < rangesArrayLength; i++)
            {
                this.ranges[i] = BitConverter.ToSingle(data, offset);
                offset += 4;
            }
            
            var intensitiesArrayLength = DeserializeLength(data, offset);
            offset += 4;
            this.intensities= new float[intensitiesArrayLength];
            for(var i = 0; i < intensitiesArrayLength; i++)
            {
                this.intensities[i] = BitConverter.ToSingle(data, offset);
                offset += 4;
            }

            return offset;
        }

        public override string ToString()
        {
            return "MLaserScan: " +
            "\nheader: " + header.ToString() +
            "\nangle_min: " + angle_min.ToString() +
            "\nangle_max: " + angle_max.ToString() +
            "\nangle_increment: " + angle_increment.ToString() +
            "\ntime_increment: " + time_increment.ToString() +
            "\nscan_time: " + scan_time.ToString() +
            "\nrange_min: " + range_min.ToString() +
            "\nrange_max: " + range_max.ToString() +
            "\nranges: " + System.String.Join(", ", ranges.ToList()) +
            "\nintensities: " + System.String.Join(", ", intensities.ToList());
        }

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        static void OnLoad()
        {
            MessageRegistry.Register<MLaserScan>(k_RosMessageName);
        }
    }
}
