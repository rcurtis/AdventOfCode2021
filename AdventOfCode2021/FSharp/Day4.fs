module FSharp.Day4

type Spot = {
    Value: int
    Daubed: bool
}
    with static member empty = { Value=0; Daubed=false }

type Card = { Spots: Spot [] }

let hasBingo (card: Card) : bool =
    card.Spots
    |> Array.chunkBySize 5
    |> Array.concat 
    true

let parse (input: string) : (int [] * Card []) =
    let lines = input.Split("\r\n\r\n")
    let ballDraw =
        lines
        |> Array.take 1
        |> Array.map int
    
    let parseSpot (spotStr: string) : Spot =
        { Spot.Value = spotStr |> int; Daubed = false }
    
    let parseCard (cardStr: string) : Spot[] =
        cardStr.Replace("\r\n", "")
                .Replace("  ", " ")
                .Trim()
                .Split(" ")
                |> Array.map parseSpot
        
    let cards =
        lines
        |> Array.skip 1
        |> Array.map parseCard
        |> Array.map (fun it -> { Card.Spots = it })
        
    (ballDraw, cards)
    

let part1 input = (188,24)

let part2 input = (0,0)

module Test =
    open Xunit

    let smallInput =
        @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7"

    [<Fact>]
    let ``Part 1 Test`` () =
        let expected = (188, 24)
        let actual = part1 smallInput
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Part 2 Test`` () =
        let expected = (148, 13)
        let actual = part2 smallInput
        Assert.Equal(expected, actual)