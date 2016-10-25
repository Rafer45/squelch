using UnityEngine;
using System.Collections;

public class RollForMisfortune : MonoBehaviour {

    public float chance;
    public float maxChance = 1;
    public float growthRate;
    private GameObject coin;

    private float maxChanceAss;
    void Awake () {
        maxChanceAss = (maxChance - chance)/5;
    }

    public void MaybeSpawn (float height) {
        
        // It's called ass because it's kind of a magic
        // number that uses as's'ymptotes.
        // Confusing, but it works well when paired up
        // with online graphing software.

        // Oh. That makes it sound even worse.

        // Well, someone'll probably tell me how to
        // improve this.
        // Someday.
        float ass = -MathFun.AsymptoteFn(height*growthRate, 131072
                                        ,160
                                        ,-5);

        float odds = chance + ass*maxChanceAss;
        float roll = Random.Range(0f,1f);
        if (roll < odds) {
            gameObject.SetActive(true);
            gameObject.BroadcastMessage("ImportAss", ass);
        }
    }

}
