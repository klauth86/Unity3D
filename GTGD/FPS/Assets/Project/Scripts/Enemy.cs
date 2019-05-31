using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
            if (hits != null && hits.Length >0) {
                nma.destination = hits[0].transform.position;
            }
        }
    }
}
