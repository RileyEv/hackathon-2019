using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class Blood : MonoBehaviour, IInputClickHandler
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
        GameObject blood = MonoBehaviour.Instantiate(Resources.Load("EffectExamples/Blood/Prefabs/BloodSprayEffect", typeof(GameObject))) as GameObject;
        blood.transform.SetPositionAndRotation(this.transform.position, Quaternion.identity);
        Destroy(blood, 2.0f);

        if(GameObject.Find("Lesson2(Clone)") == null)
        {
            GameObject lesson = MonoBehaviour.Instantiate(Resources.Load("Objects/Lesson2", typeof(GameObject))) as GameObject;
            Destroy(lesson, 10.0f);
        }
        


    }
}
