using UnityEngine;


public class SpillBeer : MonoBehaviour
{
    private GameObject electric;
 
    // Start is called before the first frame update
    void Start()
    {
        electric = GameObject.Find("Extension_cable");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (electric)
        {
            if (Vector3.Distance(this.transform.position, electric.transform.position) < 1.0f)
            {
                
                GameObject explosion = MonoBehaviour.Instantiate(Resources.Load("EffectExamples/FireExplosionEffects/Prefabs/SmallExplosionEffect", typeof(GameObject))) as GameObject;
                explosion.transform.SetPositionAndRotation(electric.transform.position, Quaternion.identity);
                explosion.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f);
                GameObject fire = MonoBehaviour.Instantiate(Resources.Load("EffectExamples/FireExplosionEffects/Prefabs/FlamesParticleEffect", typeof(GameObject))) as GameObject;
                fire.tag = "fire";
                fire.transform.SetPositionAndRotation(electric.transform.position, Quaternion.identity);
                fire.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f);
                GameObject smoke = MonoBehaviour.Instantiate(Resources.Load("EffectExamples/FireExplosionEffects/Prefabs/SmokeEffect", typeof(GameObject))) as GameObject;
                smoke.transform.SetPositionAndRotation(electric.transform.position, Quaternion.Euler(-90.0f, 0, 0));
                smoke.tag = "smoke";

                AudioSource audioSource = fire.AddComponent<AudioSource>();
                audioSource.clip = Resources.Load("Sound/Fire2") as AudioClip;
                audioSource.Play();
                audioSource.loop = true;
                audioSource.spatialBlend = 1;

                Destroy(electric);
                Destroy(explosion, 1.5f);
            }
        }
    }
}
