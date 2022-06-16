using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    ShapeSettings settings;
    INoiseFilter[] noiseFilter;
    public minMax elevationMinMax;

    public void UpdateSettings(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new INoiseFilter[settings.noiseLayers.Length];
        for (int i = 0; i < noiseFilter.Length; i++)
        {
            noiseFilter[i] = NoiseFilterFactory.CreateNoiseFiler(settings.noiseLayers[i].noiseSettings);
        }
        elevationMinMax = new minMax();
    }

    public Vector3 CalculatePointOnPlanet(Vector3 poinOnUnitSphere)
    {
        float firstLayerValue = 0;
        float elevation = 0;

        if(noiseFilter.Length > 0)
        {
            firstLayerValue = noiseFilter[0].Evaluate(poinOnUnitSphere);

            if(settings.noiseLayers[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }

        for (int i = 1; i < noiseFilter.Length; i++)
        {
            if(settings.noiseLayers[i].enabled)
            {
                float mask = (settings.noiseLayers[i].useFirstLayerAsMask) ? firstLayerValue : 1;
                elevation += noiseFilter[i].Evaluate(poinOnUnitSphere) * mask;
            }
        }
        elevation = settings.planetRadius * (1 + elevation);
        elevationMinMax.AddValue(elevation);
        return poinOnUnitSphere * elevation;
    }
}
