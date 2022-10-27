using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Students : Entity
{
    public void OnEnable() 
    {
        base.OnEnable();
    }

    public override void SetDefaultState()
    {
        SetState<StudentsWalkingState>();
    }
}
