using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public static SoundEffects instance;
    public GameObject defaultSource;
    public SoundEffectWithName[] audioLibrary;

    private void Awake() {
        instance = this;
    }

    public static void PlayAudioAtLocation(string name, Vector3 worldSpacePosition) {
        Debug.Log("Will play " + name + " at location " + worldSpacePosition);
        instance._PlayAudioAtLocation(name, worldSpacePosition);
    }

    public void _PlayAudioAtLocation(string name, Vector3 worldSpacePosition) {
        AudioClip clip = GetAudioClip(name);
        AudioSource instantiatedSource = Instantiate(defaultSource, worldSpacePosition, Quaternion.identity).GetComponent<AudioSource>();
        DestroyAfterSeconds autoDestroyer = instantiatedSource.gameObject.AddComponent<DestroyAfterSeconds>();
        autoDestroyer.WaitAndDestroy(clip.length + 0.5f);
        instantiatedSource.clip = clip;
        instantiatedSource.Play();
    }

    AudioClip GetAudioClip(string name) {
        foreach(SoundEffectWithName namedEffect in audioLibrary) {
            if (namedEffect.name == name)
                return namedEffect.clip;
        }
        Debug.LogError("ERROR: No audioclip matching name: " + name);
        return null;
    }



    [System.Serializable]
    public class SoundEffectWithName {
        public string name;
        public AudioClip clip;
    }
}
