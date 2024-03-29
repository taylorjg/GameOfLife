
# Game Of Life

I recently attended a Global Day of Coderetreat in Salford. I was part of a delegation from the company
where I work, DRL, which also co-sponsored the event.

The event involved pair programming and TDD. Each of the six pairings throughout the day lasted 45 minutes.
The exercise for the day was Conway's Game of Life.

During the week after the event, I decided to come up with a complete implementation of the exercise including
rendering to the console. This project is the result.

## Seeds

The first command line parameter identifies which seed pattern to use:

* 1 - [Blinker](http://en.wikipedia.org/wiki/File:Game_of_life_blinker.gif)
* 2 - [Toad](http://en.wikipedia.org/wiki/File:Game_of_life_toad.gif)
* 3 - [Beacon](http://en.wikipedia.org/wiki/File:Game_of_life_beacon.gif)
* 4 - [Pulsar](http://en.wikipedia.org/wiki/File:Game_of_life_pulsar.gif)
* 5 - [Glider](http://en.wikipedia.org/wiki/File:Game_of_life_animated_glider.gif)
* 6 - [Lightweight space ship](http://en.wikipedia.org/wiki/File:Game_of_life_animated_LWSS.gif)
* 7 - [R-pentomino](http://en.wikipedia.org/wiki/File:Game_of_life_fpento.svg)
* 8 - [Gun](http://en.wikipedia.org/wiki/File:Game_of_life_glider_gun.svg)

If no parameter is given, the seed defaults to Pulsar.

## Tick Sleep Interval

The optional second parameter controls the sleep interval between ticks. It defaults to 100ms.

## Links

* [Conway's Game of Life](http://en.wikipedia.org/wiki/Conway's_Game_of_Life)
* [Manchester Code Retreat 8th December 2012](http://manccoderetreat.eventbrite.com/)
* [Global Day of Coderetreat](http://globalday.coderetreat.org/)
* [DRL Limited](http://www.drllimited.co.uk/)
* [DRL's main website - www.appliancesonline.co.uk](http://www.appliancesonline.co.uk/)

## Screenshot of the Running Program

The following screenshot shows the R-pentomino seed after it has stabilised:

![Screenshot1](https://github.com/taylorjg/GameOfLife/raw/master/Images/GameOfLifeAppConsole1.png)

The following screenshot shows the Gun seed in action:

![Screenshot2](https://github.com/taylorjg/GameOfLife/raw/master/Images/GameOfLifeAppConsole2.png)

## Zombies!

I have added support for zombies i.e. cells that have been alive and then died and then come back to life again.
Zombie cells are displyed in magenta. Normal live cells are displayed in cyan.
Here is an updated screenshot of the R-pentomino seed showing some zombie cells.

![Screenshot3](https://github.com/taylorjg/GameOfLife/raw/master/Images/GameOfLifeAppConsole3.png)
