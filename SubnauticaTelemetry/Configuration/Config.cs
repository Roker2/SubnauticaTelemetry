using SMLHelper.V2.Json;
using SMLHelper.V2.Options.Attributes;

namespace SubnauticaTelemetry.Configuration
{
    [Menu("Telemetry settings")]
    class Config: ConfigFile
    {
        [Toggle("Enable water pressure")]
        public bool enableWaterPressureEffect = true;
    }
}
