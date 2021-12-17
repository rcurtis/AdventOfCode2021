module FSharp.Day2

open FSharp.Core
open Microsoft.VisualStudio.TestTools.UnitTesting

type State =
    { X: int; Y: int; Aim: int }
    static member empty = { X = 0; Y = 0; Aim = 0 }

let parseInstructions (input: string) =
    input.Split("\r\n")
    |> Array.map (fun it -> it.Split(" "))

let part1 (input: string) : (int * int) =
    let instructions = input |> parseInstructions

    let folder (state: State) (current: string array) : State =
        let magnitude = current.[1] |> int

        match current.[0] with
        | "forward" -> { state with X = state.X + magnitude }
        | "up" -> { state with Y = state.Y - magnitude }
        | "down" -> { state with Y = state.Y + magnitude }
        | _ -> failwith "invalid instruction"

    instructions
    |> Array.fold folder State.empty
    |> fun it -> (it.X, it.Y)

let part2 (input: string) : (int * int) =
    let instructions = input |> parseInstructions

    let folder (state: State) (current: string array) : State =
        let magnitude = current.[1] |> int

        match current.[0] with
        | "forward" ->
            { state with
                  X = state.X + magnitude
                  Y = state.Y + (state.Aim * magnitude) }
        | "up" ->
            { state with
                  Aim = state.Aim - magnitude }
        | "down" ->
            { state with
                  Aim = state.Aim + magnitude }
        | _ -> failwith "invalid instruction"

    instructions
    |> Array.fold folder State.empty
    |> fun it -> (it.X, it.Y)

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
