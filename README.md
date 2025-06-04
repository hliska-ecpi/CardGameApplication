# C# Console Card Game Application

## Overview

This project is a console-based card game application written in C# that showcases core object-oriented programming concepts such as abstraction, polymorphism, inheritance, and encapsulation. It includes multiple playable card games, a shared scoreboard system, persistent statistics storage.

## Features

- Multiple card games implemented using a shared interface (`ICardGame`):
  - High Card
  - Blackjack
  - War
- Shared scoreboard system (`IScoreboard`) that tracks wins, losses, and rounds per game
- Scoreboard stats are saved and loaded from a text file 
- Use of console colors for better visual feedback

## Technologies Used

- C#
- .NET Console Application
- File I/O
- Object-Oriented Programming

## Project Structure

```
/CardGameApp
│
├── Interfaces/
│   ├── ICardGame.cs
│   └── IScoreboard.cs
│
├── Services/
│   └── Scoreboard.cs
│
├── Games/
│   ├── HighCardGame.cs
│   ├── BlackjackGame.cs
│   └── WarGame.cs
│
├── Data/
│   ├── Deck.cs
│   └── Card.cs
│
├── Program.cs
├── scoreboard.txt
└── README.md
```

## How to Run

### Prerequisites

- .NET SDK installed

### Steps

1. Clone the repository or copy the source code into a new console project.
2. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```
3. Select a game to play from the menu.
4. View your results and overall statistics after each game.
5. The scoreboard is saved automatically to `scoreboard.txt`.

## OOP Concepts Demonstrated

| Concept        | Implementation                          |
|----------------|------------------------------------------|
| Abstraction    | Interfaces `ICardGame` and `IScoreboard` |
| Polymorphism   | Runtime dispatch via `ICardGame`         |
| Encapsulation  | `Scoreboard`  |
| Inheritance    | Common game structure across classes     |

## Console Enhancements

- Green text for wins
- Red text for losses
- Yellow for ties or neutral messages
- Cyan headers for the scoreboard and menus

## Extending the Project

You can extend this project by:

- Adding new games (e.g., Poker, Go Fish)
- Creating a leaderboard from SQLite data
- Exporting results to CSV
- Adding a UI layer with WPF or MAUI
- Adding multiplayer support

## License

This project is for educational purposes and may be reused and modified freely.

## Author

This project was developed by an instructor to demonstrate clean code structure, OOP design, and basic data handling in C#.
