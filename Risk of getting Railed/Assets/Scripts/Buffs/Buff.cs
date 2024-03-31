using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Buff : MonoBehaviour {
    public string desc;
    public string type;
    public string title;

    public virtual void Perform(Unit player) { }
    public void LoadInfoToUI(GameObject obj) {
        obj.transform.Find("BuffDesc").GetComponent<TextMeshProUGUI>().text = this.desc;
        obj.transform.Find("BuffName").GetComponent<TextMeshProUGUI>().text = this.title;
        obj.transform.Find("BuffType").transform.Find("BuffTypeText").GetComponent<TextMeshProUGUI>().text = this.type;

        Texture2D texture = Resources.Load<Texture2D>($"BuffAssets/{type}");
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        obj.transform.Find("BuffArt").GetComponent<Image>().sprite = sprite;
    }
}