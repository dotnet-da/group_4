# C# & .NET Framework Group 4

### Contributors
- Oktay Bekar
- Patrick Geertz

<!-- ABOUT THE PROJECT -->
## The Project
Our goal was to create a simple Windows Application that lets you track statistics about anything. Doesn't matter if its about a video game, a sport or an every day task, every statistical category can be created by the user. Multiple different statistics can be grouped together by a collection.
### Example
Lets say you want to save the statistics you had last weekend on the soccer pitch. You had 1 goal, 2 assist, and a yellow card. First you would create new **Player** (or User), with your name, so you can later save the statistics of multiple different players. After that you need to create the statistical categories for the different stats (also called **type** on the database). So you would create the following types: goals, assist, yellow cards. These types are reusable and can be used every time you played another match.
Now you can create new **Collection** referencing the Player and containing the just created types with the matching values from your game. An automatic timestamp is added to that collection so you can even track your progress.

## The Backend
Our Database and API are both hosted on a virtual server (VPS) and is accessible from everywhere. To access the API you need to provide a API-Access-Key. This protects us from outside attacks and grants, that only people with the allowed rights can alter the data on the database via the API.
### Database Structure

![er_diagram](https://user-images.githubusercontent.com/31593666/189299145-aebd0d6b-67fa-49c9-b612-21ea0a6e6019.png)

### API Structure
The API has CRUD operations for every table on the database. As mentioned earlier, every HTTP request needs a API-Access-Key in the header, to provide security and safety. The API is accessible everywhere from this address: http://h073.de

## The Frontend
Our Frontend is a WPF Application which can perform CRUD operations on the database via the API. It allows us to add new players, types, collections and entries, while also giving us an overview of our existing objects and datasets.
