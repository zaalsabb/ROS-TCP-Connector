﻿using RosMessageTypes.Nav;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.MessageVisualizers;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

public class DefaultVisualizerOccupancyGrid : BasicVisualizer<MOccupancyGrid>
{
    public override void Draw(BasicDrawing drawing, MOccupancyGrid message, MessageMetadata meta, Color color, string label)
    {
        message.Draw<FLU>(drawing);
    }

    public override Action CreateGUI(MOccupancyGrid message, MessageMetadata meta, BasicDrawing drawing) => () =>
    {
        message.header.GUI();
        message.info.GUI();
    };
}