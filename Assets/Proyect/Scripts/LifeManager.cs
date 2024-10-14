using UnityEngine;

public class LifeManager: MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int _lifes = 15;

    public delegate void OnAction(int score);
    public event OnAction onGoalScored;

    [Header("Object Scene")]
    [SerializeField] private GameObject goalBarrier;

    private void Update()
    {
        if (_lifes == 0)
        {
            goalBarrier.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_lifes == 0)
            return;

        _lifes--;
        onGoalScored?.Invoke(_lifes);   
        other.gameObject.SetActive(false);
    }
}
