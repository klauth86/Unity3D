using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    [SerializeField] private GameObject _vfx;

    internal void Success()
    {
        StartCoroutine(PlaySuccess());
    }

    private IEnumerator PlaySuccess()
    {
        _vfx.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
