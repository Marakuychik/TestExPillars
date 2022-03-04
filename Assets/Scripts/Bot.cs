using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public PillarManager PM;
    public Material[] Mats = new Material[2];
    public GameObject Target = null;
    Vector3 StartPos;
    public bool SkillFit = false;
    void Start()
    {
        Renderer[] SkillRenderers = GetComponentsInChildren<Renderer>();
        for (int i = 1; i <= Mats.Length; i++)
        {
            Mats[i-1] = SkillRenderers[i].material;
        }
        StartPos = transform.position;
    }

    void FixedUpdate()
    {
        Target = PM.CurrentPillar;
        if (Target != null)
            for (int i = 0; i < Mats.Length; i++)
            {
                if (Mats[i].color == Target.GetComponent<Renderer>().material.color)
                {
                    SkillFit = true;
                    break;
                }
            }
        else
        {
            MoveBack();
            SkillFit = false;
        }
        if (SkillFit) Move();
    }

    void Move()
    {
        if (Target != null)
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 0.05f); 
    }

    public void MoveBack()
    {
        transform.position = StartPos;
    }
}
