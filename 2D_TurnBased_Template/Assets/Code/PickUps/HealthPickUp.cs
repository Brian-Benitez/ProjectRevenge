using UnityEngine;

public class HealthPickUp : BasePickUp
{
    public GameObject EKeyButtonGO;
    public bool WithinRange = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && WithinRange)
        {
            gameObject.SetActive(false);
            HealPlayer();
            PlayerController.Instance.Player.GetComponent<BaseCharacter>().UpdatePlayersStats();
            Debug.Log("healed");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EKeyButtonGO.SetActive(true);
            WithinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EKeyButtonGO.SetActive(false);
        WithinRange = false;
    }
}
