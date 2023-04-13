# Subnautica Telemetry Library

## About it

It is a small game modification, which creates and provides telemetry data for force feedback. Telemetry types:

* Water pressure;
* No oxygen;
* Eat and drink;
* No food;
* No water;
* Damage;
* Self scanning.

It is main mod for telemetry. Mods with force feedback implementation for device are secondary.

## How to add support for my device

You need to create a new mod and add `SubnauticaTelemetry.dll` to dependencies. After this you also need to create `SubnauticaTelemetry.ForceFeedback.IForceFeedbackProcessor` implementation and add FF processor object to main mod. You can check example [here](https://github.com/Roker2/MockSubnauticaTelemetry).

## I want to test it without any devices/see some logs

You can install [MockSubnauticaTelemetry](https://github.com/Roker2/MockSubnauticaTelemetry), it is a simple force feedback implementation, which writes telemetry data to log.
