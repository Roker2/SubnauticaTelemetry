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

        [Toggle("Enable damage")]
        public bool enableDamageEffect = true;
    }
}
