using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class Singe : MonoBehaviour, IInputClickHandler
{


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
      
        GameObject smoke = MonoBehaviour.Instantiate(Resources.Load("EffectExamples/FireExplosionEffects/Prefabs/SmokeEffect", typeof(GameObject))) as GameObject;
        smoke.transform.SetPositionAndRotation(this.transform.position, Quaternion.Euler(-90.0f, 0, 0));
        Destroy(smoke, 2.0f);

        if (GameObject.Find("Lesson3(Clone)") == null)
        {
            GameObject lesson = MonoBehaviour.Instantiate(Resources.Load("Objects/Lesson3", typeof(GameObject))) as GameObject;
            Destroy(lesson, 10.0f);
        }



    }
}
