
https://unity3d.com/learn/tutorials/topics/cloud-build/creating-your-first-source-control-repository



How to use this CoderDojo project
==================================

- create a folder with your name
- under that folder, create a folder called MyScenes
- in that scene,  right click and add a Scene, give it a meaning full name. this will be the first world you design (aka level)
- in the scene, drag and drop the prefab called GameSystem
- delete the main camera


- add a layer called FireLayer (this is required by one of the explosion assets)
- add a tag called enemy

- add a terrain

- add a first person character controller


- create a gameobject, call it enemies (kind of a folder for enemies)

- drag on an enemy, give it the tag enemy
- drag the enemy gameobject in the enemies gameobject

- in the game system, pic an audio clip, this will be your background music






Current Game System Functionality
==================================
- Health bar
- Energy Bar
- Basic menu system



 How to do damage to the player
 ==============================

 private void doDamage()
    {
        HealthController h = GameObject.FindGameObjectWithTag("GameSystem").GetComponent<HealthController>();

        if (h!= null)
        {
            h.doDamage(damagePerHit);
        }

    }


# Git stuff
==============

Double check that it excludes meta files and the likes (and temp and library folder)
otherwise your download/upload takes forever

also, go to edit / project settigns / editor  and set Asset serialization to Force Text




TroubleShooting

-  When you get an error about a number regarding Firelayer, add a layer called firelayer (the explosion asset needs this)



