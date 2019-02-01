using UnityEngine;

public class Block : MonoBehaviour {

    public static int Count = 0;

    [SerializeField]
    private GameObject _sparks;

    [SerializeField]
    private AudioClip _audio;

    [SerializeField]
    private SpriteRenderer _renderer;

    [SerializeField]
    private Sprite[] _sprites;

    private int _nums;

    private Loader _loader;

    void Start()
    {
        _loader = FindObjectOfType<Loader>();
        _nums = _sprites.Length;
        if (tag != "Unbreakable")
            Count++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position);
        if (tag != "Unbreakable")
        {
            _nums--;
            Config.Instance.AddToScore();
            if (_nums == 0)
            {
                Count--;
                if (_sparks != null)
                    Instantiate(_sparks, transform.position, transform.rotation);
                Destroy(gameObject);
                if (Count == 0)
                    _loader.LoadNextLevel();
            }
            else
            {
                _renderer.sprite = _sprites[_nums-1];
            }
        }
    }
}
