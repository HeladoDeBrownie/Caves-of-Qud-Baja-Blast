using UnityEngine;
using XRL.Liquids;

namespace XRL.World.Parts
{
    public class BajaBlastSetup : IPart
    {
        public BajaBlastSetup ()
        {
            LiquidVolume.ComponentLiquidTypes[16] = new LiquidConvalessence();
            LiquidVolume.ComponentLiquidNameMap["convalessence"] = LiquidVolume.ComponentLiquidTypes[16];
        }
    }
}
