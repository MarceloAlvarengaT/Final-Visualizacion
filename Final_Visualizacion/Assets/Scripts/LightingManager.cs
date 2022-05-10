using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPresets preset;

    [SerializeField, Range(0, 24)] private float timeOfDay;

    private void Update()
    {
        if(preset == null)
        {
            return;
        }
        if (Application.isPlaying)
        {
            timeOfDay += Time.deltaTime;
            timeOfDay %= 12;
            UpdateLighting(timeOfDay / 12f);
        }
        else
        {
            UpdateLighting(timeOfDay / 12f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.FogColor.Evaluate(timePercent);

        if(directionalLight != null)
        {
            directionalLight.color = preset.DirectionalColor.Evaluate(timePercent);

            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }



    //Encontrar una luz direccional si no hemos puesto una
    private void OnValidate()
    {
        if(directionalLight != null)
        {
            return;
        }
        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
