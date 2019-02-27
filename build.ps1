param (
    [string]$outDir = ".build",
    [string]$baseHref = "taskly_prod"
)

Write-Host "Building app to directory '$outDir'"
Write-Host "Site name is '$baseHref'"

# clear output directory
if(Test-Path -Path $outDir){ 
    Remove-Item -Recurse -Force $outDir 
}

#build app server
cd server
dotnet restore
dotnet publish --output ..\..\$outDir --configuration Debug
cd ..
if (!$?){ 
    Write-Host "An error occurred while building the application server. For more information see logs."
    exit $LASTEXITCODE 
}

#build client
cd client
npm install
ng build --base-href /$baseHref/ --output-path ..\$outDir\wwwroot
if (!$?){ 
    Write-Host "An error occurred while building the client app. For more information see logs."
    exit $LASTEXITCODE 
}
cd ..