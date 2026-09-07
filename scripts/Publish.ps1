param(
    [string]$Tag = '',
    [string]$OutputDirectory = (Join-Path $PSScriptRoot '../artifacts')
)

$ErrorActionPreference = 'Stop'
$project = Join-Path $PSScriptRoot '../TidalNowPlaying/TidalNowPlaying.csproj'
$publishArguments = @(
    'publish', $project, '-c', 'Release', '-r', 'win-x64',
    '--self-contained', 'false', '-p:PublishSingleFile=true',
    '-p:PublishReadyToRun=true', '-o', $OutputDirectory
)

if ($Tag) {
    if ($Tag -notmatch '^v(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)$') {
        throw 'Release tags must use vMAJOR.MINOR.PATCH, for example v1.0.2.'
    }
    $version = $Tag.Substring(1)
    $publishArguments += @(
        "-p:Version=$version",
        "-p:AssemblyVersion=$version.0",
        "-p:FileVersion=$version.0"
    )
}

& dotnet @publishArguments
if ($LASTEXITCODE -ne 0) {
    throw "dotnet publish failed with exit code $LASTEXITCODE."
}

$executable = Join-Path $OutputDirectory 'TidalNowPlaying.exe'
$hash = (Get-FileHash -LiteralPath $executable -Algorithm SHA256).Hash.ToLowerInvariant()
Set-Content -LiteralPath "$executable.sha256" -Value "$hash  TidalNowPlaying.exe" -Encoding ascii
Write-Host "Published executable and SHA-256 checksum to $OutputDirectory"
