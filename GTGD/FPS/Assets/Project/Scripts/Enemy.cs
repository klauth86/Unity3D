using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    #region MyRegion

    public static List<Enemy> ActiveEnemies;

    static Enemy() {
        ActiveEnemies = new List<Enemy>();
    }

    #endregion

    [SerializeField] private LayerMask _searchMask;

	// Use this for initialization
	void Start () {
        ActiveEnemies.Add(this);
        StartCoroutine(SearchPlayerRoutine());
	}

    private IEnumerator SearchPlayerRoutine() {
        var tr = transform;
        var rb = GetComponent<Rigidbody>();
        var nma = GetComponent<NavMeshAgent>();

        while (rb.isKinematic) {
            yield return new WaitForSeconds(0.0125f);

            var hits = Physics.OverlapSphere(tr.position, 10, _searchMask);
            if (hits != null && hits.Length >0 && nma.enabled) {
                nma.destination = hits[0].transform.position;
            }
        }
    }
}
