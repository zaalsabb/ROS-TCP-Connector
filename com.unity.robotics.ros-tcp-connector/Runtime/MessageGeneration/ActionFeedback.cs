﻿/*
© Siemens AG, 2019
Author: Sifan Ye (sifan.ye@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using RosMessageTypes.Actionlib;
using RosMessageTypes.Std;

namespace Unity.Robotics.ROSTCPConnector.MessageGeneration
{
    public abstract class ActionFeedback<TFeedback> : Message where TFeedback : Message
    {
        public MHeader header { get; set; }
        public MGoalStatus status { get; set; }
        public TFeedback feedback { get; set; }

        public ActionFeedback()
        {
            header = new MHeader();
            status = new MGoalStatus();
        }

        public ActionFeedback(MHeader header, MGoalStatus status) {
            this.header = header;
            this.status = status;
        }
    }
}
