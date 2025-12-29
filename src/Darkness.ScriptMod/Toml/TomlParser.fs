module Darkness.ScriptMod.Toml.TomlParser

open Tomlyn

let Parser<'T when 'T: (new: unit -> 'T) and 'T : not struct>(text:string) : Result<'T,string> =
    try
        let model = Toml.Parse(text).ToModel<'T>()
        Ok model
    with ex ->
        Error "Failed"