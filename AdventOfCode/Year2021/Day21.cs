using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Extensions;

namespace AdventOfCode.Year2021
{
    class Day21 : IDay
    {
        public string ExampleInput => "Player 1 starting position: 4\nPlayer 2 starting position: 8";

        public long SolvePart1(string puzzleInput)
        {
            var matches = Regex.Matches(puzzleInput, @"Player (?<player>\d).*(?<start>\d)");
            int player1Position = int.Parse(matches[0].Groups["start"].Value);
            int player2Position = int.Parse(matches[1].Groups["start"].Value);
            int player1Points = 0;
            int player2Points = 0;

            int dice = 0;

            int diceRolls = 0;

            do
            {
                if (diceRolls % 2 == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        player1Position += ++dice;

                        if (dice > 100)
                            dice -= 100;
                    }

                    diceRolls += 3;

                    while (player1Position > 10)
                        player1Position -= 10;

                    player1Points += player1Position;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        player2Position += ++dice;

                        if (dice > 100)
                            dice -= 100;
                    }

                    diceRolls += 3;

                    while (player2Position > 10)
                        player2Position -= 10;

                    player2Points += player2Position;
                }
                
            } while (player1Points < 1000 && player2Points < 1000);
            
            return Math.Min(player1Points, player2Points) * diceRolls;
        }

        public long SolvePart2(string puzzleInput)
        {
            var matches = Regex.Matches(puzzleInput, @"Player (?<player>\d).*(?<start>\d)");

            Dictionary<(int player1Points, int player2Points, int player1Position, int player2Position, bool player1Turn), int> games = new()
            {
                { (0, 0, int.Parse(matches[0].Groups["start"].Value), int.Parse(matches[1].Groups["start"].Value), true), 1 }
            };

            long player1Wins = 0;
            long player2Wins = 0;

            do
            {
                Dictionary<(int player1Points, int player2Points, int player1Position, int player2Position, bool player1Turn), int> newGames = new();

                foreach (var game in games.Keys)
                {
                    for (int die1 = 1; die1 <= 3; die1++)
                    {
                        for (int die2 = 1; die2 <= 3; die2++)
                        {
                            for (int die3 = 1; die3 <= 3; die3++)
                            {
                                (int player1Points, int player2Points, int player1Position, int player2Position, bool player1Turn) splitGame = 
                                    new(game.player1Points, game.player2Points, game.player1Position, game.player2Position, game.player1Turn);

                                if (splitGame.player1Turn)
                                {
                                    splitGame.player1Position += die1 + die2 + die3;

                                    if (splitGame.player1Position > 10)
                                        splitGame.player1Position -= 10;

                                    splitGame.player1Points += splitGame.player1Position;
                                }
                                else
                                {
                                    splitGame.player2Position += die1 + die2 + die3;

                                    if (splitGame.player2Position > 10)
                                        splitGame.player2Position -= 10;

                                    splitGame.player2Points += splitGame.player2Position;
                                }

                                if (splitGame.player1Points >= 21)
                                    player1Wins += games[game];
                                else if (splitGame.player2Points >= 21)
                                    player2Wins += games[game];
                                else
                                {
                                    splitGame.player1Turn = !splitGame.player1Turn;
                                    if (!newGames.ContainsKey(splitGame))
                                        newGames.Add(splitGame, games[game] + 1);
                                    else
                                        newGames[splitGame] += games[game] + 1;
                                }
                            }
                        }
                    }
                }

                games = newGames;

            } while (games.Keys.Count > 0);

            return Math.Max(player1Wins, player2Wins);
        }
    }
}

namespace AdventOfCode.Extensions
{
}