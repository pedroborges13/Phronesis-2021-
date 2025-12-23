## Final Graduation Project
A 2.5D action-platformer where you control a young man who woke up in a suburban slum's junkyard with no memory of his past. Face mysterious creatures as you try to uncover what is happening in this city.

The game was developed as a final graduation project by a team of four students over eight months.
In this project, the team decided not to have fixed roles for each member.  
Instead, we rotated responsibilities during development to better understand which areas we were most interested in. During this process, I became more interested in programming.

Throughout the project, I worked with programming, documentation, dialogue writing, and a small amount of 3D modeling.

---

## 🎮 Game Overview
- Tech Stack: Unity, C#, Github, Blender
- Platform: PC

---

## My Main Contributions
- Implemented the boss behavior and combat logic
  - [Boss.cs](Projeto5/Assets/Scripts/Enemies/Boss.cs)
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
- I would avoid mixing English and Portuguese in the code
- I would write comments more often and with more detail
- I would use private variables and read-only properties instead of making most variables public
- I would use more polymorphism. At the time, I was not familiar with this concept and didn't design a scalable architecture
  Because of this, I created several repeated scripts with the same purpose for different NPCs, such as "KidDialogo", "VelhoDialogo", "ComandanteDialogo", and "MendigoDialogo"
- I would avoid scripts that handle too many responsibilities
  
## Boss System – Technical Reflection
This boss script was one of my first attempts at creating a more complex enemy behavior. It controls movement, attacks, combat phases, animations, and player interaction in a single script. At the time, my main goal was to make the fight feel dynamic and challenging. Today, I would improve this system by separating responsibilities into smaller scripts (movement, combat, phases, and animations), using a clear state machine instead of many boolean variables, and reducing code duplication. I would also improve code readability by using better naming, more comments, and a cleaner structure to make the system easier to maintain and extend.

---

## 🔗 Links
- Itch.io page: kaue-uriel.itch.io/phronesis
  
Despite its limitations, this project was an important step in my learning journey and helped me better understand how to work in a team and build complete game systems.
More recent projects on my profile show my current coding style and practices.
