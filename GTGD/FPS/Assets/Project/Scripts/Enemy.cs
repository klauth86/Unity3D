using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public static List<Enemy> ActiveEnemies;

    static Enemy() {
        ActiveEnemies = new List<Enemy>();
    }

	// Use this for initialization
	void Start () {
        ActiveEnemies.Add(this);
        StartCoroutine(SearchPlayerRoutine());
	}

    // Update is called once per frame
    void Update () {
		
	}

    private IEnumerator SearchPlayerRoutine() {
        var rb = GetComponent<Rigidbody>();
        var nma = GetComponent<NavMeshAgent>();
        while(rb.isKinematic) {
            yield return new WaitForSeconds(0.0125f);

            var hits = Physics.OverlapSphere(transform.position, 10, LayerMask.GetMask("Player"));
            if (hits != null && hits.Length >0 && nma.enabled) {
                nma.destination = hits[0].transform.position;
            }
        }
    }
}
