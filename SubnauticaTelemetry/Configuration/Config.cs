/*
* This file is part of SubnauticaTelemetry
* Copyright (C) 2023 - Roker2
*
* This program is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* This program is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

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

        [Toggle("Enable eat and drink")]
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
