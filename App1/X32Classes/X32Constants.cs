﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gnow.util.behringer
{
	/// <summary> Constants defined by behringer</summary>
    public static class Constants
    {

        //See http://www.behringer.com/assets/X32_OSC_Remote_Protocol.pdf

		
        public enum ON_OFF { OFF, ON };
        public enum MONOMODE { LRM, LRC };
        public enum SOLO_SOURCE { OFF, LR, LRC, LRPFL, LRAFL, AUX56, AUX78 };
        public enum SOLO_MODE { PFL, AFL };

		/// <summary>Routing options for input channel blocks.</summary>
        public enum INPUT_ROUTING
        {
            AN1TO8, AN9TO16, AN17TO24, AN25TO32, A1TO8, A9TO16,
            A17TO24, A25TO32, A33TO40, A41TO48, B1TO8, B9TO16,
            B17TO24, B25TO32, B33TO40, B41TO48, CARD1TO8, CARD9TO16,
            CARD17TO24, CARD25TO32
        };

		/// <summary>Routing options for aux input channel block.</summary>
        public enum AUX_INPUT_ROUTING { AUX1TO4, AN1TO4, A1TO4, B1TO4, CARD1TO4 };

		/// <summary>Routing options for AES output channel blocks.</summary>
        public enum AES_ROUTING
        {
            AN1TO8, AN9TO16, AN17TO24, AN25TO32, A1TO8, A9TO16,
            A17TO24, A25TO32, A33TO40, A41TO48, B1TO8, B9TO16,
            B17TO24, B25TO32, B33TO40, B41TO48, CARD1TO8, CARD9TO16,
            CARD17TO24, CARD25TO32, OUT1TO8, OUT9TO16, P161TO8,
            P169TO16, AUX_CR
        };

		/// <summary>Routing options for card output channel blocks.</summary>
        public enum CARD_ROUTING
        {
            AN1TO8, AN9TO16, AN17TO24, AN25TO32, A1TO8, A9TO16,
            A17TO24, A25TO32, A33TO40, A41TO48, B1TO8, B9TO16,
            B17TO24, B25TO32, B33TO40, B41TO48, CARD1TO8, CARD9TO16,
            CARD17TO24, CARD25TO32, OUT1TO8, OUT9TO16, P161TO8,
            P169TO16, AUX_CR
        };

		/// <summary>Scribble strip colors</summary>
        public enum COLOR { OFF, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, WHITE };

        public enum GATE_MODE { GATE, DUCK };

		/// <summary>Type of filter for gate sidechain(?)</summary>
        public enum FILTER_TYPE { LC6, LC12, HC6, HC12, _1, _2, _3, _5, _10 };

        public enum DYN_MODE { COMP, EXP };

		/// <summary>Input level to use for dynamic theshold checking</summary>
        public enum DYN_DET { PEAK, RMS };

        public enum DYN_ENV { LIN, LOG };

        public enum DYN_RATIO { _1_1, _1_3, _1_5, _2, _2_5, _3, _4, _5, _7, _10, _20, _100 };

		/// <summary>Tap point for inserts.</summary>
        public enum SIMPLE_POS { PRE, POST };

        public enum INSERT_SEL
        {
            OFF, FX1L, FX1R, FX2L, FX2R, FX3L, FX3R, FX4L,
            FX4R, FX5L, FX5R, FX6L, FX6R, FX7L, FX7R, FX8L,
            FX8R, AUX1, AUX2, AUX3, AUX4, AUX5, AUX6
        };

        public enum EQ_TYPE { LCUT, LSHV, PEQ, VEQ, HSHV, HCUT };

		/// <summary>Tap point for sends</summary>
        public enum MIX_TAP { PRE_EQ, POST_EQ, PRE, POST, GRP };

		/// <summary>Effect type used for effects 1-4</summary>
        public enum FX_TYPE_1
        {
            HALL, PLAT, VREV, VRM, AMBI, GATE, RVRS, DLY,
            _3TAP, CRS, FLNG, PHAS, FILT, ROTA, PAN, D_RV,
            CR_R, FL_R, D_CR, D_FL, GEQ2, GEQ, TEQ2, TEQ,
            WAVD, LIM, ENH2, ENH, EXC2, EXC, IMG, AMP2, AMP,
            DRV2, DRV, PIT2, PIT
        };

        public enum FX_SOURCE
        {
            INS, MIX1, MIX2, MIX3, MIX4, MIX5, MIX6, MIX7,
            MIX8, MIX9, MIX10, MIX11, MIX12, MIX13, MIX14,
            MIX15, MIX16
        };

		/// <summary>Effect type used for effects 5-8.</summary>
        public enum FX_TYPE_2
        {
            GEQ2, GEQ, TEQ2, TEQ, WAVD, LIM, ENH2, ENH,
            EXC2, EXC, IMG, AMP2, AMP, DRV2, DRV, PHAS,
            FILT, PAN
        };

		/// <summary>Types of meter requests/messages</summary>
        public enum METER_TYPE
        {
            HOME, CHANNEL_PAGE, MIX_BUS, AUX_FX, IN_OUT, 
            SURFACE, CHANNEL_DETAIL, BUS_SEND, MATRIX_SEND,
            EFFECTS
        }

    };

    public class Level
    {
        public float m_fRawLevel { get; set; }
        public float m_fDbFSLevel { get; set; }
        public int m_nSteps { get; set; }

        public Level(float dbLevel, int steps)
        {
            m_nSteps = steps;
            if (dbLevel < -100 || dbLevel > 10)
            {
                m_fDbFSLevel = -100;
            }
            else
            {
                m_fDbFSLevel = dbLevel;
            }
            getRaw(m_fDbFSLevel);
        }

        protected void getRaw(float fDB)
        {
            m_fRawLevel = fDB;
            if (fDB < -100 || fDB > 10)
                if (fDB < -60)
                {
                    m_fRawLevel.Remap(-100, 0.0f, -60, .0625f);
                }
            if (fDB < -30)
            {
                m_fRawLevel.Remap(-60, 0.0625f, -30, .25f);
            }
            if (fDB < -10)
            {
                m_fRawLevel.Remap(-30, 0.25f, -10, .5f);
            }
            if (fDB <= 10)
            {
                m_fRawLevel.Remap(-10, 0.5f, 10, 1.0f);
            }
        }


    };
    public static class ExtensionMethods
    {
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }
}