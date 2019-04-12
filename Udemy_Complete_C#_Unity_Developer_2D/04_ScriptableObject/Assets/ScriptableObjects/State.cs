using UnityEngine;

[CreateAssetMenu(menuName = "StateAsset")]
public class State : ScriptableObject {
    [TextArea(10, 14)][SerializeField]string _text;
}
