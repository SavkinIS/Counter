using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _tickRate = 0.5f;
    [SerializeField] private InputReader  _inputReader;

    private int _currentTime;
    private bool _isTicking;
    private bool _isRunning;
    private float _elapsedTime;

    public event Action<int> CounterChanged;

    private void Start()
    {
        _isRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    private void ChangeTickingState()
    {
        _isTicking = !_isTicking;
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForFixedUpdate();

        while (_isRunning)
        {
            if (_isTicking)
            {
                _elapsedTime += Time.deltaTime;

                if (_elapsedTime >= _tickRate)
                {
                    _elapsedTime -= _tickRate;
                    _currentTime++;
                    CounterChanged?.Invoke(_currentTime);
                }
            }
            else
            {
                _elapsedTime = 0f;
            }

            yield return null;
        }
    }

    private void OnEnable()
    {
       if (_inputReader != null)
           _inputReader.LeftMouseClicked += ChangeTickingState;
    }

    private void OnDisable()
    {
        if (_inputReader != null)
        _inputReader.LeftMouseClicked -= ChangeTickingState;
    }
    
    private void OnDestroy()
    {
        CounterChanged = null;
    }
}