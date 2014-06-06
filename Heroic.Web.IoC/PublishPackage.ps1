#Remove existing packages
Remove-Item *.nupkg
#Create package
nuget pack 
#Push
$PackageName = gci "*.nupkg"
nuget push $PackageName
