$source="../"
$directories=@("obj", "bin")

foreach ($path in $directories){
   echo "Deleting files in folder '$path'..."
   cd ($source); get-childitem -Include $path -Recurse -force | Remove-Item -Force -Recurse -Confirm:$false
   echo "Deleting files inf folder '$path' finished"    
}

Read-Host -Prompt "Press Enter to exit"

