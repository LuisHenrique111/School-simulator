using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Variables
{
    /// <summary>
    /// Main variable base class
    /// </summary>
    public class Variable : ScriptableObject
    {
        #region Public Fields
        public bool named = false;
        public string variableName;

        public UnityEvent OnValueChanged;
        #endregion
    
        #region Public Properties
        public virtual object AsObject => null;
        public virtual Type ValueType => null;
        #endregion

        #region Public Methods
        public override string ToString() => "?";
        public virtual bool TryToSetValue(object value) { return false; }
        #endregion
    }
}
