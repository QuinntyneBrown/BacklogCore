# Script to convert C# files to file-scoped namespaces
$files = Get-ChildItem -Path "c:\projects\BacklogCore" -Filter "*.cs" -Recurse

$convertedCount = 0
$failedFiles = @()

foreach ($file in $files) {
    try {
        $content = Get-Content $file.FullName -Raw
        
        # Check if file has traditional namespace
        if ($content -match '(?m)^namespace\s+([\w.]+)\s*$\s*\{') {
            $namespace = $matches[1]
            
            # Find the namespace line and opening brace
            $lines = $content -split "`r?`n"
            $namespaceLineIndex = -1
            $openBraceIndex = -1
            
            for ($i = 0; $i -lt $lines.Count; $i++) {
                if ($lines[$i] -match '^namespace\s+([\w.]+)\s*$') {
                    $namespaceLineIndex = $i
                }
                elseif ($namespaceLineIndex -ge 0 -and $lines[$i] -match '^\{\s*$') {
                    $openBraceIndex = $i
                    break
                }
            }
            
            if ($namespaceLineIndex -ge 0 -and $openBraceIndex -ge 0) {
                # Convert namespace to file-scoped
                $newLines = @()
                
                # Copy lines before namespace (using statements, etc.)
                for ($i = 0; $i -lt $namespaceLineIndex; $i++) {
                    $newLines += $lines[$i]
                }
                
                # Add file-scoped namespace
                $newLines += "namespace $namespace;"
                
                # Skip the opening brace line
                # Dedent and copy all lines after opening brace
                $foundClosingBrace = $false
                for ($i = $openBraceIndex + 1; $i -lt $lines.Count; $i++) {
                    $line = $lines[$i]
                    
                    # Check if this is the final closing brace
                    if ($i -eq $lines.Count - 1 -and $line -match '^\}\s*$') {
                        $foundClosingBrace = $true
                        break
                    }
                    
                    # Dedent by 4 spaces or 1 tab
                    if ($line -match '^    (.*)$') {
                        $newLines += $matches[1]
                    }
                    elseif ($line -match '^\t(.*)$') {
                        $newLines += $matches[1]
                    }
                    else {
                        $newLines += $line
                    }
                }
                
                # Write the new content
                $newContent = $newLines -join "`r`n"
                Set-Content -Path $file.FullName -Value $newContent -NoNewline
                $convertedCount++
                Write-Host "Converted: $($file.FullName)"
            }
        }
    }
    catch {
        $failedFiles += $file.FullName
        Write-Host "Failed: $($file.FullName) - Error: $_" -ForegroundColor Red
    }
}

Write-Host "`n========================================" -ForegroundColor Green
Write-Host "Conversion Complete!" -ForegroundColor Green
Write-Host "Files converted: $convertedCount" -ForegroundColor Green
Write-Host "Files failed: $($failedFiles.Count)" -ForegroundColor Yellow
if ($failedFiles.Count -gt 0) {
    Write-Host "`nFailed files:" -ForegroundColor Yellow
    $failedFiles | ForEach-Object { Write-Host "  $_" -ForegroundColor Yellow }
}
