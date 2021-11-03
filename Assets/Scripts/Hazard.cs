using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{

        void OnCollisionEnter(Collision col)
        {
        if (col.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("Marshmallow_Level_2");
        }
    }
}
