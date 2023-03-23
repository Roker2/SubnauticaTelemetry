# Subnautica Telemetry Library

## About it

It is a small game modification, which create and provide telemetry data for force feedback. Telemetry types:

* Water pressure;
* No oxygen;
* No food;
* No water;
* Damage.

It is master modification for telemetry, modifications with force feedback implementation for device are secondary modifications.

## How to add support for my device

You should to create a new modification and add `SubnauticaTelemetry.dll` to dependencies. After this you need to create `SubnauticaTelemetry.ForceFeedback.IForceFeedbackProcessor` implementation and add FF processor object to master modification. You can check example [here](https://github.com/Roker2/MockSubnauticaTelemetry).

## I want to test it without any devices/watch logs

You can install [MockSubnauticaTelemetry](https://github.com/Roker2/MockSubnauticaTelemetry), it is a simple force feedback implementation, which write telemetry data to log.