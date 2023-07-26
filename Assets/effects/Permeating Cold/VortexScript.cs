using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexScript : MonoBehaviour
{
    [SerializeField] List<GameObject> emitters;
    [SerializeField] List<Material> materials;
    float size;
    public float time;
    List<float> intensities = new List<float>();
    List<float> radiusSizes = new List<float>();
    List<float> radialForces = new List<float>();

    private void Start()
    {
        for (int i = 0; i < emitters.Count; i++)
        {
            var sh = emitters[i].GetComponent<ParticleSystem>().shape;
            radiusSizes.Add(sh.radius);
            var vl = emitters[i].GetComponent<ParticleSystem>().velocityOverLifetime;
            radialForces.Add(vl.radial.constant);
        }
        materials[0].SetFloat("_intensity", 1);
        materials[1].SetFloat("_intensity", 0.4f);
        materials[2].SetFloat("_intensity", 0.7f);

        for (int i = 0; i < materials.Count; i++)
        {
            intensities.Add(materials[i].GetFloat("_intensity"));
            materials[i].SetFloat("_intensity", 0);
        }
    }
    void Update()
    {
        time += Time.smoothDeltaTime;

        if (time >= 1.5f) 
        { 
            for (int i = 0; i < emitters.Count; i++)
            {
                materials[i].SetFloat("_intensity", materials[i].GetFloat("_intensity") - Time.deltaTime);
            }
        }
        else
        {
            for (int i = 0; i < emitters.Count; i++)
            {
                if (materials[i].GetFloat("_intensity") <= intensities[i])
                {
                    materials[i].SetFloat("_intensity", materials[i].GetFloat("_intensity") + Time.deltaTime);
                }
            }
        }
    }
}
