using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Counter _counter;

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
    
    private void UpdateView(int counter)
    {
        _timerText.text = counter.ToString();
    }
}