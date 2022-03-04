using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    public PillarManager PM;
    public Material Grey;
    public bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            Bot bot = other.GetComponent<Bot>();
            if (bot.SkillFit)
            {
                bot.SkillFit = false;
                bot.MoveBack();
                PM.CurrentPillar = null;
                PM.busy = false;
                this.GetComponent<Renderer>().material = Grey;
                active = false;
            }
        }
    }
}
