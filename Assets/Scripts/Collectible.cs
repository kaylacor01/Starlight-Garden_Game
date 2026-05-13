using UnityEngine;

public class Collectible : MonoBehaviour{
  public GameObject starPrefab;
  public GameObject sakuraPrefab;

  public int star = 10;
  public int sakura = 14;

  public Vector2 minPos;
  public Vector2 maxPos;

  void Start()
    {
        Spawn(starPrefab, star, true);
        Spawn(sakuraPrefab, sakura, false);
    }

  void Spawn(GameObject prefab, int count, bool heals)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 pos = new Vector2(
                Random.Range(minPos.x, maxPos.x),
                Random.Range(minPos.y, maxPos.y)
            );
            GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
            CollectibleItem item = obj.AddComponent<CollectibleItem>();
            item.heals = heals;
        }
    }
}

public class CollectibleItem : MonoBehaviour
{
    public bool heals;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (heals)
        {
            PlayerDeath hp = other.GetComponent<PlayerDeath>();
            hp.TakeDamage(-10);
            ScoreManager.instance.AddStar();
        }
        else{
          ScoreManager.instance.AddSakura();
        }
        Destroy(gameObject);
    }
}