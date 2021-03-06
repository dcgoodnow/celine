﻿using System;
using System.Collections.Generic;
using System.Text;
using gnow.util.behringer;

namespace gnow.util
{
    public class Channel17_24 : FaderBank
    {
        public void setMute(int index, bool value)
        {
            int channel = 17 + index;
            string subAddress = "mix/on";
            string address = "/ch/" + channel.ToString().PadLeft(2, '0') + subAddress;
            X32Console.Instance.Channels[channel].StereoOn = value;
        }

        public void setLevel(int index, float value)
        {
            int channel = 17 + index;
            string subAddress = "mix/fader";
            string address = "/ch/" + channel.ToString().PadLeft(2, '0') + subAddress;
            X32Console.Instance.Channels[channel].Level.DbFSLevel = value;
        }

        public Constants.FADER_GROUP getEnum()
        {
            return Constants.FADER_GROUP.CHANNEL_17_24;
        }
    }
}
