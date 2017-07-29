# SportsViewer

### Mantainer: Tao Wei

Given a file (rugby_athletes.json in this directory), containing a JSON encoded list of Squads and Athletes, output one team for each squads using the following criteria.

* No athletes in the team should be injured
* A Rugby Union team comprises of: 2 props, 1 hooker, 2 locks, 2 flankers, 1 Number Eight, 1 Scrum Half, 1 Out Half, 2 Centres, 2 Wingers, 1 Full Back
* The output should contain at least the following - squad name, squad ID and a list of the players with their position, eg 'prop - Colm Doyle'
* Where a full team cannot be made for each squad, the missing positions should be listed.