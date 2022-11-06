using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{


    public class State : MonoBehaviour{
        public Entity entity;
        public virtual void OnEnter(){}
        public virtual void OnLeave(){}
    }

    private State _state;

    public void OnEnable()
    {
        
        if(_state == null)
        {
            SetDefaultState();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SetDefaultState()
    {
        
    }

    public State GetState()
    {
        return _state;
    }

    public State SetState<T>() where T : State
    {
        if(_state != null)
        {
            _state.OnLeave();
            Destroy(_state);
        }

        _state = gameObject.AddComponent<T>();
        _state.entity = this;
        _state.OnEnter();
        return _state;
    }
}
