using UnityEngine;

public class Balloon : MonoBehaviour {

    public Color color = Color.white;
    public GameObject balloon;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void OnHit()
    {
        //Als de balloon dood gaat
        for (int i = 0; i < 2; i++)
        {
            if (transform.localScale.x > 0.07f)
            {
                GameObject newBalloon = Instantiate(balloon, transform.position + Random.insideUnitSphere * 0.2f, Quaternion.identity);
                newBalloon.transform.localScale = transform.localScale / 2;
                newBalloon.GetComponent<Balloon>().color = new Color(Random.value, Random.value, Random.value, 1);
            }
        }
        Destroy(gameObject);
    }
}
