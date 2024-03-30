using UnityEngine;
using UnityEngine.UI;
public class Buff : MonoBehaviour {
    public string desc;
    public string type;
    public string name;
    public Sprite art;
    public virtual void Perform(Unit player) { }
}