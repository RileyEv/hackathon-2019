using HoloToolkitExtensions.Messaging;
using UnityEngine;

public class ObjectDisplayer : MonoBehaviour
{
    void Start()
    {
        Messenger.Instance.AddListener<PositionFoundMessage>(ShowObject);

#if !UNITY_EDITOR
        gameObject.SetActive(false);
#endif
    }

    private void ShowObject(PositionFoundMessage m)
    {
        if (m.Status == PositionFoundStatus.Accepted)
        {
            Vector3 newPosition = new Vector3(transform.position.x, m.Location.y,
                transform.parent.transform.position.z) + Vector3.up * 0.05f;
            transform.position = newPosition;

            GameObject extensionLead = GameObject.Find("Extension_cable");
            extensionLead.transform.SetPositionAndRotation(newPosition + new Vector3(0.5f, 0.51f, 2.0f), Quaternion.identity);
            extensionLead.GetComponent<Rigidbody>().useGravity = true;

            GameObject beer = GameObject.Find("Beer");
            beer.transform.SetPositionAndRotation(newPosition + new Vector3(-0.635f, 0.782f, 2.862f), Quaternion.identity);
            beer.GetComponent<Rigidbody>().useGravity = true;
            

            GameObject fireExtin = GameObject.Find("FireExtinguisher");
            fireExtin.transform.SetPositionAndRotation(newPosition + new Vector3(-0.09f, 0.71f, 1.0f), Quaternion.identity);
            fireExtin.GetComponent<Rigidbody>().useGravity = true;

            GameObject saw = GameObject.Find("Saw");
            saw.transform.SetPositionAndRotation(newPosition + new Vector3(0.5f, 0.51f, 3.0f), Quaternion.identity);
            saw.GetComponent<Rigidbody>().useGravity = true;

            GameObject solder = GameObject.Find("soldering-iron");
            solder.transform.SetPositionAndRotation(newPosition + new Vector3(-1.0f, 2.0f, 3.5f), Quaternion.identity);
            solder.GetComponent<Rigidbody>().useGravity = true;



            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
