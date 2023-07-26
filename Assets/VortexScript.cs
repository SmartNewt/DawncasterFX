using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexScript : MonoBehaviour
{
    [SerializeField] List<GameObject> emitters;
    [SerializeField] List<Material> materials;
    float size;
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
    }
    void Update()
    {
        for (int i =0; i < emitters.Count; i++)
        {
            if (size < 2)
            {
                size += Time.deltaTime * 0.1f;
                var sh = emitters[i].GetComponent<ParticleSystem>().shape;
                sh.radius = radiusSizes[i] + size;
                var vl = emitters[i].GetComponent<ParticleSystem>().velocityOverLifetime;
                vl.radial = radialForces[i] - size;
            }
            else
            {
                materials[i].SetFloat("_intensity", materials[i].GetFloat("_intensity")-Time.deltaTime*0.1f);
            }
        }
    }
}
