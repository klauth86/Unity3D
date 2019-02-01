using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour {
    private WaveConfig _config;
    private List<Transform> wayPoints;
    private int _currentWayPoint;

	// Use this for initialization
	void Start () {
        _currentWayPoint = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    private void Move()
    {

        if (_config != null && wayPoints != null)
        {
            if (_currentWayPoint == wayPoints.Count - 1)
                Destroy(gameObject);
            if (Vector2.Distance(transform.position, wayPoints[_currentWayPoint].position) < 0.1)
                _currentWayPoint++;
            else
            {
                var delta = new Vector2(wayPoints[_currentWayPoint].position.x - transform.position.x,
                    wayPoints[_currentWayPoint].position.y - transform.position.y).normalized;

                transform.position = new Vector2(transform.position.x + delta.x * _config.GetSpeed() * Time.deltaTime,
                    transform.position.y + delta.y * _config.GetSpeed() * Time.deltaTime);
            }
        }        
    }

    public void SetWaveConfig(WaveConfig config)
    {
        _config = config;
        wayPoints = _config.GetWayPoints();
    }
}
