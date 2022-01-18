**README**

A small game created to practice the following patterns:

1. Observer Pattern
2. Singleton Pattern
3. Finite State Machines
4. State Pattern
5. Object Pooling
6. Strategy Pattern
7. Decorator Pattern
8. Composite Pattern
9. MVP Pattern

**--- Why do this? ---**

This project is for practice purposes, I've been taking a lot of courses and reading a lot about this patterns and I wanted to test them on my own.

Please, do not expect super tidy or clean code since I'll be forcing a lot of this patterns, for instance, my approach of the Singleton Pattern is overkill, there's no need for such complex code, a very basic singleton would be more than enough, but as I said, this game is being created for practicing purposes so I'm doing things that I wouldn't normally do.

**--- Patterns and Implementation ---**

1. Observer Pattern / MVP Pattern

	The MVP pattern is pretty much linked to the observer pattern. The idea is to have a "Presenter" that is aware of a "Module", but the module cannot know about the presenter, in this case the Module is the Player Statistics and the Presenter is the User Interface. To achieve this an event is used, nothing fancy, just a simple action.

2. Singleton Pattern

	In this case I wanted to play a little bit with sealed classes and a way to create singletons. Instead of having a class in the hierarchy, I created a class that keeps track of all the items that aren't supposed to be destroyed on load, you can even remove them from the list so you can destroy them if the need is there.
	
	The big downside is that I used strings to check, but I suppose you could use types instead, like checking if there's another "PlayerController" in there and act accordingly.

3. Object Pooling
	
	When I first implemented the Object Pooling system I realized that I didn't need it to be generic, so I created two, and maybe arguably, three, types of object pooling:
	1. The Road Creator script uses a list that Unity already has in the Transform class, Child, I used this because the pooling will always occur in a very orderly fashion, the first in line will always become the last in line. Instead of using an overcomplicated pooling system, I just move the first part of the road created and then set it as the last child. Lastly, the road parts don't need to know about the object pooler, which makes things easier to code.
	2. The original pooler was supposed to be a somewhat generic class to be used as a pooler for any sort of object, I realized this wasn't truly necessary so I changed it to a more specific type of pooler, a Bullet Pooler. In this case the bullets need to know about the pooler to enqueue themselves after finishing whatever they were doing which might occur at pretty much anytime between 0 and 4 seconds, that means that the first out might not be the first to return to the queue, it might be the last, so I actually needed a more complicated list (Queue in this case), still FIFO, but with the capacity to let any bullet object to enqueue at any time.

	This was not intended, after some refactors I realized I used the same pattern in two very different ways which was kinda cool when I noticed.

4. Strategy / Decorator / Composite

	The item system uses this 3 patterns, maybe the Decorator not so much, but it is there in spirit. I used Monobehaviours for this, I wanted to see if this was plausible and it was, definitely not the best approach, ScriptableObjects would be so much better and simpler but the idea of all of this is to push myself. I also tried this using pure C#, no Monobehaviours involved, it worked but it was way too convoluted to be considered useful.
	
	I'm quite surprised by the result, I loved it because this allows me to create almost an infite arrange of items why just 4 abilites; Heal, Destroy All Enemies, Invincibility, Delay Cast. I can create pretty much any sort of combination, like Heal > Delay > DestrolAll, or Heal > Delay > Heal > Deal, I was able to create a HoT (Heal Over Time) without actually coding that. I used this patterns in the past but not like this, I'm quite amazed by interfaces power and flexibility, the only downside is that Unity doesn't handle Interface in the inspector which is a downside, that's why SO are probably a better choice for this sort of system.