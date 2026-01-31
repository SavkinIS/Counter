using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private Counter _counter;

    private void UpdateView(int counter)
    {
        _timerText.text = counter.ToString();
    }

    private void OnEnable()
    {
        if (_counter == null)
            _counter = FindFirstObjectByType<Counter>();

        if (_counter != null)
            _counter.OnCounterChanged += UpdateView;
    }

    private void OnDestroy()
    {
        if (_counter != null)
            _counter.OnCounterChanged -= UpdateView;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.OnCounterChanged -= UpdateView;
    }
    
    private void OnValidate()
    {
        if (_timerText == null)
        {
            _timerText = GetComponent<TextMeshProUGUI>();
        }
    }
}