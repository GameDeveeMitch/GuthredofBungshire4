using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class BreakableBlockScript : BlockManager
{
    private void OnEnable()
    {
        HighLightBlockTurnOff();
    }
    public override void HighLightBlockTurnOff()
    {
        base.HighLightBlockTurnOff();
    }
    public override void DestroyBlock()
    {
        base.DestroyBlock();
    }
    public override void LightItUp()
    {
        base.LightItUp();
    }
}
