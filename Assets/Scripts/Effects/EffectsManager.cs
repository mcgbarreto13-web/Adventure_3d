using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Core.Singleton;

public class EffectsManager : Singleton<EffectsManager>
{
   public PostProcessVolume postProcessVolume;
   public float duration = 1f;
   
   [SerializeField] private Vignette _vignette;

    [NaughtyAttributes.Button]
   public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }

    IEnumerator FlashColorVignette()
    {
        Vignette tmp;

        if(postProcessVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            _vignette = tmp;
        }
        UnityEngine.Rendering.PostProcessing.ColorParameter c = new UnityEngine.Rendering.PostProcessing.ColorParameter();
        
        float time = 0;
        while(time < duration)
        {
            c.value = Color.Lerp(Color.black, Color.red, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c.value);
            yield return new WaitForEndOfFrame();
        }
        time = 0;
          while(time < duration)
        {
            c.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c.value);
            yield return new WaitForEndOfFrame();
        }

        
    }
}
