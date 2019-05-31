using UnityEngine;
using UnityEngine.AI;

public class BulletCube : MonoBehaviour {

    [SerializeField] private float _explodionForce;
    [SerializeField] private float _explodionRadius;
    [SerializeField] private LayerMask _explodionLayer;

    private void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
        var hits = Physics.OverlapSphere(transform.position, _explodionRadius, _explodionLayer);
        foreach (var item in hits) {
            var nma = item.gameObject.GetComponent<NavMeshAgent>();
            if (nma) nma.enabled = false;

            var rb = item.gameObject.GetComponent<Rigidbody>();
            if (rb) {
                rb.isKinematic = false;
                rb.AddExplosionForce(_explodionForce, transform.position, _explodionRadius);
            }

            var enemy = item.gameObject.GetComponent<Enemy>();
            if (enemy) {
                var cntBefore = Enemy.ActiveEnemies.Count;
                Enemy.ActiveEnemies.Remove(enemy);
                if (Enemy.ActiveEnemies.Count == 0 && cntBefore == 1) {
                    Manager.Instance.ShowMessage("Whoaahah!? Beaten by sucker like you!!!");
                }
            }
        }
    }
}
