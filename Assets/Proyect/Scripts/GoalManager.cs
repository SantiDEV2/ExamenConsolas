using UnityEngine;

public class GoalManager: MonoBehaviour
{
    private int _lifes = 15;

    public delegate void OnAction(int score);
    public event OnAction onGoalScored;

    public GameObject goalBarrier;

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

        other.gameObject.SetActive(false);
        _lifes--;
        onGoalScored?.Invoke(_lifes);   
    }
}
