using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataEntry
{
    public float Angle { get; set; }
    public float AngleTargetHigh = Mathf.PI * 2;
    public float AngleTargetLow = Mathf.PI * -2;
    public Vector2 LastPoint { get; set; }
    public PlanetScript TargetPlanet { get; set; }
    public PlanetDataEntry(float angle, Vector2 lastPoint, PlanetScript targetPlanet)
    {
        Angle = angle;
        LastPoint = lastPoint;
        TargetPlanet = targetPlanet;
    }

    public bool CheckAndUpdate(float angleChange, Vector2 position)
    {
        Angle += angleChange;
        LastPoint = position;
        bool ret =  Angle < AngleTargetLow || Angle > AngleTargetHigh;
        AngleTargetLow = Mathf.Max(Angle - Mathf.PI*2, AngleTargetLow);
        AngleTargetHigh = Mathf.Min(Angle + Mathf.PI * 2, AngleTargetHigh);
        return ret;
    }
}
