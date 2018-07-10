using UnityEngine;

public class Balloon : MonoBehaviour {

    public Color color = Color.white;
    public GameObject balloon;
    public float speed = 0.3f;

    private PlayerController player;
    private Rigidbody rb;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!player)
        {
            player = FindObjectOfType<PlayerController>();
            return;
        }
        if (player.isDead)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + Vector3.up * 0.5f, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, player.transform.position + Vector3.up * 0.5f) < 1f)
        {
            player.GetComponent<PlayerController>().Dead();
        }
    }

    public void OnHit()
    {
        //Als de balloon dood gaat
        for (int i = 0; i < 2; i++)
        {
            if (transform.localScale.x > 0.14f)
            {
                GameObject newBalloon = Instantiate(balloon, transform.position + Random.insideUnitSphere * 0.2f, Quaternion.identity);
                newBalloon.transform.localScale = transform.localScale / 2;
                newBalloon.GetComponent<Balloon>().color = new Color(Random.value, Random.value, Random.value, 1);
            }
        }
        Destroy(gameObject);
    }
}
