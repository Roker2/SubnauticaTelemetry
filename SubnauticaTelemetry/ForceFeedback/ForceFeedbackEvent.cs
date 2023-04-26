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

using UnityEngine;

namespace SubnauticaTelemetry.ForceFeedback
{
    public struct ForceFeedbackEvent
    {
        /// <summary>
        /// Type of event
        /// </summary>
        public ForceFeedbackType Type;
        /// <summary>
        /// Power of event
        /// </summary>
        public float Multiplier;
        /// <summary>
        /// Position of event trigger, it can be (0, 0, 0) for some events
        /// </summary>
        public Vector3 Position;

        public ForceFeedbackEvent(ForceFeedbackType type, float multiplier = 1f, Vector3 position = new Vector3())
        {
            Type = type;
            Multiplier = multiplier;
            Position = position;
        }

        public override string ToString()
        {
            return $"Type: {Type}, Multiplier: {Multiplier}, Direction: {Position}";
        }
    }
}
