using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private Counter _counter;

    private void OnEnable()
    {
        if (_counter != null)
            _counter.CounterChanged += UpdateView;
    }

    private void OnDisable()
    {
        if (_counter != null)
            _counter.CounterChanged -= UpdateView;
    }

    private void OnValidate()
    {
        if (_timerText == null)
        {
            _timerText = GetComponent<TextMeshProUGUI>();
        }
    }
    
    private void UpdateView(int counter)
    {
        _timerText.text = counter.ToString();
    }
}