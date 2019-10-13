using System;
using System.Drawing;

namespace CSharp8.Features
{
    class SwitchExpression
    {
        public enum Rainbow
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        public static Color FromRainbow(Rainbow colorBand) => colorBand switch
        {
            Rainbow.Red => Color.FromArgb(1, 2, 3),
            Rainbow.Orange => Color.FromArgb(4, 5, 6),
            Rainbow.Yellow => Color.FromArgb(7, 8, 9),
            Rainbow.Green => Color.FromArgb(1, 2, 3),
            Rainbow.Blue => Color.FromArgb(4, 5, 6),
            Rainbow.Indigo => Color.FromArgb(7, 8, 9),
            Rainbow.Violet => Color.FromArgb(1, 2, 3),
            _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
        };
    }

    class PropertyPattern
    {
        public class Address
        {
            public string State { get; } = "WA";
        }

        public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
            location switch
            {
                { State: "WA" } => salePrice * 0.06M,
                { State: "MN" } => salePrice * 0.75M,
                { State: "MI" } => salePrice * 0.05M,
                _ => 0M
            };
    }

    class TuplePatter
    {
        public string RockPaperScissors(string first, string second)
            => (first, second) switch
            {
                ("rock", "paper") => "rock is covered by paper. Paper wins.",
                ("rock", "scissors") => "rock breaks scissors. Rock wins.",
                ("paper", "rock") => "paper covers rock. Paper wins.",
                ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
                ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
                ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
                (_, _) => "tie"
            };
    }
}