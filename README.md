# C# & .NET Framework Group 4

<!-- ABOUT THE PROJECT -->
## The Project
Our goal was to create a simple Windows Application that lets you track statistics about anything. Doesn't matter if its about a video game, a sport or an every day task, every statistical category can be created by the user. Multiple different statistics can be grouped together by a collection.
### Example
Lets say you want to save the statistics you had last weekend on the soccer pitch. You had 1 goal, 2 assist, and a yellow card. First you would create new **Player** (or User), with your name, so you can later save the statistics of multiple different players. After that you need to create the statistical categories for the different stats (also called **type** on the database). So you would create the following types: goals, assist, yellow cards. These types are reusable and can be used every time you played another match.
Now you can create new **Collection** referencing the Player and containing the just created types with the matching values from your game. An automatic timestamp is added to that collection so you can even track your progress.

## The Backend
Our Database and API are both hosted on a virtual server (VPS) and is accessible from everywhere. To access the API you need to provide a API-Access-Key. This protects us from outside attacks and grants, that only people with the allowed rights can alter the data on the database via the API.
### Database Structure

![ER-Diagram](er_diagramm.png)
