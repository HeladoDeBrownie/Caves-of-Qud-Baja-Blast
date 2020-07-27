using XRL.World.Parts;

namespace XRL.Liquids
{
    [IsLiquid]
    [System.Serializable]
    public class LiquidBajaBlast : LiquidConvalessence
    {
        public const string NAME = "{{C|baja blast}}";
        public const string ADJECTIVE = "{{C|baja}}";
        public const string STAINED_NAME = "{{C|baja-blast}}";

        public override string GetAdjective(LiquidVolume _)
        {
            return ADJECTIVE;
        }

        public override string GetName(LiquidVolume _)
        {
            return NAME;
        }

        public override string GetSmearedName(LiquidVolume _)
        {
            return ADJECTIVE;
        }

        public override string GetStainedName(LiquidVolume _)
        {
            return STAINED_NAME;
        }
    }
}
