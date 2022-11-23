# FinalBiome Api Codegen

The console application for automatically generating types and methods from node metadata for the [FinalBiome.Api](../FinalBiome.Api/README.md)

## Usage
There are two options to using app:
* `--output` - the output directory for the generated code.
* `--endpoint` - endpoint to connect to a node. Default `ws://127.0.0.1:9944`

Execution this app will generate c# code for types and methods for using in [](../Console.Api/).

For security reasons, the generated code must be manually moved to the [Artifacts](../FinalBiome.Api/Artifacts/) folder, removing the existing code there.
