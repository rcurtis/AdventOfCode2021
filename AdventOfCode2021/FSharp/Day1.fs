module FSharp.Day1

open System.IO
open FSharp.Core

let parseFileInput (path: string) : string = File.ReadAllText(path)

let parseInput (text: string) : int array =
    text.Split("\r\n")
    |> Array.map (fun it -> it |> int)

type State =
    { last: int option
      total: int }
    static member empty = { last = None; total = 0 }


let part1 (text: string) : int =
    let input = parseInput text

    let folder (state: State) (current: int) : State =
        match state.last with
        | None -> { state with last = Some current }
        | Some last ->
            match current > last with
            | true -> { last = Some current; total = state.total + 1 }
            | false -> { state with last = Some current }

    input
    |> Array.fold folder State.empty
    |> fun it -> it.total


let part2 (text: string) : int =
    let input = parseInput text

    let folder (state: State) (current: int []) : State =
        let sum = current |> Array.sum
        
        match state.last with
        | None -> { state with last = Some sum }
        | Some last ->
            match sum > last with
            | true -> { last = Some sum; total = state.total + 1 }
            | false -> { state with last = Some sum }

    input
    |> Array.windowed 3
    |> Array.fold folder State.empty
    |> fun it -> it.total


module Test =
    open Xunit

    let smallInput =
        @"199
200
208
210
200
207
240
269
260
263"

    [<Fact>]
    let ``Part 1 Test`` () =
        let expected = 7
        let actual = part1 smallInput
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Part 2 Test`` () =
        let expected = 5
        let actual = part2 smallInput
        Assert.Equal(expected, actual)
