using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAbilityController : MonoBehaviour
{
    //public List<Ability> playerAbilityList = new List<Ability>();
    List<Component> components = new List<Component>();
    //going to need a dictionary of some sort
    //thinking it should be the component and id
    //just a way to store the components that we have gathered and then quickly reference them
    //they have names and I added a variable for the Id
    //just need to sit back and think on which way we want to go with this
    private float timer = 0;
    private void Update()
    {
        components.Add(this.gameObject.GetComponent<SimpleUnlock>());
    }
}
