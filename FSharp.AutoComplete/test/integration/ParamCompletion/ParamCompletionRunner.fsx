#load "../TestHelpers.fsx"
open TestHelpers
open System.IO
open System

(*
 * This test is a simple sanity check of a basic run of the program.
 * A few completions, files and script.
 *)

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
File.Delete "output.txt"

let p = new FSharpAutoCompleteWrapper()

p.send "outputmode json\n"
p.project "Test1.fsproj"
p.parse "FileTwo.fs"
p.parse "Program.fs"
Threading.Thread.Sleep(8000)
p.methods "Program.fs" 8 28
p.methods "Program.fs" 6 18
p.methods "Program.fs" 4 36
Threading.Thread.Sleep(1000)
p.send "quit\n"
p.finalOutput ()
|> writeNormalizedOutput "output.json"
