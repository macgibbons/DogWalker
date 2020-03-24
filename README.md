# DogWalker

This is a `console application` using C# and a SQL database to practice implementing CRUD fucntionality and to understand data relationships in SQL

The database consists of the following tables:
* Dogs (can belong to one owner)
* Walkers (can work in one neighborhood but walk many dogs)
* Owners (can own many dogs but live in one neighborhood)
* Neighborhoods 
* Walks (join table between walkers and dogs)


#### Functionality

 The user can 
* view all owners and their dogs, walkers, and neighborhoods
*  Create new owners and walkers
* View Owners by neighborhoods
* Choose a walker and an owner and have the walker walk every one of the selcted owner's dogs for a determinted amount of time
 
   ... The walk method adds a walk to the Walks join table on my SQL database and prints a confirmation message to the console

