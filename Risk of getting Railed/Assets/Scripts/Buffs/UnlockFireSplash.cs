
using Unity.VisualScripting;
using UnityEngine;

public class UnlockFireSplash : Buff {

    public UnlockFireSplash() {
        desc = $"Unlock Fire Breathing (gives enemy burn effect that incraeses the damage you deal)";
        title = "New Attack";
        type = "FireSplash";
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.PlrAtkMult : 1;


        if (!player.transform.GetComponent<AudioSource>()) {
            AudioClip audioClip = Resources.Load<AudioClip>("Sounds/Moves/fireSFX");
            AudioSource newAudioSource = player.gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = audioClip;
        }


        player.Moves.Add(new FireSplash(player.transform.GetComponent<AudioSource>(), dmgMult));
    }
}