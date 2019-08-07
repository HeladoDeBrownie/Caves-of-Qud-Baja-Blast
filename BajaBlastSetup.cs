using System;
using UnityEngine;
using XRL.Liquids;

namespace XRL.World.Parts {
    public class helado_BajaBlastSetup : IPart {
        static helado_BajaBlastSetup () {
            ReplaceLiquid ("convalessence", new LiquidBajaBlast ()); }

        private static void ReplaceLiquid(String Name, BaseLiquid NewLiquid) {
            var oldLiquid = LiquidVolume.ComponentLiquidNameMap[Name];
            LiquidVolume.ComponentLiquidTypes[oldLiquid.ID] = NewLiquid;
            LiquidVolume.ComponentLiquidNameMap[Name] = NewLiquid; } } }
