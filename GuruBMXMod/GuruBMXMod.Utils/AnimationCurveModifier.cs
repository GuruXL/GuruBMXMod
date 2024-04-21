using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GuruBMXMod.Utils
{
    internal class AnimationCurveModifier
    {
        public static void ModifyMinMaxCurve(AnimationCurve curve, float minValue, float maxValue, float time)
        {
            Keyframe[] keys = curve.keys;

            if (keys.Length == 2)
            {
                keys[0].value = minValue; // set the Min Value for the Curve

                keys[1].value = maxValue; // set the MAx Value for the Curve
                keys[1].time = time; // Set the Duration time for the Curve

                curve.keys = keys;
            }
            else
            {
                MelonLogger.Msg("Animation Curve Does Not Have 2 Keys to Modify");
            }
        }
    }
}
