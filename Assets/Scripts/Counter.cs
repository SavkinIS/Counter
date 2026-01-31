using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int m_leftMousebutton = 0;

    [SerializeField] private float _tickRate = 0.5f;

    private int _currentTime;
    private bool _isTicking;
    private bool _isRunning;
    private float _elapsedTime;

    public event Action<int> OnCounterChanged;

    private void Start()
    {
        _isRunning = true;
        OnCounterChanged += (timer) 
            => { Debug.Log($"Timer Tick {timer}"); };

        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForFixedUpdate();

        while (_isRunning)
        {
            if (Input.GetMouseButtonDown(m_leftMousebutton))
            {
                _isTicking = !_isTicking;

                if (_isTicking)
                    Debug.Log($"Timer is running");
                else
                    Debug.Log($"Timer is paused");
            }

            if (_isTicking)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime >= _tickRate)
                {
                    _elapsedTime -= _tickRate;
                    _currentTime++;
                    OnCounterChanged?.Invoke(_currentTime);
                }
            }
            else
            {
                _elapsedTime = 0f;
            }

            yield return null;
        }
    }
    
    private void OnDestroy()
    {
        OnCounterChanged = null;
    }
}