using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int LeftMouseButton = 0;
    
    public event Action LeftMouseClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            LeftMouseClicked?.Invoke();
        }
    }

    private void OnDestroy()
    {
        LeftMouseClicked =  null;
    }
}