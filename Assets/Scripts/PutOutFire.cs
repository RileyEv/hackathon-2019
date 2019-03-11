using UnityEngine;


public class PutOutFire : MonoBehaviour
{
    private GameObject fire;
    private GameObject smoke;
    private GameObject fireExtinguisher;
    // Start is called before the first frame update
    void Start()
    {
        fire = GameObject.FindWithTag("fire");
        smoke = GameObject.FindWithTag("smoke");
        fireExtinguisher = GameObject.Find("FireExtinguisher");
    }

    // Update is called once per frame
    void Update()
    {
        if (fire)
        {
            if (Vector3.Distance(this.transform.position, fire.transform.position) < 1.0f)
            {
                Destroy(fire);
                Destroy(smoke);
                AudioSource extinguisherSource = fireExtinguisher.AddComponent<AudioSource>();
                extinguisherSource.clip = Resources.Load("Sound/FireExtinguisher") as AudioClip;
                extinguisherSource.Play();

                GameObject lesson = MonoBehaviour.Instantiate(Resources.Load("Objects/Lesson1", typeof(GameObject))) as GameObject;
                Destroy(lesson, 10.0f);

            }
        }
        else
        {
            fire = GameObject.FindWithTag("fire");
            smoke = GameObject.FindWithTag("smoke");
        }
    }
}
