using UnityEngine;

public class Character:MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private protected float speed = 1f;
    public bool isAlive = true;

    [Header("Direction")]
    public bool xAxis;

    [Header("Borders")]
    [SerializeField] private protected float boundaries = 2.7f;

    [Header("Functionability")]
    [SerializeField] private LifeManager assignedGoal;

    protected virtual void Move(Vector3 direction)
    {
        if (GameManager.isPaused)
            return;

        transform.position += direction * speed * Time.deltaTime;

        if (xAxis)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -boundaries, boundaries), transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, -boundaries, boundaries));
        }
    }

    private void OnEnable()
    {
        if (assignedGoal != null)
        {
            assignedGoal.onGoalScored += UpdateLife;
        }
    }

    private void OnDisable()
    {
        if (assignedGoal != null)
        {
            assignedGoal.onGoalScored -= UpdateLife;
        }

    }

    protected virtual void UpdateLife(int updatedLife)
    {
        if (updatedLife == 0)
        {
            isAlive = false;
            GameManager.Instance.RemovePlayers(this);
            Destroy(this.gameObject);
        }

    }
}
