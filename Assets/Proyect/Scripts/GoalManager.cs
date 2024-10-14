using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [System.Serializable]
    public class GoalUI
    {
        public LifeManager assignedGoal;
        public TextMeshProUGUI lifeText;
    }

    [SerializeField] private List<GoalUI> goalsUI = new List<GoalUI>();

    private void OnEnable()
    {
        foreach (GoalUI goalUI in goalsUI)
        {
            goalUI.assignedGoal.onGoalScored += (updatedlife) => UpdateLife(goalUI, updatedlife);
        }
    }

    private void OnDisable()
    {
        foreach(GoalUI goalUI in goalsUI)
        {
            goalUI.assignedGoal.onGoalScored -= (updatedlife) => UpdateLife(goalUI, updatedlife);
        }
    }

    private void UpdateLife(GoalUI goalUI, int updatedLife)
    {
        goalUI.lifeText.text = updatedLife.ToString();
    }
}
