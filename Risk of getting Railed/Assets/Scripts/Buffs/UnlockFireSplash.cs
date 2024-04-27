
using Unity.VisualScripting;
using UnityEngine;

public class UnlockFireSplash : Buff {

    public UnlockFireSplash() {
        desc = $"Unlock Fire Breathing (gives enemy burn effect that incraeses the damage you deal)";
        title = "New Attack";
        type = "New";
    }

    public override void Perform(Unit player) {
        base.Perform(player);

        DifficultyProps diffProps = GameObject.Find("DIFFICULTY_PROPERTIES") ? GameObject.Find("DIFFICULTY_PROPERTIES").GetComponent<DifficultyProps>() : null;
        float dmgMult = diffProps ? diffProps.PlrAtkMult : 1;


        AudioSource audioSource = player.transform.Find("FIRE_SFX")?.GetComponent<AudioSource>();

        if (!audioSource) {
            AudioClip audioClip = Resources.Load<AudioClip>("Sounds/Moves/HeavyStomp");

            audioSource = player.gameObject.AddComponent<AudioSource>();
            audioSource.name = "FIRE_SFX";
            audioSource.clip = audioClip;
        }


        player.Moves.Add(new FireSplash(audioSource, dmgMult));
    }
}