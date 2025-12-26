## Final Graduation Project
A 2.5D action-platformer where you control a young man who woke up in a suburban slum's junkyard with no memory of his past. Face mysterious creatures as you try to uncover what is happening in this city.

![compressed-M4M1qZKI](https://github.com/user-attachments/assets/3c820a3d-5e16-4305-9510-554d050b7155)

The game was developed as a final graduation project by a team of four students over eight months. In this project, the team decided not to have fixed roles for each member. Instead, we rotated responsibilities during development to better understand which areas we were most interested in. During this process, I became more interested in programming.

![PhronesisComBorda2 (2)](https://github.com/user-attachments/assets/e274d562-f233-4f5c-a787-91129a434aa7)

Throughout the project, I worked with programming, documentation, dialogue writing, and a small amount of 3D modeling.

---

## 🎮 Game Overview
- Tech Stack: Unity, C#, Github, Blender
- Platform: PC

---

## My Main Contributions
- Implemented the boss behavior and combat logic
  - [Boss.cs](Assets/Scripts/Boss/Boss.cs)
  - The boss system is composed of multiple supporting scripts handling:
    - Damage detection and hit reactions
    - Health, UI, and death flow
    - Visual and audio feedback (camera shake, particles)
    - Full implementation available in: [Boss Folder](Assets/Scripts/Boss)
- Developed a dialogue system using ScriptableObjects
  - [FalaNPC.cs](Assets/Scripts/FalasFinal/FalasNPCs/FalaNPC.cs) (ScriptableObject – dialogue data)
  - [RespostaKid.cs](Assets/Scripts/FalasFinal/Respostas/RespostaKid.cs) (Dialogue branching structure)
  - [KidDialogo.cs](Assets/Scripts/FalasFinal/Dialogos/KidDialogo.cs) (Dialogue trigger logic)
  - [KidController.cs](Assets/Scripts/FalasFinal/Controller/KidController.cs) (Dialogue flow and UI control)
  - [AnswerButtonKid.cs](Assets/Scripts/FalasFinal/BotãoResposta/AnswerButtonKid.cs) (UI interaction layer)
- Created a one-way platform logic using raycasts  
- Identified, monitored, and fixed gameplay bugs

---

## What I Would Do Differently Today - General overview
Looking back at the project, there are several things I would approach differently:
- I wouldn't mix English and Portuguese in the code
- I would write comments more often and with more detail
- I would use private variables and read-only properties instead of making most variables public
- I would use polymorphism. At the time, I was not familiar with this concept and didn't design a scalable architecture. Because of this, I created several repeated scripts with the same purpose for different NPCs, such as "KidDialogo", "VelhoDialogo", "ComandanteDialogo", and "MendigoDialogo"
- I would use events
- For performance reasons, I wouldn't use so many FindObjectOfType and string-based tag comparisons (tag == "Player").
- I would avoid scripts that handle too many responsibilities
  
## Boss System – Technical Reflection
This boss script was one of my first attempts at creating a more complex enemy behavior. It controls movement, attacks, combat phases, animations, and player interaction in a single script. At the time, my main goal was to make the fight feel dynamic and challenging. Today, I would improve this system by separating responsibilities into smaller scripts (movement, combat, phases, and animations), using a clear state machine instead of many boolean variables, and reducing code duplication. I would also improve code readability by using better naming, more comments, and a cleaner structure to make the system easier to maintain and extend.

---

## 🔗 Links
- Itch.io page: kaue-uriel.itch.io/phronesis
  
Despite its limitations, this project was an important step in my learning journey and helped me better understand how to work in a team and build complete game systems.
More recent projects on my profile show my current coding style and practices.
