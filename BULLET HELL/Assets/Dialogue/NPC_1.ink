INCLUDE Globals.ink
->main
===main====
 NPC 1: It's dangerous to go alone! Take this.
    + [Sniper]
            ->chosen("Sniper")
    + [SMG]
        ->chosen("SMG")
    +[Shotgun]
        ->chosen("Shotgun")
===chosen(weapon)===
~ weaponEquiped=weapon
    - Good luck out there. 

     
-> END