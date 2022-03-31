

# this will convert the CSV from https://simplemaps.com/data/us-cities to a json file
# only some fields will be converted
function ConvertCityCsvToJson(){
    [cmdletbinding()]
    param(
        [string]$pathToCsv,
        [string]$outputFilePath
    )
    process{
        $results = Import-Csv -Path $pathToCsv |% {'{{"city":"{0}","state":"{1}","stateId":"{2}","lat":{3},"long":{4}}},' -f $_.city,$_.state_name,$_.state_id,$_.lat,$_.lng}

        $results[$results.Length -1] = $results[$results.Length -1].TrimEnd(",")

        # $results = $results.TrimEnd(",")
        Out-File -path $outputFilePath -InputObject "[" -NoNewline
        Out-File -path $outputFilePath -Append -InputObject $results
        Out-File -path $outputFilePath -Append -InputObject "]" -NoNewline
    }

}

ConvertCityCsvToJson -pathToCsv .\uscities.csv -outputFilePath .\uscities.json


