using UnityEngine;
using UnityEngine.AI;

public class BulletCube : MonoBehaviour {

    [SerializeField] private float _explodionForce;
    [SerializeField] private float _explodionRadius;
    [SerializeField] private LayerMask _explodionLayer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.transform.name);
        Destroy(gameObject);
        var hits = Physics.OverlapSphere(transform.position, _explodionRadius, _explodionLayer);
        foreach (var item in hits) {
            var rb = item.gameObject.GetComponent<Rigidbody>();
            if (rb) {
                rb.isKinematic = false;

                var nma = item.gameObject.GetComponent<NavMeshAgent>();
                if (nma) nma.enabled = false;

                var enemy = item.gameObject.GetComponent<Enemy>();
                if (enemy) {
                    Enemy.ActiveEnemies.Remove(enemy);
                    if (Enemy.ActiveEnemies.Count == 0) {
                        Manager.Instance.ShowMessage("Whoaahah!? Beaten by sucker like you!!!");
                    }
                }
                rb.AddExplosionForce(_explodionForce, transform.position, _explodionRadius);
            }
        }
    }
}
