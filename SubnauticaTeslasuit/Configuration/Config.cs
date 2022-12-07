using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;

namespace SubnauticaTeslasuit.Configuration
{
    [Menu("Teslasuit Force Feedback")]
    class Config: ConfigFile
    {
        [Toggle("Enable water pressure")]
        public bool enableWaterPressureEffect = true;
    }
}
