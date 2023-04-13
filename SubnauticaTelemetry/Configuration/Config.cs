using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;

namespace SubnauticaTelemetry.Configuration
{
    [Menu("Telemetry settings")]
    class Config: ConfigFile
    {
        [Toggle("Enable water pressure")]
        public bool enableWaterPressureEffect = true;

        [Toggle("Enable no oxygen")]
        public bool enableNoOxygenEffect = true;

        [Toggle("Eat and drink")]
        public bool enableEatAndDrink = true;

        [Toggle("Enable no food")]
        public bool enableNoFoodEffect = true;

        [Toggle("Enable no water")]
        public bool enableNoWaterEffect = true;

        [Toggle("Enable damage")]
        public bool enableDamageEffect = true;

        [Toggle("Enable self scanning")]
        public bool enableSelfScannigEffect = true;
    }
}
