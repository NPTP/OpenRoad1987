using System.Collections;
using Movement;
using UnityEngine;

namespace Audio
{
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip engine;

        [SerializeField] [Range(0, 1)] private float pitchMin = 0.25f;
        [SerializeField] [Range(1, 3)] private float pitchMax = 1.05f;

        private PlayerMovement playerMovement;

        private AudioSource audioSource;
        private Coroutine fadeOutRoutine = null;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            audioSource = GetComponent<AudioSource>();

            audioSource.loop = true;
            audioSource.clip = engine;
        }

        private void Update()
        {
            float normalizedValue = playerMovement.AccelCurve;
            bool isPlaying = audioSource.isPlaying;
            if (normalizedValue > float.Epsilon)
            {
                if (fadeOutRoutine != null)
                {
                    StopCoroutine(fadeOutRoutine);
                    fadeOutRoutine = null;
                    audioSource.volume = 1.0f;
                }
                
                if (!isPlaying)
                {
                    audioSource.Play();
                }
                
                audioSource.pitch = Mathf.Clamp(pitchMin + normalizedValue * (pitchMax - pitchMin), pitchMin, pitchMax);
            }
            else if (isPlaying && fadeOutRoutine == null)
            {
                fadeOutRoutine = StopFadeOut(audioSource, 0.25f);
            }
        }

        private Coroutine StopFadeOut(AudioSource audioSrc, float duration)
        {
            return StartCoroutine(StopFadeOutCoroutine(audioSrc, duration));
        }

        private IEnumerator StopFadeOutCoroutine(AudioSource audioSrc, float duration)
        {
            float elapsed = 0.0f;
            float currentVolume = audioSrc.volume;
            while (elapsed < duration)
            {
                audioSrc.volume = Mathf.Lerp(currentVolume, 0.0f, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            audioSrc.volume = 0.0f;
        }
    }
}
