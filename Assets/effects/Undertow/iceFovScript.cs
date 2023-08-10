using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceFovScript : MonoBehaviour
{
    public float lifetime;
    public List<GameObject> gameObjects;
    public GameObject Card;

    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= 1.4)
        {
            foreach (GameObject go in gameObjects)
            {
                go.active = false;
            }
        }
        /*if (lifetime >= 1.4)
        {
            if (Card.transform.localScale.x > 0)
            {
                Card.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            }
        }*/
    }
}
