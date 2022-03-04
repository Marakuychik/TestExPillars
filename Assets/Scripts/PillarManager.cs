using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    public GameObject[] Pillars = new GameObject[3];
    public Material[] Mats = new Material[3];
    public bool busy = false;
    public GameObject CurrentPillar = null;

    // Update is called once per frame
    void Update()
    {
        if (!busy)
        {
            busy = true;
            StartCoroutine(Recolor());
        }
    }

    IEnumerator Recolor()
    {
        yield return new WaitForSeconds(5);
        CurrentPillar = Pillars[Random.Range(0, Pillars.Length)];
        CurrentPillar.GetComponent<Renderer>().material = Mats[Random.Range(0, Mats.Length)];
        CurrentPillar.GetComponent<Pillar>().active = true;
    }
}
