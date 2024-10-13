using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    [Header("Instances")]
    public GameObject ballPrefab;

    [Header("Spawn Positions")]
    [SerializeField] private Transform[] _ballOrigins;

    private List<GameObject> _balls = new List<GameObject>();
    private int amountToBalls = 15;

    private void Start()
    {
        for (int i = 0; i < amountToBalls; i++)
        {
            GameObject obj = Instantiate(ballPrefab);
            obj.SetActive(false);
            _balls.Add(obj);
        }

        StartCoroutine(OnBallSpawn());
    }

    public GameObject GetBallObject()
    {
        for(int i = 0; i < _balls.Count; i++)
        {
            if (!_balls[i].activeInHierarchy)
            {
                return _balls[i];
            }
        }
        return null;
    }

    private IEnumerator OnBallSpawn ()
    {
        while (true)
        {
            int index = Random.Range(0, _ballOrigins.Length);

            GameObject newBall = GetBallObject();
            if (newBall != null) { newBall.transform.position = _ballOrigins[index].transform.position; newBall.SetActive(true); }

            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            rb.velocity = (Vector3.zero - newBall.transform.position).normalized; 
            yield return new WaitForSeconds(2.5f);
        }
    }
}
