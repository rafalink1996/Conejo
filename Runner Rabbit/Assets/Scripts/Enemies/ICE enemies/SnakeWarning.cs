using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWarning : MonoBehaviour, IPooledObject
{
    [SerializeField] SpriteRenderer mySpriteRenderer = null;
    [SerializeField] SpriteRenderer ArrowSpriteRenderer = null;
    [SerializeField] GameObject SnakePrefab = null;

    ObjectPooler myObjectPooler;
    string SnakeTag = "Snake";
    // Start is called before the first frame update
    private void Awake()
    {
        myObjectPooler = ObjectPooler.Instance;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        myObjectPooler = ObjectPooler.Instance;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void OnObjectSpawn()
    {
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        for (int i = 0; i < 10; i++)
        {

            mySpriteRenderer.color = new Color(1f, 1f, 1f, 0.4f);
            if (ArrowSpriteRenderer != null)
            {
                ArrowSpriteRenderer.color = new Color(0.5f, 1f, 1f, 0.4f);
            }
            
            yield return new WaitForSeconds(.1f);
            FindObjectOfType<AudioManager>().Play("SnakeWarning");
        mySpriteRenderer.color = new Color(1f, 1f, 1f, 1);
            if (ArrowSpriteRenderer != null)
            {
                ArrowSpriteRenderer.color = new Color(0.5f, 1f, 1f, 1);
            }
            yield return new WaitForSeconds(.1f);

        }

        //Instantiate(SnakePrefab, transform.position + new Vector3(30, 0, 0), Quaternion.identity);
       GameObject snake = myObjectPooler.SpawnFromPool(SnakeTag, transform.position + new Vector3(30, 0, 0), Quaternion.identity);
       
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }
}
