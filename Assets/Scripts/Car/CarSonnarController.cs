using UnityEngine;

public class CarSonnarController : MonoBehaviour
{

    private Renderer rend;

    [SerializeField] private Transform worm;

    [Header("Distance Settings")]
    [SerializeField] float distRange1 = 1f;
    [SerializeField] float distRange2 = 2f;
    [SerializeField] float distRange3 = 3f;

    [Header("Speed Settings by Range")]

    [SerializeField] float speedRange1 = 3f;
    [SerializeField] float speedRange2 = 2f;
    [SerializeField] float speedRange3 = 1f;

    [Header("Color Settings by Range")]
    [SerializeField] private Color colorRange1 = Color.red;
    
    [SerializeField] private Color colorRange2 = Color.yellow;
    
    [SerializeField] private Color colorRange3 = Color.green;


    float dist;
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        GetDistanceFromWorm();
        ScaleObject();
        SetColor();
    }

    private void GetDistanceFromWorm()
    {
        dist = Vector3.Distance(worm.position, transform.position);
    }
    private void ScaleObject()
    {
        if (dist > distRange1)
            transform.localScale = new Vector3(Mathf.PingPong(Time.time * speedRange1, 0.1f) + 0.5f, Mathf.PingPong(Time.time * speedRange1, 0.1f) + 0.5f, Mathf.PingPong(Time.time * speedRange1, 0.1f) + 0.5f);
        if (dist > distRange2)
            transform.localScale = new Vector3(Mathf.PingPong(Time.time * speedRange2, 0.1f) + 0.5f, Mathf.PingPong(Time.time * speedRange2, 0.1f) + 0.5f, Mathf.PingPong(Time.time * speedRange2, 0.1f) + 0.5f);
        if (dist > distRange3)
            transform.localScale = new Vector3(Mathf.PingPong(Time.time * speedRange3, 0.1f) + 0.5f, Mathf.PingPong(Time.time * speedRange3, 0.1f) + 0.5f, Mathf.PingPong(Time.time * speedRange3, 0.1f) + 0.5f);
    }
    private void SetColor()
    {
        if (dist > distRange1)
            rend.material.color = colorRange1;
        if (dist > distRange2)
            rend.material.color = colorRange2;
        if (dist > distRange3)
            rend.material.color = colorRange3;

    }
}