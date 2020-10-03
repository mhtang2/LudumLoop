using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDataEntry
{
    public double Score { get; set; }
    public Vector2 LastPoint { get; set; }
    public PlanetScript TargetPlanet { get; set; }

    public PlanetDataEntry(double score, Vector2 lastPoint, PlanetScript targetPlanet)
    {
        Score = score;
        LastPoint = lastPoint;
        TargetPlanet = targetPlanet;
    }
}
