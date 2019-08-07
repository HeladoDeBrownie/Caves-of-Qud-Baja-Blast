using System;
using System.Collections.Generic;
using System.Text;
using XRL.Core;
using XRL.Rules;
using XRL.World;
using XRL.World.Parts;

namespace XRL.Liquids
{
	[Serializable]
	internal class LiquidBajaBlast : BaseLiquid
	{
		//
		// Static Fields
		//
		public new const int ID = 16;

		public new const string Name = "convalessence";

		[NonSerialized]
		public static List<string> Colors = new List<string> (2) {
			"C",
			"Y"
		};

		//
		// Constructors
		//
		public LiquidBajaBlast () : base (ID, Name, 350, 200, 2)
		{
		}

		//
		// Methods
		//
		public override void BeforeRender (LiquidVolume Liquid, Event eRender)
		{
			Physics physics = Liquid.ParentObject.GetPart ("Physics") as Physics;
			physics.CurrentCell.ParentZone.AddLight (physics.CurrentCell.X, physics.CurrentCell.Y, 2);
		}

		public override void BeforeRenderSecondary (LiquidVolume Liquid, Event eRender)
		{
			Physics physics = Liquid.ParentObject.GetPart ("Physics") as Physics;
			physics.CurrentCell.ParentZone.AddLight (physics.CurrentCell.X, physics.CurrentCell.Y, 1);
		}

		public override bool Drank (LiquidVolume Liquid, int Volume, GameObject Target, StringBuilder Message, ref bool ExitInterface)
		{
			Message.Append ("It's effervescent!");
			return true;
		}

		public override bool Froze (LiquidVolume Liquid)
		{
			Physics pPhysics = Liquid.ParentObject.pPhysics;
			if (pPhysics != null && pPhysics.CurrentCell != null) {
				GameObject gameObject = GameObjectFactory.Factory.CreateObject ("CryoGas");
				Gas gas = gameObject.GetPart ("Gas") as Gas;
				gas.Density = Liquid.Volume / 20;
				pPhysics.CurrentCell.AddObject (gameObject);
			}
			Liquid.ParentObject.Destroy (false);
			return false;
		}

		public override string GetAdjective (LiquidVolume Liquid)
		{
			if (Liquid == null || Liquid.ComponentLiquids [16] > 0) {
				return "&Cbaja";
			}
			return null;
		}

		public override string GetColor ()
		{
			return "C";
		}

		public override List<string> GetColors ()
		{
			return LiquidBajaBlast.Colors;
		}

		public override string GetName (LiquidVolume Liquid)
		{
			return "&Cbaja blast";
		}

		public override int GetNavigationWeight (LiquidVolume Liquid, GameObject GO, bool Smart, bool Slimewalking, ref bool Uncacheable)
		{
			return 0;
		}

		public override string GetPreparedCookingIngredient ()
		{
			return "coldMinor,regenLowtierMinor";
		}

		public override string GetSmearedName (LiquidVolume Liquid)
		{
			return "&Cbaja";
		}

		public override void ObjectInCell (LiquidVolume Liquid, GameObject GO)
		{
			if (Liquid.MaxVolume == -1) {
				if (GO.GetIntProperty ("Inorganic", 0) == 0) {
					GO.Heal (1, false, true, true);
				}
				if (GO.pPhysics.Temperature > 5) {
					GO.pPhysics.Temperature -= 20;
				}
				Liquid.ParentObject.pPhysics.Temperature = 5;
			}
		}

		public override void RenderBackground (LiquidVolume Liquid, RenderEvent eRender)
		{
			eRender.ColorString = "^C" + eRender.ColorString;
		}

		public override void RenderPrimary (LiquidVolume Liquid, RenderEvent eRender)
		{
			Physics physics = Liquid.ParentObject.GetPart ("Physics") as Physics;
			if (physics.Temperature <= physics.FreezeTemperature) {
				eRender.RenderString = "~";
				eRender.ColorString = "&C^Y";
			}
			else {
				Render render = Liquid.ParentObject.GetPart ("Render") as Render;
				int num = (XRLCore.CurrentFrame + Liquid.nFrameOffset) % 60;
				if (Stat.RandomCosmetic (1, 60) == 1 || render.ColorString == "&b") {
					if (num < 15) {
						render.RenderString = string.Empty + '÷';
						render.ColorString = "&Y^C";
					}
					else if (num < 30) {
						render.RenderString = "~";
						render.ColorString = "&Y^C";
					}
					else if (num < 45) {
						render.RenderString = " ";
						render.ColorString = "&Y^C";
					}
					else {
						render.RenderString = "~";
						render.ColorString = "&Y^C";
					}
				}
			}
		}

		public override void RenderSecondary (LiquidVolume Liquid, RenderEvent eRender)
		{
			eRender.ColorString += "&C";
		}

		public override void RenderSmearPrimary (LiquidVolume Liquid, RenderEvent eRender)
		{
			int num = XRLCore.CurrentFrame % 60;
			if (num > 5 && num < 15) {
				eRender.ColorString = "&C";
			}
			base.RenderSmearPrimary (Liquid, eRender);
		}
	}
}
