module FSharp.Day2

open FSharp.Core
open Microsoft.VisualStudio.TestTools.UnitTesting

type State =
    { x: int
      y: int
      aim: int }
    static member empty = { x = 0; y = 0; aim = 0 }

let parseInstructions (input: string) =
    input.Split("\r\n")
    |> Array.map (fun it -> it.Split(" "))

let part1 (input: string) : (int * int) =
    let instructions = input |> parseInstructions

    let folder (state: State) (current: string array) : State =
        let magnitude = current.[1] |> int

        match current.[0] with
        | "forward" -> { state with x = state.x + magnitude }
        | "up" -> { state with y = state.y - magnitude }
        | "down" -> { state with y = state.y + magnitude }

    instructions
    |> Array.fold folder State.empty
    |> fun it -> (it.x, it.y)

let part2 (input: string) : (int * int) =
    let instructions = input |> parseInstructions

    let folder (state: State) (current: string array) : State =
        let magnitude = current.[1] |> int

        match current.[0] with
        | "forward" ->
            { state with
                  x = state.x + magnitude
                  y = state.y + (state.aim * magnitude) }
        | "up" ->
            { state with
                  aim = state.aim - magnitude }
        | "down" ->
            { state with
                  aim = state.aim + magnitude }

    instructions
    |> Array.fold folder State.empty
    |> fun it -> (it.x, it.y)

module Test =
    open Xunit

    let smallInput =
        @"forward 5
down 5
forward 8
up 3
down 8
forward 2"

    [<Fact>]
    let ``Part 1 Test`` () =
        let expected = (15, 10)
        let actual = part1 smallInput
        Assert.Equal(expected, actual)

    [<Ignore>]
    [<Fact>]
    let ``Part 2 Test`` () =
        let expected = (15, 60)
        let actual = part2 smallInput
        Assert.Equal(expected, actual)
