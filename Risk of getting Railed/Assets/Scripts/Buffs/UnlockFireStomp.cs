
using Unity.VisualScripting;
using UnityEngine;

public class UnlockFireStomp : Buff {

    public UnlockFireStomp() {
        desc = $"Unlock Fire Stomp";
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

        player.Moves.Add(new FireStomp(audioSource, dmgMult));
    }
}