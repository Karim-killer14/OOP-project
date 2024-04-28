
using Unity.VisualScripting;
using UnityEngine;

public class UnlockFireStomp : Buff {

    public UnlockFireStomp() {
        desc = $"Unlock Fire Stomp";
        title = "New Attack";
        type = "FireStomp";
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.PlrAtkMult : 1;


        if (!player.transform.GetComponent<AudioSource>()) {
            AudioClip audioClip = Resources.Load<AudioClip>("Sounds/Moves/HeavyStomp");
            AudioSource newAudioSource = player.gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = audioClip;
        }
        player.Moves.Add(new FireStomp(player.gameObject.GetComponent<AudioSource>(), dmgMult));
    }
}