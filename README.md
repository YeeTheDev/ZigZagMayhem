**README**

A small game created to practice the following patterns:

1. Observer Pattern
2. Singleton Pattern
3. Finite State Machines
4. State Pattern
5. Object Pooling
6. Stratey Pattern
7. Decorator Pattern
8. Composite Pattern
9. MVP Pattern

**--- Patterns and Implementation ---**

5. Object Pooling
	
	Object Pooling is used to recycle the endless path, re-use bullets, and to spawn enemies.
	I didn't use the Unity Pool Interface due to it being a 2021v feature, so I created a semi-generic Object Pool Monobehaviour class to be reused in all other areas where a pooler was needed.