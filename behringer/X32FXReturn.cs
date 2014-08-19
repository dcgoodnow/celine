﻿using gnow.util.osc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gnow.util.behringer
{
    public class X32FXReturn : X32ChannelBase
    {
        public Constants.ON_OFF StereoOn;
        public Constants.ON_OFF MonoOn;
        public X32Level MonoLevel;

        public X32FXReturn() : base()
        {
            Sends = new List<X32Send>(16);
            for(int i = 0; i<16; i++)
            {
                Sends.Add(new X32Send());
            }
            eq = new X32Eq();
            StereoOn = Constants.ON_OFF.ON;
            MonoOn = Constants.ON_OFF.OFF;
            MonoLevel = new X32Level(0.0f, 161);
        }
        public override bool SetMixValues(string[] parameters, object value)
        {
            if(!base.SetMixValues(parameters, value))
            {
                switch (parameters[2])
                {
                    case "pan":
                        break;
                    case "st":
                        StereoOn = (Constants.ON_OFF)(int)(oscInt)value;
                        break;
                    case "mono":
                        MonoOn = (Constants.ON_OFF)(int)(oscInt)value;
                        break;
                    case "mlevel":
                        MonoLevel.RawLevel = (oscFloat)value;
                        break;
                }
            }
            return true;
        }
    }
}
