using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

   private Image HealthBar;
    float CurrentHealth;
   float MaxHealth;
   PlayerControl PlayerControlRef;
   public GameObject PlayerGB;

    void Start()
    {
      HealthBar = GetComponent<Image>();

      PlayerControlRef = PlayerGB.GetComponent<PlayerControl>();

      MaxHealth = PlayerControlRef.Health;

    }

    void Update()
    {
      CurrentHealth = PlayerControlRef.Health;
      HealthBar.fillAmount = CurrentHealth / MaxHealth;

    }
}
