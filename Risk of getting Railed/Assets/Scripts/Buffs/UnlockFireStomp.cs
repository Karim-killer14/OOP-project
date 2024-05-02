
using Unity.VisualScripting;
using UnityEngine;

public class UnlockFireStomp : Buff {

    public UnlockFireStomp() {
        desc = $"Unlock Fire Stomp (60 attack dmg, 1 turn cooldown)";
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
        FireStomp fireStomp = new FireStomp(player.gameObject.GetComponent<AudioSource>(), dmgMult) {
            Cooldown = 1,
            damage = 60 * dmgMult
        };
        player.Moves.Add(fireStomp);
    }
}