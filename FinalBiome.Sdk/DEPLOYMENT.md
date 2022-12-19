# Deployment Instruction
1. Build
    ```sh
    dotnet build --configuration Release finalbiome-sdk-cs.sln
    ```

2. Pack
    ```sh
    dotnet pack --configuration Release ./FinalBiome.Sdk/FinalBiome.Sdk.csproj
    ```

3.  Bump package version
    ```sh
    dotnet tool install --global Versionize
    versionize
    ```

    If command not found error, add in the ~/.zshrc the next line `export PATH=$HOME/.dotnet/tools:$PATH`

3. Publish (set new version before)
    ```sh
    dotnet nuget push ./FinalBiome.Sdk/bin/Release/FinalBiome.Sdk.1.0.1.nupkg --api-key oy2lh4de4yia32yuko5qlw77x2cazlauji4ruthjd7lnz4 --source https://api.nuget.org/v3/index.json
    ```
