using System;
using System.Collections.Generic;
using System.Text;
using XRL.Liquids;
using XRL.World;
using XRL.World.Parts;

namespace XRL.Liquids {
    [IsLiquid]
    public class LiquidBajaBlast : BaseLiquid {
        private static BaseLiquid Convalessence = LiquidVolume.getLiquid ("convalessence");

        public LiquidBajaBlast () : base (Convalessence.ID, Convalessence.FlameTemperature, Convalessence.VaporTemperature, Convalessence.Cooling) {}

        public override void BeforeRender (LiquidVolume Liquid, Event eRender) {
            Convalessence.BeforeRender (Liquid, eRender); }

        public override void BeforeRenderSecondary (LiquidVolume Liquid, Event eRender) {
            Convalessence.BeforeRenderSecondary (Liquid, eRender); }

        public override bool Drank (LiquidVolume Liquid, int Volume, GameObject Target, StringBuilder Message, ref bool ExitInterface) {
            return Convalessence.Drank (Liquid, Volume, Target, Message, ref ExitInterface); }

        public override bool Froze (LiquidVolume Liquid) {
            return Convalessence.Froze (Liquid); }

        public override string GetAdjective (LiquidVolume Liquid) {
            if (Liquid == null || Liquid.ComponentLiquids [Convalessence.ID] > 0) {
                return "&Cbaja"; }
            else {
                return null; } }

        public override string GetColor () {
            return Convalessence.GetColor (); }

        public override List<string> GetColors () {
            return Convalessence.GetColors (); }

        public override string GetName (LiquidVolume _) {
            return "&Cbaja blast"; }

        public override int GetNavigationWeight (LiquidVolume Liquid, GameObject GO, bool Smart, bool Slimewalking, ref bool Uncacheable) {
            return Convalessence.GetNavigationWeight (Liquid, GO, Smart, Slimewalking, ref Uncacheable); }

        public override string GetPreparedCookingIngredient () {
            return Convalessence.GetPreparedCookingIngredient (); }

        public override string GetSmearedName (LiquidVolume _) {
            return "&Cbaja"; }

        public override void ObjectInCell (LiquidVolume Liquid, GameObject GO) {
            Convalessence.ObjectInCell (Liquid, GO); }

        public override void RenderBackground (LiquidVolume Liquid, RenderEvent eRender) {
            Convalessence.RenderBackground (Liquid, eRender); }

        public override void RenderPrimary (LiquidVolume Liquid, RenderEvent eRender) {
            Convalessence.RenderPrimary (Liquid, eRender); }

        public override void RenderSecondary (LiquidVolume Liquid, RenderEvent eRender) {
            Convalessence.RenderSecondary (Liquid, eRender); }

        public override void RenderSmearPrimary (LiquidVolume Liquid, RenderEvent eRender) {
            Convalessence.RenderSmearPrimary (Liquid, eRender); } } }
