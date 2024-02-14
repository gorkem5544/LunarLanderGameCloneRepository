using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;
    private float _currentTime = 0;
    public float CurrentTime { get => _currentTime; set => _currentTime = value; }

    private void LateUpdate()
    {
        _currentTime += Time.deltaTime;
        System.TimeSpan ts = System.TimeSpan.FromSeconds(_currentTime);
        _timeText.text = $"TIME {string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds)}";
    }
}
