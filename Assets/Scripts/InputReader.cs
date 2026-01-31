using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int m_leftMousebutton = 0;
    
    public event Action LeftMouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(m_leftMousebutton))
        {
            LeftMouseClicked?.Invoke();
        }
    }

    private void OnDestroy()
    {
        LeftMouseClicked =  null;
    }
}