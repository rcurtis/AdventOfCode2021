module FSharp.Day3

open System


let part1 (input: string) =
    let getMostCommon (input : (char * int)[]) =
        match input with
        | [| ('0', zeroes); ('1', ones) |] | [| ('1', ones); ('0', zeroes) |] ->
            Some ( if zeroes > ones then 0 else 1)
        | _ -> None
    
    let input = input.Split "\r\n"
    
    let stringBinToDecimal (input: string) : int = Convert.ToInt32(input, 2)
    
    let transposed =
        input
        |> Array.map (fun it -> it.ToCharArray())
        |> Array.transpose
        |> Array.map (fun x -> x |> Array.countBy id )
        |> Array.choose getMostCommon
        |> Array.map string
    
    let gamma =
        String.Join("", transposed)
        |> stringBinToDecimal
        
    let epsilon =
        transposed
        |> Array.map (fun ch -> if ch = "1" then "0" else "1")
        |> fun it -> String.Join("", it)
        |> stringBinToDecimal
    
    (gamma, epsilon)
    
let part2 input = 5


module Test =
    open Xunit

    let smallInput =
        @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010"

    [<Fact>]
    let ``Part 1 Test`` () =
        let expected = (22, 9)
        let actual = part1 smallInput
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``Part 2 Test`` () =
        let expected = 5
        let actual = part2 smallInput
        Assert.Equal(expected, actual)