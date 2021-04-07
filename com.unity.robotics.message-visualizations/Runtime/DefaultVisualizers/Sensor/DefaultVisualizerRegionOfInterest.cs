using RosMessageTypes.Sensor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.MessageVisualizers;
using UnityEngine;

public class DefaultVisualizerRegionOfInterest : BasicVisualizer<MRegionOfInterest>
{
    public override Action CreateGUI(MRegionOfInterest message, MessageMetadata meta, BasicDrawing drawing) => () =>
    {
        message.GUI();
    };
}
