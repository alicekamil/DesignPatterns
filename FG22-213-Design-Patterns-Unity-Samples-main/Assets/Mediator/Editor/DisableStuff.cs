using System;
using UnityEditor;
using UnityEngine;

namespace Mediator.Editor
{
    public class DisableStuff : EditorWindow
    {
        private void Awake()
        {
            // on save scene
            // disable all popups in case they're active
        }
    }
}