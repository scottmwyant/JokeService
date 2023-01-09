#
# This script shows how to install / start / stop / delete
# the service on the client machine.
#

$verb = $Args[0].ToString().ToLower()
$serviceName = ".Net Joke Service"
$binPath = "C:\users\swyant\dev\mqtt\out\JokeService.exe"

if ($verb -eq "install"){
    Write-Host "Add the service to the registry."
    sc.exe create $serviceName binpath=$binPath
}
elseif ($verb -eq "start") {
    Write-Host "Start the service."
    sc.exe start $serviceName
}
elseif ($verb -eq "stop") {
    "Stop the service."
    sc.exe stop $serviceName
}
elseif ($verb -eq "delete") {
    Write-Host "Remove the service from the registry."
    sc.exe delete $serviceName
}
elseif($verb -eq "test"){
    Write-Host "Install and start."
    sc.exe create $serviceName binpath=$binPath
    sc.exe start $serviceName
}
else{
    Write-Warning "Invalid command!"
}
