using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceFovScript : MonoBehaviour
{
    public float intensity;
    [SerializeField] Material material;

    private void OnEnable()
    {
        material.SetFloat("_intensity", 30);
        Debug.Log("lel");
    }

    void Update()
    {
        if (material.GetFloat("_intensity") >= 15)
            material.SetFloat("_intensity", material.GetFloat("_intensity")- Time.deltaTime * intensity);
    }
}
