using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
# if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
# else
        Application.Quit();
# endif
    }
}